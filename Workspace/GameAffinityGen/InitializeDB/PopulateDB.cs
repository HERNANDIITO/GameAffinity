using System;
using System.Collections.Generic;
using GameAffinityGen.ApplicationCore.CEN.GameAffinity;
using GameAffinityGen.ApplicationCore.CP.GameAffinity;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.Enumerated.GameAffinity;
using GameAffinityGen.Infraestructure.CP;
using GameAffinityGen.Infraestructure.EN.GameAffinity;
using GameAffinityGen.Infraestructure.Repository.GameAffinity;

namespace PopulateDB
{
    public class PopulateDatabase
    {
        public static void populateDB()
        {
            try
            {

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("PUPLANDO DB!!!!!");
                Console.ResetColor();
                // Repositorios y CENs inicializados
                RegistradoRepository registradoRepo = new RegistradoRepository();
                RegistradoCEN registradoCEN = new RegistradoCEN(registradoRepo);
                EmpresaRepository empresaRepo = new EmpresaRepository();
                EmpresaCEN empresaCEN = new EmpresaCEN(empresaRepo);
                VideojuegoRepository videojuegoRepo = new VideojuegoRepository();
                VideojuegoCEN videojuegoCEN = new VideojuegoCEN(videojuegoRepo);
                ListaRepository listaRepo = new ListaRepository();
                ListaCEN listaCEN = new ListaCEN(listaRepo);
                ResenyaRepository resenyaRepo = new ResenyaRepository();
                ResenyaCEN resenyaCEN = new ResenyaCEN(resenyaRepo);

                IndividuoRepository individuoRepo = new IndividuoRepository();
                IndividuoCEN individuoCEN = new IndividuoCEN(individuoRepo);

                ValoracionCP valoracionCP = new ValoracionCP( new SessionCPNHibernate() );

                RegistradoCP registradoCP = new RegistradoCP(new SessionCPNHibernate());

                Random random = new Random();

                // Crear 10 empresas con descripciones reales
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("CREANDO EMPRESAS");
                Console.ResetColor();
                var empresas = new List<int>();
                empresas.Add(empresaCEN.New_("Nintendo", "Desarrolladora japonesa de videojuegos", 0, ""));
                empresas.Add(empresaCEN.New_("Sony", "Desarrolladora de PlayStation y videojuegos AAA", 0, ""));
                empresas.Add(empresaCEN.New_("Microsoft", "Famosa por Xbox y Halo", 0, ""));
                empresas.Add(empresaCEN.New_("Ubisoft", "Conocida por Assassin's Creed y Far Cry", 0, ""));
                empresas.Add(empresaCEN.New_("Electronic Arts", "Famosa por FIFA y Apex Legends", 0, ""));
                empresas.Add(empresaCEN.New_("Square Enix", "Creadores de Final Fantasy y Tomb Raider", 0, ""));
                empresas.Add(empresaCEN.New_("Activision Blizzard", "Famosa por Call of Duty y WoW", 0, ""));
                empresas.Add(empresaCEN.New_("Rockstar Games", "Creadores de GTA y Red Dead Redemption", 0, ""));
                empresas.Add(empresaCEN.New_("Capcom", "Conocidos por Resident Evil y Street Fighter", 0, ""));
                empresas.Add(empresaCEN.New_("Bethesda", "Creadora de Skyrim y Fallout", 0, ""));




                // Crear individuos con datos reales
                Random randomNumber = new Random();

                PaisesRepository paisRep = new PaisesRepository();
                PaisesCEN paisCEN = new PaisesCEN(paisRep);

                IList<PaisesEN > paisEN = paisCEN.ReadAll(0, 90);
                

                var individuos = new List<int>();
                var rialsIndividuos = new List<(string Nombre, string Apellido, DateTime FechaNacimiento, GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.RolesEnum Rol, string bio, string fotikoNene, int nasion)>
                {
                    ("Hideo", "Kojima", new DateTime(1960, 02, 18), GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.RolesEnum.Ilustrador, "Panoli", "", paisEN[randomNumber.Next(1, 90)].Id),
                    ("Yoko", "Shimomura", new DateTime(1967, 10, 19), GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.RolesEnum.Musico, "MusicoYoko", "", paisEN[randomNumber.Next(1, 90)].Id),
                    ("John", "Carmack", new DateTime(1970, 08, 20), GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.RolesEnum.Programador, "Carmack123", "", paisEN[randomNumber.Next(1, 90)].Id),
                    ("Shigeru", "Miyamoto", new DateTime(1952, 11, 16), GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.RolesEnum.Director, "MiyamotoShigeru", "", paisEN[randomNumber.Next(1, 90)].Id),
                    ("Koji", "Kondo", new DateTime(1961, 08, 13), GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.RolesEnum.Musico, "KondoKoji", "", paisEN[randomNumber.Next(1, 90)].Id),
                    ("Tetsuya", "Nomura", new DateTime(1970, 10, 08), GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.RolesEnum.Ilustrador, "NomuraTetsuya", "", paisEN[randomNumber.Next(1, 90)].Id),
                    ("Ken", "Levine", new DateTime(1966, 09, 06), GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.RolesEnum.Director, "LevineKen", "", paisEN[randomNumber.Next(1, 90)].Id),
                    ("Toby", "Fox", new DateTime(1983, 10, 11), GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.RolesEnum.Musico, "TobyFoxMusic", "", paisEN[randomNumber.Next(1, 90)].Id),
                    ("Markus", "Persson", new DateTime(1979, 06, 01), GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.RolesEnum.Programador, "Notch", "", paisEN[randomNumber.Next(1, 90)].Id),
                    ("Hideki", "Kamiya", new DateTime(1970, 12, 28), GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.RolesEnum.Director, "KamiyaHideki", "", paisEN[randomNumber.Next(1, 90)].Id),
                    ("Fumito", "Ueda", new DateTime(1968, 12, 09), GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.RolesEnum.Ilustrador, "UedaFumito", "", paisEN[randomNumber.Next(1, 90)].Id),
                    ("Gustavo", "Santaolalla", new DateTime(1951, 08, 19), GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.RolesEnum.Musico, "GustavoSanta", "", paisEN[randomNumber.Next(1, 90)].Id),
                    ("Jason", "Jones", new DateTime(1971, 09, 13), GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.RolesEnum.Programador, "BungieJason", "", paisEN[randomNumber.Next(1, 90)].Id),
                    ("Naoto", "Ohshima", new DateTime(1966, 02, 02), GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.RolesEnum.Ilustrador, "OhshimaNaoto", "", paisEN[randomNumber.Next(1, 90)].Id),
                    ("Yusuke", "Naora", new DateTime(1971, 05, 12), GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.RolesEnum.Ilustrador, "NaoraYusuke", "", paisEN[randomNumber.Next(1, 90)].Id),
                    ("Akira", "Yamaoka", new DateTime(1968, 02, 06), GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.RolesEnum.Musico, "YamaokaAkira", "", paisEN[randomNumber.Next(1, 90)].Id),
                    ("Satoshi", "Takahashi", new DateTime(1980, 01, 30), GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.RolesEnum.Programador, "TakahashiSatoshi", "", paisEN[randomNumber.Next(1, 90)].Id),
                    ("Kazunori", "Yamauchi", new DateTime(1967, 08, 05), GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.RolesEnum.Director, "YamauchiKazunori", "", paisEN[randomNumber.Next(1, 90)].Id),
                    ("Yuji", "Naka", new DateTime(1965, 09, 17), GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.RolesEnum.Programador, "YujiNaka", "", paisEN[randomNumber.Next(1, 90)].Id),
                    ("Ryuji", "Ikeda", new DateTime(1975, 03, 12), GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.RolesEnum.Ilustrador, "IkedaRyuji", "", paisEN[randomNumber.Next(1, 90)].Id)
                };


                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("CREANDO INDIVIDUOS");
                Console.ResetColor();
                foreach (var individuo in rialsIndividuos)
                {
                    int empresaIndex = random.Next(0, empresas.Count - 1);
                    int indi = individuoCEN.New_(individuo.Nombre, individuo.Apellido, individuo.FechaNacimiento, individuo.Rol, individuo.bio, "", individuo.nasion);
                    individuos.Add(indi);

                    // Asociar individuo a una empresa
                    EmpresaEN empresaEN = empresaCEN.GetByOID(empresas[empresaIndex]);
                    IndividuoEN individuoEN = individuoCEN.GetByOID(indi);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("INDIVIDUO AÑADIDO: " + individuoEN.Nombre);
                    Console.ResetColor();

                    empresaCEN.AnyadirIndividuo(empresaEN.Id, new List<int> { individuoEN.Id });
                }




                // Crear videojuegos con datos reales
                var videojuegos = new List<int>();
                var juegosReales = new List<(string Titulo, string Descripcion, GenerosEnum Genero, int Nota, DateTime Fecha)>
                {
                    ("The Legend of Zelda: Breath of the Wild", "Juego de mundo abierto", GenerosEnum.Aventura, 0, new DateTime(2017, 3, 3)),
                    ("God of War", "Aventura mitológica", GenerosEnum.Accion, 0, new DateTime(2018, 4, 20)),
                    ("Halo Infinite", "Shooter futurista", GenerosEnum.Accion, 0, new DateTime(2021, 12, 8)),
                    ("FIFA 23", "Simulador de fútbol", GenerosEnum.Deportes, 0, new DateTime(2022, 9, 30)),
                    ("Assassin's Creed Valhalla", "Aventura vikinga", GenerosEnum.Aventura, 0, new DateTime(2020, 11, 10)),
                    ("Resident Evil 4", "Survival Horror", GenerosEnum.Terror, 0, new DateTime(2005, 1, 11)),
                    ("Final Fantasy VII Remake", "RPG épico", GenerosEnum.RPG, 0, new DateTime(2020, 4, 10)),
                    ("Call of Duty: Modern Warfare", "Shooter bélico", GenerosEnum.Accion, 0, new DateTime(2019, 10, 25)),
                    ("Red Dead Redemption 2", "Western de mundo abierto", GenerosEnum.Aventura, 0, new DateTime(2018, 10, 26)),
                    ("Minecraft", "Juego de construcción y exploración", GenerosEnum.Otros, 0, new DateTime(2011, 11, 18)),
                    ("Cyberpunk 2077", "Juego de rol futurista", GenerosEnum.RPG, 0, new DateTime(2020, 12, 10)),
                    ("Elden Ring", "Aventura en un mundo oscuro", GenerosEnum.Aventura, 0, new DateTime(2022, 2, 25)),
                    ("The Sims 4", "Simulación de vida", GenerosEnum.Simulacion, 0, new DateTime(2014, 9, 2)),
                    ("Overwatch 2", "Shooter multijugador", GenerosEnum.Accion, 0, new DateTime(2022, 10, 4)),
                    ("Fortnite", "Battle Royale", GenerosEnum.Accion, 0, new DateTime(2017, 7, 21)),
                    ("League of Legends", "MOBA competitivo", GenerosEnum.Estrategia, 0, new DateTime(2009, 10, 27)),
                    ("Hades", "Dungeon crawler basado en la mitología griega", GenerosEnum.Aventura, 0, new DateTime(2020, 9, 17)),
                    ("Stardew Valley", "Simulación de granja", GenerosEnum.Simulacion, 0, new DateTime(2016, 2, 26)),
                    ("Terraria", "Juego de exploración y construcción 2D", GenerosEnum.Otros, 0, new DateTime(2011, 5, 16)),
                    ("Dark Souls III", "Juego de rol y acción desafiante", GenerosEnum.RPG, 0, new DateTime(2016, 4, 12)),
                    ("Hyper Light Breaker", "Secuela de Hyper Light Drifter", GenerosEnum.RPG, 0, new DateTime(2025, 1, 15)),
                    ("Dynasty Warriors: Origins", "Entrega nueva de Dynasty Warriors", GenerosEnum.RPG, 0, new DateTime(2025, 1, 17)),
                    ("Animal Crossing: New Leaf", "El mejor videojuego del mundo, donde podrás conoces a paquito, el pato más guapo", GenerosEnum.Simulacion, 0, new DateTime(2012, 8, 11))
                };

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("CREANDO VIDEOJUEGOS");
                Console.ResetColor();
                foreach (var juego in juegosReales)
                {
                    int empresaIndex = random.Next(0, empresas.Count - 1);
                    int individuoIndex = random.Next(0, individuos.Count - 1);
                    int videojuego = videojuegoCEN.New_(juego.Titulo, juego.Descripcion, juego.Nota, juego.Genero, juego.Fecha, "");
                    videojuegos.Add(videojuego);

                    // Asociar juego a una empresa y a un individuo
                    EmpresaEN empresaEN = empresaCEN.GetByOID(empresas[empresaIndex]);
                    IndividuoEN indiEN = individuoCEN.GetByOID(individuos[individuoIndex]);
                    VideojuegoEN videojuegoEN = videojuegoCEN.GetByoID(videojuego);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("VIDEOJUEGO AÑADIDO: " + videojuegoEN.Nombre);
                    Console.ResetColor();

                    empresaCEN.AnyadirJuegoDesarrollado(empresaEN.Id, new List<int> { videojuegoEN.Id });
                    individuoCEN.AnyadirVideojuego(indiEN.Id, new List<int> { videojuegoEN.Id });
                }

                // Crear usuarios con datos realistas
                var usuarios = new List<RegistradoEN>();
                var nombresUsuarios = new List<(string Nombre, string Email, string Username)>
                {
                    ("Juan Pérez", "juan.perez@example.com", "juanperez"),
                    ("María Gómez", "maria.gomez@example.com", "mariagomez"),
                    ("Carlos Ruiz", "carlos.ruiz@example.com", "carlosruiz"),
                    ("Ana López", "ana.lopez@example.com", "analopez"),
                    ("Pedro Morales", "pedro.morales@example.com", "pedromorales"),
                    ("Lucía Fernández", "lucia.fernandez@example.com", "luciafernandez"),
                    ("Jorge Martínez", "jorge.martinez@example.com", "jorgemartinez"),
                    ("Laura Sánchez", "laura.sanchez@example.com", "laurasanchez"),
                    ("David Torres", "david.torres@example.com", "davidtorres"),
                    ("Sofía Ramírez", "sofia.ramirez@example.com", "sofiaramirez"),
                    ("Luis Ortega", "luis.ortega@example.com", "luisortega"),
                    ("Claudia Navarro", "claudia.navarro@example.com", "claudianavarro"),
                    ("Manuel Castro", "manuel.castro@example.com", "manuelcastro"),
                    ("Laura Saval", "laura.saval@example.com", "patataSuprema")
                };

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("CREANDO USUARIOS");
                Console.ResetColor();

                foreach (var usuario in nombresUsuarios)
                {
                    RegistradoEN reg = registradoCP.New_(usuario.Nombre, usuario.Email, usuario.Username, false, true, "contraseña", "");
                    usuarios.Add(reg);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("USUARIO REGISTRADO: " + reg.Nombre);
                    Console.ResetColor();

                    if ( random.Next(1, 20) >= 15 )
                    {
                        registradoCEN.Aceptar_mentoria(reg.Id);
                    }
                }

                RegistradoEN laura = registradoCEN.GetByEmail("laura.saval@example.com");

                registradoCEN.Aceptar_mentoria(laura.Id);

                int resenyaLaura = resenyaCEN.New_(
                    "Mi juego favorito",
                    "El mejor juego del mundo, me encanta",
                    0, 0, laura.Id, videojuegos[videojuegos.Count - 1]
                );

                valoracionCP.New_(10, laura.Id, videojuegos[videojuegos.Count - 1]);

                // Cada usuario escribe 10 reseñas para juegos aleatorios
                foreach (var usuario in usuarios)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("HACIENDO RESEÑAS DE: " + usuario.Nombre);
                    Console.ResetColor();

                    for (int j = 0; j < 10; j++)
                    {
                        int juegoID = videojuegos[random.Next(0, videojuegos.Count - 1)];

                        VideojuegoEN juego = videojuegoCEN.GetByoID(juegoID);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("JUEGO: " + juego.Nombre);
                        Console.ResetColor();

                        int resenya = resenyaCEN.New_(
                            "Reseña",
                            "Comentario del juego",
                            j, j, usuario.Id, juego.Id
                        );
                        ValoracionEN valoracion = valoracionCP.New_(random.Next(1, 10), usuario.Id, juego.Id);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("RESEÑA: " + resenya);
                        Console.WriteLine("VALORACION: " + valoracion.Id);
                        Console.ResetColor();


                    }
                }

                // Cada usuario crea entre 1 y 3 listas personalizadas con 5 juegos cada una
                foreach (var usuario in usuarios)
                {
                    int cantidadListas = random.Next(1, 4);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("CREANDO " + cantidadListas + " PARA: " + usuario.Nombre);
                    Console.ResetColor();

                    for (int k = 0; k < cantidadListas; k++)
                    {
                        string nombreLista = $"Lista {k + 1} de {usuario.Nombre}";
                        string descripcionLista = $"Descripción de la lista {k + 1} de {usuario.Nombre}";
                        string imagenLista = $"imagen_lista_{k + 1}.jpg";

                        var juegosEnLista = new List<int>();
                        int lista = listaCEN.New_(nombreLista, descripcionLista, false, usuario.Id, imagenLista);
                        ListaEN listaEN = listaCEN.GetByOID(lista);

                        while (juegosEnLista.Count < 5)
                        {
                            VideojuegoEN videojuego = videojuegoCEN.GetByoID(videojuegos[random.Next(videojuegos.Count)]);
                            juegosEnLista.Add(videojuego.Id);

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("AÑADIENDO: " + videojuego.Nombre + " A LISTA " + listaEN.Nombre);
                            Console.ResetColor();
                            
                        }
                        listaCEN.AnyadirVideojuego(lista, juegosEnLista);

                    }
                }

                // Cada usuario sigue entre 1 y 20 usuarios
                foreach (var usuario in usuarios)
                {
                    int cantidadSeguimientos = random.Next(1, usuarios.Count - 1);
                    List<int> seguidos = [];

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine( "LISTA DE SEGUIDOS DE: " + usuario.Nombre);
                    Console.ResetColor();

                    foreach ( var seguido in usuario.Seguidos )
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(seguido.Nombre);
                        Console.ResetColor();
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine( usuario.Nombre + " VA A SEGUIR A " + cantidadSeguimientos + " USUARIOS ");
                    Console.ResetColor();

                    while (seguidos.Count < cantidadSeguimientos)
                    {
                        int seguidoID = usuarios[random.Next(usuarios.Count)].Id;
                        RegistradoEN aSeguir = registradoCEN.GetByOID(seguidoID);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(usuario.Nombre + " VA A SEGUIR A " + aSeguir.Nombre);
                        Console.ResetColor();

                        if (aSeguir != null && aSeguir.Id != usuario.Id)
                        {
                            if ( !seguidos.Contains(seguidoID) )
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(aSeguir.Nombre + " AÑADIDO A LA LISTA DE SEGUIDOS ");
                                Console.ResetColor();
                                seguidos.Add(seguidoID);
                            }
                        }
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("IDs que sigue: " + usuario.Id);
                    Console.WriteLine("IDs a seguir: ");
                    Console.ResetColor();

                    foreach (var seguido in seguidos)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(seguido);
                        Console.ResetColor();
                    }

                    registradoCEN.Seguir_perfiles(usuario.Id, seguidos);
                }

                Console.WriteLine("Base de datos inicializada y poblada correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al poblar la base de datos: " + ex.Message);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine();
                Console.WriteLine(ex.InnerException);
                Console.WriteLine();
                Console.WriteLine(ex.Source);

                Console.ResetColor();
            }
        }
    }
}
