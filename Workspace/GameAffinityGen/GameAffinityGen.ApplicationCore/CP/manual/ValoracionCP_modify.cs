
using System;
using System.Text;

using System.Collections.Generic;
using GameAffinityGen.ApplicationCore.Exceptions;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;
using GameAffinityGen.ApplicationCore.CEN.GameAffinity;



/*PROTECTED REGION ID(usingGameAffinityGen.ApplicationCore.CP.GameAffinity_Valoracion_modify) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace GameAffinityGen.ApplicationCore.CP.GameAffinity
{
public partial class ValoracionCP : GenericBasicCP
{
public void Modify (int p_Valoracion_OID, int p_nota)
{
        /*PROTECTED REGION ID(GameAffinityGen.ApplicationCore.CP.GameAffinity_Valoracion_modify) ENABLED START*/

        ValoracionCEN valoracionCEN = null;
        ValoracionEN valoracionEN = null;
        VideojuegoCEN videojuegoCEN = null;
        VideojuegoEN videojuegoEN = null;

        try
        {
                CPSession.SessionInitializeTransaction ();
                Console.WriteLine ("NOTA NOTA NOTA NOTA NOTA NOTA NOTA");
                // CEN
                valoracionCEN = new ValoracionCEN (CPSession.UnitRepo.ValoracionRepository);
                videojuegoCEN = new VideojuegoCEN (CPSession.UnitRepo.VideojuegoRepository);

                // EN
                Console.WriteLine ("NOTA NOTA NOTA NOTA NOTA NOTA NOTA ID valoracion: " + p_Valoracion_OID);
                valoracionEN = valoracionCEN.GetByOID (p_Valoracion_OID);
                Console.WriteLine ("NOTA NOTA NOTA NOTA NOTA NOTA NOTA ID JUEGO" + valoracionEN.Videojuego_valorado.Id);
                videojuegoEN = videojuegoCEN.GetByoID (valoracionEN.Videojuego_valorado.Id);
                Console.WriteLine ("NOTA NOTA NOTA NOTA NOTA NOTA NOTA");

                // Cambio de nota
                valoracionEN.Nota = p_nota;

                //recalcular media del videojuego
                int notaMedia = 0;
                Console.WriteLine ("NOTA NOTA NOTA NOTA NOTA NOTA NOTA");
                foreach (ValoracionEN videojuego_valoracion in videojuegoEN.Valoracion) {
                        Console.WriteLine ("NOTA NOTA NOTA NOTA NOTA NOTA NOTA" + videojuego_valoracion.Nota);
                        notaMedia += videojuego_valoracion.Nota;
                }

                notaMedia = notaMedia / videojuegoEN.Valoracion.Count;

                // Sobreescribimos la nota media
                videojuegoEN.Nota_media = notaMedia;

                // Aplicamos cambios
                videojuegoCEN.get_IVideojuegoRepository ().ModifyDefault (videojuegoEN);
                valoracionCEN.get_IValoracionRepository ().Destroy (p_Valoracion_OID);

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


        /*PROTECTED REGION END*/
}
}
}
