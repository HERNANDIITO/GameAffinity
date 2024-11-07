
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

                ValoracionEN valoracion = valoracionCEN.GetByOID (p_Valoracion_OID);
                VideojuegoEN videojuego = videojuegoCEN.GetByoID (valoracion.Videojuego_valorado.Id);

                // Eliminamos la valoracion de la lista
                videojuego.Valoracion.Remove (valoracion);

                // Recalculamos la nota media
                int notaMedia = 0;
                foreach (ValoracionEN videojuego_valoracion in videojuego.Valoracion) {
                        notaMedia += videojuego_valoracion.Nota;
                }

                notaMedia = notaMedia / videojuego.Valoracion.Count;

                // Sobreescribimos la nota media
                videojuego.Nota_media = notaMedia;

                // Aplicamos cambios
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
