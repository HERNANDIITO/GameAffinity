
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
                // CEN
                valoracionCEN = new  ValoracionCEN (CPSession.UnitRepo.ValoracionRepository);
                videojuegoCEN = new VideojuegoCEN(CPSession.UnitRepo.VideojuegoRepository);

                // EN
                valoracionEN = valoracionCEN.GetByOID(p_Valoracion_OID);
                videojuegoEN = videojuegoCEN.GetByoID(valoracionEN.Videojuego_valorado.Id);


                // Cambio de nota
                valoracionEN.Nota = p_nota;

                //recalcular media del videojuego
                int notaMedia = 0;
                foreach (ValoracionEN videojuego_valoracion in videojuegoEN.Valoracion)
                {
                    notaMedia += videojuego_valoracion.Nota;
                }

                notaMedia = notaMedia / videojuegoEN.Valoracion.Count;

                // Sobreescribimos la nota media
                videojuegoEN.Nota_media = notaMedia;

                // Aplicamos cambios
                valoracionCEN.get_IValoracionRepository().ModifyDefault(valoracionEN);
                videojuegoCEN.get_IVideojuegoRepository().ModifyDefault(videojuegoEN);




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
