
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
                PaisesRepository paisesrepository = new PaisesRepository ();
                PaisesCEN paisescen = new PaisesCEN (paisesrepository);



                /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/

                //Creacion de Empresa
                int nintendoID = empresacen.New_("Nintendo", "Juego pa toa la famili", 10);
                int santamonicaID = empresacen.New_("Santa Monica", "Solo se nos conoce por el gow", 9);

                // Llamar al método pasándole el ID de la empresa y la lista de IDs de videojuegos


                //Creacion de Registrado y prueba de Aceptar_Mentoria

                int jorgeID = registradocen.New_ ("jorge", "jpb80@gmail.com", "deevo", false, true, "wdefrgsasadsa", "");
                registradocen.Aceptar_mentoria (jorgeID);
                RegistradoEN jorge = registradocen.GetByOID (jorgeID);

                Console.WriteLine("Es mentor: " + jorge.Es_mentor);

                //PRUEBA ANYADIR_JUEGO: Crea dos videojuegos, los a�ade a una lista y muestra la lista
                Console.WriteLine("\nPRUEBA ANYADIR_VIDEOJUEGO: ");
                int superMarioID = videojuegocen.New_(
                    "Super Mario",
                    "YAHOOOOO!!!",
                    10,
                    GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.GenerosEnum.Puzzles,
                    DateTime.Parse("06/04/2025"),
                    "");
                VideojuegoEN videojuegoMarioEn = videojuegocen.GetByoID(superMarioID);
                Console.WriteLine("VIDEOJUEGO SUPER MARIO: " + videojuegoMarioEn.Nombre + "\n");
                Console.WriteLine("ID DEL VIDEOJUEGO SUPER MARIO: " + videojuegoMarioEn.Id + "\n");

         
                int sonicID = videojuegocen.New_(
                    "Sonic Heroes",
                    "U're too slow.",
                    10,
                    GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.GenerosEnum.Accion,
                    DateTime.Parse("15/04/2012"),
                    "");
                VideojuegoEN sonicEN = videojuegocen.GetByoID(sonicID);
                Console.WriteLine("VIDEOJUEGO SONIC HEROES: " + sonicEN.Nombre + "\n");
                Console.WriteLine("ID DEL VIDEOJUEGO SONIC HEROES: " + sonicEN.Id + "\n");

                var videojuegoIDs = new List<int> { superMarioID };
                empresacen.AnyadirJuegoDesarrollado(nintendoID, videojuegoIDs);

                int silvaID = registradocen.New_("Silva", "silva@gmail.com", "laCalva", "arrikitaun");
                RegistradoEN silva = registradocen.GetByOID(jorgeID);

                ListaCEN listaSilvaCEN = new ListaCEN(listarepository);
                int listaJuegosSilvaID = listaSilvaCEN.New_("JUEGOS Y VAINAS", "Una lista rexulona bb", false, silvaID);
                ListaEN listaJuegosSilvaEN = listaSilvaCEN.GetByOID(listaJuegosSilvaID);

                Console.WriteLine("Lista: " + listaJuegosSilvaEN.Nombre + "\n");
                Console.WriteLine("Lista: " + listaJuegosSilvaEN.Descripcion + "\n");
                Console.WriteLine("Lista: " + registradocen.GetByOID(listaJuegosSilvaEN.Autor_lista.Id).Nombre + "\n");

                listaSilvaCEN.AnyadirVideojuego(listaJuegosSilvaID, new List<int> { sonicID, superMarioID });

                Console.WriteLine("\nLista despu�s de a�adir juegos: " + listaJuegosSilvaEN.Nombre + "\n");
                Console.WriteLine("Videojuegos en la lista:\n");
                using (var session = NHibernateHelper.OpenSession()) // Abre la sesi�n
                {
                    var listaJuegosSilva = session.Get<ListaEN>(listaJuegosSilvaID); // Obtienes el objeto ListaEN por su ID
                    session.Refresh(listaJuegosSilva); // Aseg�rate de cargar la colecci�n Videojuegos si est� perezosamente cargada
                                                       // Ahora puedes acceder a la colecci�n sin el error de LazyInitializationException
                    Console.WriteLine("\n\nN�mero de videojuegos en la lista: " + listaJuegosSilva.Videojuegos.Count);
                    // O recorrer la colecci�n
                    foreach (var videojuego in listaJuegosSilva.Videojuegos)
                    {
                        Console.WriteLine(videojuego.Nombre);
                    }
                }

                //PRUEBA ELIMINAR_JUEGO: Elimina un juego de la lista y luego muestra la lista por consola
                Console.WriteLine("\nPRUEBA ELIMINAR_JUEGO: ");

                listaSilvaCEN.EliminarJuego(listaJuegosSilvaID, new List<int> { sonicID });

                using (var session = NHibernateHelper.OpenSession()) // Abre la sesi�n
                {
                    var listaJuegosSilva = session.Get<ListaEN>(listaJuegosSilvaID); // Obtienes el objeto ListaEN por su ID
                    session.Refresh(listaJuegosSilva); // Aseg�rate de cargar la colecci�n Videojuegos si est� perezosamente cargada
                                                       // Ahora puedes acceder a la colecci�n sin el error de LazyInitializationException
                    Console.WriteLine("\n\nN�mero de videojuegos en la lista despu�s de eliminar uno: " + listaJuegosSilva.Videojuegos.Count);
                    // O recorrer la colecci�n
                    foreach (var videojuego in listaJuegosSilva.Videojuegos)
                    {
                        Console.WriteLine(videojuego.Nombre);
                    }
                }

                //PRUEBA RECUPERAR_PASSWORD: Recuperar contrase�a de Pablo
                Console.WriteLine ("\n\nPRUEBA RECUPERAR_PASSWORD");
                int pabloID = registradocen.New_ ("pablo", "pablo@example.com", "hernan", false, true, "pass123", "");
                RegistradoEN registradoEN3 = registradocen.GetByOID (pabloID);
                string passwordPablo = registradoEN3.Contrasenya.ToString ();
                Console.WriteLine ("CONTRASENYA PABLO: " + registradoEN3.Contrasenya + "\n");

                registradocen.Recuperar_password(pabloID);
                Console.WriteLine("CONTRASENYA PABLO RECUPERADA: " + registradoEN3.Contrasenya + "\n");

                //ESTE APARTADO ESTa HECHO POR SILVA

                //PRUEBA CONSULTAR_AFINIDADES: Comparar dos usuarios para saber afinidad
                Console.WriteLine("\n\nPRUEBA CONSULTAR_AFINIDADES: ");
                ///// Cargar usuarios y videojuegos
                int davidID = registradocen.New_ ("david", "david@example.com", "davidxx", false, true, "pass123", "");
                // A�adir videojuegos y rese�as, similar al c�digo que ya tienes
                int darkSoulsID = videojuegocen.New_(
                    "darkSouls",
                    "Aventura",
                    0,
                    GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.GenerosEnum.Accion,
                    DateTime.Parse("06/04/2020"),
                    "");

                int unchartedID = videojuegocen.New_(
                    "Uncharted",
                    "Aventura",
                    0,
                    GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.GenerosEnum.Accion,
                    DateTime.Parse("06/04/2025"),
                    "");

                int resenyaPablo = resenyacen.New_("Buen gameplay", "Rese�a del juego", 5, 1, pabloID, darkSoulsID);
                int resenyaDavidA = resenyacen.New_("Excelente jugabilidad", "Rese�a del juego", 4, 2, davidID, unchartedID);
                int resenyaDavidB = resenyacen.New_("Pedazo historia", "Rese�a del juego", 7, 2, davidID, darkSoulsID);

                //Prueba de Cambio de Contrase�a
                Console.WriteLine("Contrase�a antes de cambiar: " + jorge.Contrasenya);
                registradocen.Cambiar_password(jorge.Id, "ElNano33");
                jorge = registradocen.GetByOID(jorgeID);
                Console.WriteLine("Contrase�a cambiada: " + jorge.Contrasenya);

                //Crea una Lista de juegos para Jorge y Comprueba sus campos
                int juegosFavsJorgeID = listacen.New_ ("juegos favs", "mi lista de juegos favs", false, jorgeID, "");
                ListaEN juegosFavsJorge = listacen.GetByOID (juegosFavsJorgeID);
                Console.WriteLine ("Lista: " + juegosFavsJorge.Nombre);
                Console.WriteLine ("Lista: " + juegosFavsJorge.Descripcion);
                Console.WriteLine ("Lista: " + registradocen.GetByOID (juegosFavsJorge.Autor_lista.Id).Nombre);

                //Prueba de Cambiar_descripcion de la Lista
                listacen.Cambiar_descripcion(juegosFavsJorgeID, "Jorge, espabila");
                juegosFavsJorge = listacen.GetByOID(juegosFavsJorgeID);
                Console.WriteLine("Lista: " + juegosFavsJorge.Descripcion);

                //Crea un Videojuego y le a�ade una Rese�a del usuario Jorge, y la muestra por Pantalla
                int tlouID = videojuegocen.New_(
                    "TLOU",
                    "Zombies",
                    0,
                    GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.GenerosEnum.Accion,
                    DateTime.Parse("06/04/2013"),
                    "");
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

                //Prueba a�adir una valoracion del usuario Jorge a un Juego
                ValoracionCP valoracionCP = new ValoracionCP(new SessionCPNHibernate());
                VideojuegoEN tlouGame = videojuegocen.GetByoID(tlouID);
                Console.WriteLine(tlouGame.Nombre);
                Console.WriteLine("TLOU ANTES DE JORGE: " + tlouGame.Nota_media.ToString());
                ValoracionEN valoracionTlouJorge = valoracionCP.New_(10, jorgeID, tlouID);
                valoracionTlouJorge = valoracioncen.get_IValoracionRepository().GetByOID(valoracionTlouJorge.Id);
                tlouGame = videojuegocen.GetByoID(tlouID);
                Console.WriteLine("TLOU DESPUES DE JORGE: " + tlouGame.Nota_media.ToString());

                IList<ValoracionEN> valoracionesJorge = valoracioncen.DameValoracionesUsu(jorgeID);
                Console.WriteLine("VALORACIONES JORGE: " + valoracionesJorge.Count);

                //Prueba el cambio de Valoracion
                Console.WriteLine("VALORACION TLOU ID: " + valoracionTlouJorge.Id);
                valoracionCP.Modify(valoracionTlouJorge.Id, 5);
                tlouGame = videojuegocen.GetByoID(tlouID);
                Console.WriteLine("TLOU DESPUES DE MODIFICAR: " + tlouGame.Nota_media.ToString());

                //Prueba el eliminar una Valoracion
                valoracionCP.Destroy(valoracionTlouJorge.Id);
                tlouGame = videojuegocen.GetByoID(tlouID);
                Console.WriteLine("TLOU DESPUES DE DESTRUIR: " + tlouGame.Nota_media.ToString());

                //Prueba el a�adir una interaccion a una Rese�a
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

                // Abrimos una sesi�n de NHibernate
                RegistradoEN registradoPablo = registradocen.GetByOID(pabloID);

                // Consultar afinidades con la sesi�n abierta
                RegistradoCP registradoCP = new RegistradoCP(new SessionCPNHibernate());

                valoracionCP.New_(7, pabloID, tlouID);
                valoracionCP.New_(7, davidID, tlouID);

                valoracionCP.New_(7, pabloID, darkSoulsID);
                valoracionCP.New_(7, davidID, sonicID);

                IList<ValoracionEN> valoracionesPablo = valoracioncen.DameValoracionesUsu(pabloID);
                Console.WriteLine("VALORACIONES Pablo: \n");
                foreach (var valoracion in valoracionesPablo)
                {
                    VideojuegoEN juego = videojuegocen.GetByoID(valoracion.Videojuego_valorado.Id);
                    Console.WriteLine("TITULO: " + juego.Nombre + "\n" + "NOTA: " + valoracion.Nota);
                }

                IList<ValoracionEN> valoracionesDavid = valoracioncen.DameValoracionesUsu(davidID);
                Console.WriteLine("VALORACIONES David: \n");
                foreach (var valoracion in valoracionesDavid)
                {
                    VideojuegoEN juego = videojuegocen.GetByoID(valoracion.Videojuego_valorado.Id);
                    Console.WriteLine("TITULO: " + juego.Nombre + "\n" + "NOTA: " + valoracion.Nota);
                }

                int afinidad = registradoCP.Consultar_afinidades(pabloID, davidID);

                Console.WriteLine("\n\nAfinidad entre usuario Pablo y usuario David: " + afinidad);

                int idEspanya = paisescen.New_ ("España");

                // prueba creacion individuo
                int idHideo = individuocen.New_ (
                        "Hideo",
                        "Kojima",
                        new DateTime (1963, 08, 23),
                        GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.RolesEnum.Director,
                        "Es el legendario diseñador de videojuegos detrás de la saga Metal Gear y el videojuego Death Stranding. En 2016, durante la gala de The Game Awards, fue galardonado con el premio honorífico a ícono de la industria de los videojuegos.",
                        "",
                        idEspanya
                        );
                IndividuoEN Hideo = individuocen.GetByOID (idHideo);
                Console.WriteLine ("Este es Hideo Kojima: " + Hideo.Biografia);





                //creacion de listas por defecto y admin que las administra
                int adminID = registradocen.New_ ("Admin", "admin@gmail.com", "elAdmin", false, true, "1234", "");
                RegistradoEN admin = registradocen.GetByOID (adminID);

                int listaCompletados = listacen.New_ ("Juegos completados", "Juegos que el jugador ha completado", true, adminID, "");
                ListaEN completados = listacen.GetByOID (listaCompletados);

                int listaEnProgreso = listacen.New_ ("Juegos en progreso", "Juegos que el jugador esta jugando pero no ha completado todavia", true, adminID, "");
                ListaEN enProgreso = listacen.GetByOID (listaEnProgreso);

                int listaPendientes = listacen.New_ ("Juegos pendientes", "Juegos que el jugador quiere jugar pero no ha empezado", true, adminID, "");
                ListaEN pendientes = listacen.GetByOID (listaPendientes);


                // GENERACION DE PAISES

                int idEstadosUnidos = paisescen.New_("Estados Unidos");
                int idChina = paisescen.New_("China");
                int idIndia = paisescen.New_("India");
                int idAlemania = paisescen.New_("Alemania");
                int idReinoUnido = paisescen.New_("Reino Unido");
                int idFrancia = paisescen.New_("Francia");
                int idItalia = paisescen.New_("Italia");
                int idJapon = paisescen.New_("Japón");
                int idAustralia = paisescen.New_("Australia");
                int idCanada = paisescen.New_("Canadá");
                int idBrasil = paisescen.New_("Brasil");
                int idRusia = paisescen.New_("Rusia");
                int idCoreaDelSur = paisescen.New_("Corea del Sur");
                int idMexico = paisescen.New_("México");
                int idSudafrica = paisescen.New_("Sudáfrica");
                int idArgentina = paisescen.New_("Argentina");
                int idArabiaSaudita = paisescen.New_("Arabia Saudita");
                int idTurquia = paisescen.New_("Turquía");
                int idIndonesia = paisescen.New_("Indonesia");
                int idSuiza = paisescen.New_("Suiza");
                int idHolanda = paisescen.New_("Holanda");
                int idSuecia = paisescen.New_("Suecia");
                int idNoruega = paisescen.New_("Noruega");
                int idFinlandia = paisescen.New_("Finlandia");
                int idDinamarca = paisescen.New_("Dinamarca");
                int idBelgica = paisescen.New_("Bélgica");
                int idAustria = paisescen.New_("Austria");
                int idSingapur = paisescen.New_("Singapur");
                int idNuevaZelanda = paisescen.New_("Nueva Zelanda");
                int idMalasia = paisescen.New_("Malasia");
                int idTailandia = paisescen.New_("Tailandia");
                int idVietnam = paisescen.New_("Vietnam");
                int idFilipinas = paisescen.New_("Filipinas");
                int idBangladesh = paisescen.New_("Bangladesh");
                int idEgipto = paisescen.New_("Egipto");
                int idNigeria = paisescen.New_("Nigeria");
                int idKenya = paisescen.New_("Kenia");
                int idGhana = paisescen.New_("Ghana");
                int idColombia = paisescen.New_("Colombia");
                int idPeru = paisescen.New_("Perú");
                int idChile = paisescen.New_("Chile");
                int idVenezuela = paisescen.New_("Venezuela");
                int idPolonia = paisescen.New_("Polonia");
                int idUcrania = paisescen.New_("Ucrania");
                int idGrecia = paisescen.New_("Grecia");
                int idPortugal = paisescen.New_("Portugal");
                int idIrlanda = paisescen.New_("Irlanda");
                int idChequia = paisescen.New_("Chequia");
                int idHungria = paisescen.New_("Hungría");
                int idRumania = paisescen.New_("Rumania");
                int idEslovaquia = paisescen.New_("Eslovaquia");
                int idBulgaria = paisescen.New_("Bulgaria");
                int idCroacia = paisescen.New_("Croacia");
                int idEslovenia = paisescen.New_("Eslovenia");
                int idEstonia = paisescen.New_("Estonia");
                int idLetonia = paisescen.New_("Letonia");
                int idLituania = paisescen.New_("Lituania");
                int idIslandia = paisescen.New_("Islandia");
                int idLuxemburgo = paisescen.New_("Luxemburgo");
                int idMalta = paisescen.New_("Malta");
                int idChipre = paisescen.New_("Chipre");
                int idIsrael = paisescen.New_("Israel");
                int idJordania = paisescen.New_("Jordania");
                int idLibano = paisescen.New_("Líbano");
                int idIrak = paisescen.New_("Irak");
                int idIran = paisescen.New_("Irán");
                int idPakistán = paisescen.New_("Pakistán");
                int idAfganistan = paisescen.New_("Afganistán");
                int idKazajistan = paisescen.New_("Kazajistán");
                int idUzbekistan = paisescen.New_("Uzbekistán");
                int idTurkmenistan = paisescen.New_("Turkmenistán");
                int idKirguistan = paisescen.New_("Kirguistán");
                int idTayikistan = paisescen.New_("Tayikistán");
                int idMongolia = paisescen.New_("Mongolia");
                int idSriLanka = paisescen.New_("Sri Lanka");
                int idNepal = paisescen.New_("Nepal");
                int idBhutan = paisescen.New_("Bután");
                int idMaldivas = paisescen.New_("Maldivas");
                int idMyanmar = paisescen.New_("Myanmar");
                int idCamboya = paisescen.New_("Camboya");
                int idLaos = paisescen.New_("Laos");
                int idBrunei = paisescen.New_("Brunéi");
                int idTimorOriental = paisescen.New_("Timor Oriental");
                int idPapuaNuevaGuinea = paisescen.New_("Papúa Nueva Guinea");
                int idFiyi = paisescen.New_("Fiyi");
                int idSamoa = paisescen.New_("Samoa");
                int idTonga = paisescen.New_("Tonga");
                int idVanuatu = paisescen.New_("Vanuatu");
                int idMicronesia = paisescen.New_("Micronesia");
                int idPalau = paisescen.New_("Palaos");
                int idIslasSalomon = paisescen.New_("Islas Salomón");

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