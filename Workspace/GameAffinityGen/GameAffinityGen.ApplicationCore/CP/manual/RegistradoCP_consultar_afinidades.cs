
using System;
using System.Text;

using System.Collections.Generic;
using GameAffinityGen.ApplicationCore.Exceptions;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;
using GameAffinityGen.ApplicationCore.CEN.GameAffinity;



/*PROTECTED REGION ID(usingGameAffinityGen.ApplicationCore.CP.GameAffinity_Registrado_consultar_afinidades) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace GameAffinityGen.ApplicationCore.CP.GameAffinity
{
public partial class RegistradoCP : GenericBasicCP
{
public int Consultar_afinidades (int p_oid, int user_ID)
{
        /*PROTECTED REGION ID(GameAffinityGen.ApplicationCore.CP.GameAffinity_Registrado_consultar_afinidades) ENABLED START*/

        int afinidad = 0;

        try
        {
                CPSession.SessionInitializeTransaction ();

                RegistradoCEN registradoCEN = new RegistradoCEN (CPSession.UnitRepo.RegistradoRepository);
                ValoracionCEN valoracionCEN = new ValoracionCEN (CPSession.UnitRepo.ValoracionRepository);
                VideojuegoCEN videojuegoCEN = new VideojuegoCEN (CPSession.UnitRepo.VideojuegoRepository);

                IList<ValoracionEN> misValoraciones = valoracionCEN.get_IValoracionRepository ().DameValoracionesUsu (p_oid);
                IList<ValoracionEN> susValoraciones = valoracionCEN.get_IValoracionRepository ().DameValoracionesUsu (user_ID);

                Console.WriteLine ("misValoraciones: " + misValoraciones.Count);
                Console.WriteLine ("susValoraciones: " + susValoraciones.Count);

                //creo la variable coincidence que es in int en el que contare las coincidencias
                var coincidencias = 0;
                //dos for eachs, uno dentro de otro, en cada for, hago resenya.juego y comparo la cadena con todas las resenya.juego del otro usuario (metiendo un for en otro for). Por cada coincidencia sumo 1 a la var coincidence
                foreach (var miValoracion in misValoraciones) {
                        foreach (var suValoracion in susValoraciones) {
                                // Comparo los nombres de los juegos en ambas rese�as
                                VideojuegoEN miVideojuego = videojuegoCEN.GetByoID (miValoracion.Videojuego_valorado.Id);
                                VideojuegoEN suVideojuego = videojuegoCEN.GetByoID (suValoracion.Videojuego_valorado.Id);

                                if (miVideojuego.Id == suVideojuego.Id) {
                                        Console.WriteLine (miVideojuego.Nombre + " | " + suVideojuego.Nombre);
                                        coincidencias++;
                                }
                        }
                }

                // Write here your custom transaction ...

                //creo var afinidad (int), y divido el numero de resenyas que tengo entre el numero de coincidencias con mi colega, el valor que obtenga es la afinidad
                float afinidadFloat = 0;

                if (coincidencias != 0) {
                        Console.WriteLine ("HA HABIDO COINCIDENCIAS!!");
                        afinidadFloat = ((float)coincidencias / (float)misValoraciones.Count) * 100;
                        afinidad = (int)afinidadFloat;
                }


                Console.WriteLine ("COINCIDENCIAS: " + coincidencias);
                Console.WriteLine ("misValoraciones.Count: " + misValoraciones.Count);
                Console.WriteLine ("afinidad: " + afinidad);
                Console.WriteLine ("afinidadFloat: " + afinidadFloat);

                CPSession.Commit ();
        }
        catch (Exception ex)
        {
                CPSession.RollBack ();
                throw ex;
        }
        finally
        {
                CPSession.SessionClose ();
        }
        return afinidad;

        /*PROTECTED REGION END*/
}
}
}
