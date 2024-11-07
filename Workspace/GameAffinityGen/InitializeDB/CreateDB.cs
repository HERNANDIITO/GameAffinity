
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.CEN.GameAffinity;
using GameAffinityGen.Infraestructure.Repository.GameAffinity;
using GameAffinityGen.Infraestructure.CP;
using GameAffinityGen.ApplicationCore.Exceptions;

using GameAffinityGen.ApplicationCore.CP.GameAffinity;
using GameAffinityGen.Infraestructure.Repository;

/*PROTECTED REGION END*/
namespace InitializeDB
{
    public class CreateDB
    {
        public static void Create(string databaseArg, string userArg, string passArg)
        {
            String database = databaseArg;
            String user = userArg;
            String pass = passArg;

            // Conex DB
            SqlConnection cnn = new SqlConnection(@"Server=(local)\sqlexpress; database=master; integrated security=yes");

            // Order T-SQL create user
            String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN [" + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END";

            //Order delete user if exist
            String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
            //Order create databas
            string createBD = "CREATE DATABASE " + database;
            //Order associate user with database
            String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
            SqlCommand cmd = null;

            try
            {
                // Open conex
                cnn.Open();

                //Create user in SQLSERVER
                cmd = new SqlCommand(createUser, cnn);
                cmd.ExecuteNonQuery();

                //DELETE database if exist
                cmd = new SqlCommand(deleteDataBase, cnn);
                cmd.ExecuteNonQuery();

                //CREATE DB
                cmd = new SqlCommand(createBD, cnn);
                cmd.ExecuteNonQuery();

                //Associate user with db
                cmd = new SqlCommand(associatedUser, cnn);
                cmd.ExecuteNonQuery();

                System.Console.WriteLine("DataBase create sucessfully..");
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
        }

        public static void InitializeData()
        {
            try
            {
                // Initialising  CENs
                RegistradoRepository registradorepository = new RegistradoRepository();
                RegistradoCEN registradocen = new RegistradoCEN(registradorepository);
                ModeradorRepository moderadorrepository = new ModeradorRepository();
                ModeradorCEN moderadorcen = new ModeradorCEN(moderadorrepository);
                ListaRepository listarepository = new ListaRepository();
                ListaCEN listacen = new ListaCEN(listarepository);
                ResenyaRepository resenyarepository = new ResenyaRepository();
                ResenyaCEN resenyacen = new ResenyaCEN(resenyarepository);
                ValoracionRepository valoracionrepository = new ValoracionRepository();
                ValoracionCEN valoracioncen = new ValoracionCEN(valoracionrepository);
                EmpresaRepository empresarepository = new EmpresaRepository();
                EmpresaCEN empresacen = new EmpresaCEN(empresarepository);
                IndividuoRepository individuorepository = new IndividuoRepository();
                IndividuoCEN individuocen = new IndividuoCEN(individuorepository);
                VideojuegoRepository videojuegorepository = new VideojuegoRepository();
                VideojuegoCEN videojuegocen = new VideojuegoCEN(videojuegorepository);
                InteraccionRepository interaccionrepository = new InteraccionRepository();
                InteraccionCEN interaccioncen = new InteraccionCEN(interaccionrepository);



                /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/


                int reg1 = registradocen.New_("jorge", "jpb80@gmail.com", "deevo", false, false, "wdefrgs");
                RegistradoCEN registradoCEN = new RegistradoCEN(registradorepository);
                registradoCEN.Aceptar_mentoria(reg1);
                RegistradoEN registradoEN = registradocen.GetByOID(reg1);

                Console.WriteLine("Es mentor: " + registradoEN.Es_mentor);

                int lista = listacen.New_("juegos favs", "mi lista de juegos favs", false, reg1);
                ListaEN listaEN = listacen.GetByOID(lista);

                Console.WriteLine("Lista: " + listaEN.Nombre);
                Console.WriteLine("Lista: " + listaEN.Descripcion);
                Console.WriteLine("Lista: " + registradoCEN.GetByOID(listaEN.Autor_lista.Id).Nombre);

                listacen.Cambiar_descripcion(lista, "David, curra");
                listaEN = listacen.GetByOID(lista);
                Console.WriteLine("Lista: " + listaEN.Descripcion);

                int videojuego1 = videojuegocen.New_("The Last of Us", "Zombies", 0, GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.GenerosEnum.Accion);
                VideojuegoEN lastOfUs = videojuegocen.GetByoID(videojuego1);
                Console.WriteLine("Videojuego nombre: " + lastOfUs.Nombre);

                listacen.AnyadirJuego(lista, videojuego1);

                registradoEN = registradocen.GetByOID(reg1);

                Console.WriteLine("Lista jorge: ", registradoEN.Listas[0].Nombre);

                /*PROTECTED REGION END*/
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.InnerException);
                throw;
            }
        }
    }
}
