
using System;
using System.Text;

using System.Collections.Generic;
using GameAffinityGen.ApplicationCore.Exceptions;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;
using GameAffinityGen.ApplicationCore.CEN.GameAffinity;



/*PROTECTED REGION ID(usingGameAffinityGen.ApplicationCore.CP.GameAffinity_Valoracion_destroy) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace GameAffinityGen.ApplicationCore.CP.GameAffinity
{
public partial class ValoracionCP : GenericBasicCP
{
public void Destroy (int p_Valoracion_OID)
{
        /*PROTECTED REGION ID(GameAffinityGen.ApplicationCore.CP.GameAffinity_Valoracion_destroy) ENABLED START*/

        try
        {
                CPSession.SessionInitializeTransaction ();
                ValoracionCEN valoracionCEN = new ValoracionCEN (CPSession.UnitRepo.ValoracionRepository);
                VideojuegoCEN videojuegoCEN = new VideojuegoCEN (CPSession.UnitRepo.VideojuegoRepository);

                Console.WriteLine ("VALORACION DESTROY ID: " + p_Valoracion_OID);
                ValoracionEN valoracionEN = valoracionCEN.GetByOID (p_Valoracion_OID);
                VideojuegoEN videojuego = videojuegoCEN.GetByoID (valoracionEN.Videojuego_valorado.Id);

                // Recalculamos la nota media
                int notaMedia = 0;
                IList<ValoracionEN> listaValoraciones = valoracionCEN.DameValoracionesJuego (videojuego.Id);
                listaValoraciones.Remove (valoracionEN);

                foreach (ValoracionEN videojuego_valoracion in listaValoraciones) {
                        notaMedia += videojuego_valoracion.Nota;
                }

                if (videojuego.Valoracion.Count > 0) {
                        notaMedia = notaMedia / videojuego.Valoracion.Count;
                }
                else{
                        notaMedia = 0;
                }

                //Sobreescribimos la nota media
                videojuego.Nota_media = notaMedia;

                //Sobreescribimos la nota media
                videojuego.Nota_media = notaMedia;

                //Aplicamos cambios
                videojuegoCEN.get_IVideojuegoRepository ().ModifyDefault (videojuego);
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
