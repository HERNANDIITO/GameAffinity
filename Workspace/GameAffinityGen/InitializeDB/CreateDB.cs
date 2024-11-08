
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
using GameAffinityGen.Infraestructure.EN.GameAffinity;
using NHibernate;
using Microsoft.Win32;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local)\sqlexpress; database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

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
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception)
        {
                throw;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        try
        {
                // Initialising  CENs
                RegistradoRepository registradorepository = new RegistradoRepository ();
                RegistradoCEN registradocen = new RegistradoCEN (registradorepository);
                ModeradorRepository moderadorrepository = new ModeradorRepository ();
                ModeradorCEN moderadorcen = new ModeradorCEN (moderadorrepository);
                ListaRepository listarepository = new ListaRepository ();
                ListaCEN listacen = new ListaCEN (listarepository);
                ResenyaRepository resenyarepository = new ResenyaRepository ();
                ResenyaCEN resenyacen = new ResenyaCEN (resenyarepository);
                ValoracionRepository valoracionrepository = new ValoracionRepository ();
                ValoracionCEN valoracioncen = new ValoracionCEN (valoracionrepository);
                EmpresaRepository empresarepository = new EmpresaRepository ();
                EmpresaCEN empresacen = new EmpresaCEN (empresarepository);
                IndividuoRepository individuorepository = new IndividuoRepository ();
                IndividuoCEN individuocen = new IndividuoCEN (individuorepository);
                VideojuegoRepository videojuegorepository = new VideojuegoRepository ();
                VideojuegoCEN videojuegocen = new VideojuegoCEN (videojuegorepository);
                InteraccionRepository interaccionrepository = new InteraccionRepository ();
                InteraccionCEN interaccioncen = new InteraccionCEN (interaccionrepository);



                /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/


                int jorgeID = registradocen.New_ ("jorge", "jpb80@gmail.com", "deevo", false, false, "wdefrgs");
                registradocen.Aceptar_mentoria (jorgeID);
                RegistradoEN jorge = registradocen.GetByOID (jorgeID);

                Console.WriteLine ("Es mentor: " + jorge.Es_mentor);

                int juegosFavsJorgeID = listacen.New_ ("juegos favs", "mi lista de juegos favs", false, jorgeID);
                ListaEN juegosFavsJorge = listacen.GetByOID (juegosFavsJorgeID);

                Console.WriteLine ("Lista: " + juegosFavsJorge.Nombre);
                Console.WriteLine ("Lista: " + juegosFavsJorge.Descripcion);
                Console.WriteLine ("Lista: " + registradocen.GetByOID (juegosFavsJorge.Autor_lista.Id).Nombre);

                listacen.Cambiar_descripcion (juegosFavsJorgeID, "David, curra");
                juegosFavsJorge = listacen.GetByOID (juegosFavsJorgeID);
                Console.WriteLine ("Lista: " + juegosFavsJorge.Descripcion);

                int tlouID = videojuegocen.New_ ("TLOU", "Zombies", 0, GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.GenerosEnum.Accion);

                int resenyatlouID = resenyacen.New_ ("Bombastico", "Es un juego excelente", 0, 0, jorgeID, tlouID);

                ResenyaEN resenyatlou = resenyacen.GetByOID (resenyatlouID);
                Console.WriteLine ("resenyatlou: " + resenyatlou.Titulo);

                // resenyacen.Destroy (resenyatlouID);

                // resenyatlou = resenyacen.GetByOID (resenyatlouID);
                // Console.WriteLine ("resenyatlou: " + resenyatlou);

                Console.WriteLine ("Notis: " + jorge.Notificaciones);
                registradocen.Alternar_notificaciones (jorgeID);
                jorge = registradocen.GetByOID (jorgeID);
                Console.WriteLine ("Notis: " + jorge.Notificaciones);

                Console.WriteLine ("Notis: " + jorge.Notificaciones);
                listacen.Cambiar_nombre (juegosFavsJorgeID, "Peores juegos");
                juegosFavsJorge = listacen.GetByOID (juegosFavsJorgeID);
                Console.WriteLine ("JUEGOS FAV JORGE NOMBRE CAMBIADO: " + juegosFavsJorge.Nombre);

                registradocen.Dar_de_baja (jorgeID);
                jorge = registradocen.GetByOID (jorgeID);

                Console.WriteLine (jorge.Nombre + "\n" + jorge.Email);

                ValoracionCP valoracionCP = new ValoracionCP (new SessionCPNHibernate ());




                VideojuegoEN tlouGame = videojuegocen.GetByoID (tlouID);

                Console.WriteLine (tlouGame.Nombre);
                Console.WriteLine ("tlou antes de jorge: " + tlouGame.Nota_media.ToString ());

                ValoracionEN valoracionTlouJorge = valoracionCP.New_ (10, jorgeID, tlouID);

                tlouGame = videojuegocen.GetByoID (tlouID);
                Console.WriteLine ("tlou despues de jorge: " + tlouGame.Nota_media.ToString ());

                //valoracionCP.Modify(valoracionTlouJorge.Id, 5);
                //tlouGame = videojuegocen.GetByoID(tlouID);
                //Console.WriteLine("tlou despues de modificar: " + tlouGame.Nota_media.ToString());

                InteraccionCP interaccionCP = new InteraccionCP (new SessionCPNHibernate ());
                InteraccionEN inter1 = interaccionCP.New_ (jorgeID, true, false, resenyatlouID, resenyatlouID);

                /*PROTECTED REGION END*/
        }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw;
        }
}
}
}
