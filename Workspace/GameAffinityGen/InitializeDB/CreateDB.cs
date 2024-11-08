
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

                //Creacion de Registrado y prueba de Aceptar_Mentoria
                int jorgeID = registradocen.New_("jorge", "jpb80@gmail.com", "deevo", false, false, "wdefrgs");
                registradocen.Aceptar_mentoria(jorgeID);
                RegistradoEN jorge = registradocen.GetByOID(jorgeID);
                Console.WriteLine("Es mentor: " + jorge.Es_mentor);

                //Prueba de Cambio de Contraseña
                Console.WriteLine("Contraseña antes de cambiar: " + jorge.Contrasenya);
                registradocen.Cambiar_password(jorge.Id, "ElNano33");
                jorge = registradocen.GetByOID(jorgeID);
                Console.WriteLine("Contraseña cambiada: " + jorge.Contrasenya);

                //Crea una Lista de juegos para Jorge y Comprueba sus campos
                int juegosFavsJorgeID = listacen.New_("juegos favs", "mi lista de juegos favs", false, jorgeID);
                ListaEN juegosFavsJorge = listacen.GetByOID(juegosFavsJorgeID);
                Console.WriteLine("Lista: " + juegosFavsJorge.Nombre);
                Console.WriteLine("Lista: " + juegosFavsJorge.Descripcion);
                Console.WriteLine("Lista: " + registradocen.GetByOID(juegosFavsJorge.Autor_lista.Id).Nombre);

                //Prueba de Cambiar_descripcion de la Lista
                listacen.Cambiar_descripcion(juegosFavsJorgeID, "David, curra");
                juegosFavsJorge = listacen.GetByOID(juegosFavsJorgeID);
                Console.WriteLine("Lista: " + juegosFavsJorge.Descripcion);

                //Crea un Videojuego y le añade una Reseña del usuario Jorge, y la muestra por Pantalla
                int tlouID = videojuegocen.New_("TLOU", "Zombies", 0, GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.GenerosEnum.Accion);
                int resenyatlouID = resenyacen.New_("Bombastico", "Es un juego excelente", 0, 0, jorgeID, tlouID);
                ResenyaEN resenyatlou = resenyacen.GetByOID(resenyatlouID);
                Console.WriteLine("resenyatlou: " + resenyatlou.Titulo);

                //Prueba del Alternar_notificaciones
                Console.WriteLine("Notis: " + jorge.Notificaciones);
                registradocen.Alternar_notificaciones(jorgeID);
                jorge = registradocen.GetByOID(jorgeID);
                Console.WriteLine("Notis: " + jorge.Notificaciones);

                //Prueba el Cambiar_Nombre de Lista
                listacen.Cambiar_nombre(juegosFavsJorgeID, "Peores juegos");
                juegosFavsJorge = listacen.GetByOID(juegosFavsJorgeID);
                Console.WriteLine("JUEGOS FAV JORGE NOMBRE CAMBIADO: " + juegosFavsJorge.Nombre);

                //Prueba el Dar de Baja con el usuario Jorge
                registradocen.Dar_de_baja(jorgeID);
                jorge = registradocen.GetByOID(jorgeID);
                Console.WriteLine(jorge.Nombre + "\n" + jorge.Email);

                //Prueba añadir una valoracion del usuario Jorge a un Juego
                ValoracionCP valoracionCP = new ValoracionCP(new SessionCPNHibernate());
                VideojuegoEN tlouGame = videojuegocen.GetByoID(tlouID);
                Console.WriteLine(tlouGame.Nombre);
                Console.WriteLine("TLOU ANTES DE JORGE: " + tlouGame.Nota_media.ToString());
                ValoracionEN valoracionTlouJorge = valoracionCP.New_(10, jorgeID, tlouID);
                valoracionTlouJorge = valoracioncen.get_IValoracionRepository().GetByOID(valoracionTlouJorge.Id);
                tlouGame = videojuegocen.GetByoID(tlouID);
                Console.WriteLine("TLOU DESPUES DE JORGE: " + tlouGame.Nota_media.ToString());

                //Prueba el cambio de Valoracion
                Console.WriteLine("VALORACION TLOU ID: " + valoracionTlouJorge.Id);
                valoracionCP.Modify(valoracionTlouJorge.Id, 5);
                tlouGame = videojuegocen.GetByoID(tlouID);
                Console.WriteLine("TLOU DESPUES DE MODIFICAR: " + tlouGame.Nota_media.ToString());

                //Prueba el eliminar una Valoracion
                valoracionCP.Destroy(valoracionTlouJorge.Id);
                tlouGame = videojuegocen.GetByoID(tlouID);
                Console.WriteLine("TLOU DESPUES DE DESTRUIR: " + tlouGame.Nota_media.ToString());

                //Prueba el añadir una interaccion a una Reseña
                InteraccionCP interaccionCP = new InteraccionCP(new SessionCPNHibernate());
                InteraccionEN inter1 = interaccionCP.New_(jorgeID, true, false, resenyatlouID, resenyatlouID);
                RegistradoEN autorResenya = registradocen.GetByOID(inter1.Autor.Id);
                resenyatlou = resenyacen.GetByOID(resenyatlouID);
                Console.WriteLine("RESENYA TLOU LIKES: " + resenyatlou.Likes_contador);
                Console.WriteLine("RESENYA TLOU DISLIKES: " + resenyatlou.Dislikes_contador);

                //Modifica el dislike, poniendo un like, y lo prueba
                interaccionCP.Modify(inter1.Id, false, true, inter1.Id_resenya);
                resenyatlou = resenyacen.GetByOID(resenyatlouID);
                Console.WriteLine("RESENYA TLOU MODIF LIKES: " + resenyatlou.Likes_contador);
                Console.WriteLine("RESENYA TLOU MODIF DISLIKES: " + resenyatlou.Dislikes_contador);

                //Destruye la interaccion
                interaccionCP.Destroy(inter1.Id);
                resenyatlou = resenyacen.GetByOID(resenyatlouID);
                Console.WriteLine("RESENYA TLOU MODIF LIKES: " + resenyatlou.Likes_contador);
                Console.WriteLine("RESENYA TLOU MODIF DISLIKES: " + resenyatlou.Dislikes_contador);



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
