
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

        try
        {
                CPSession.SessionInitializeTransaction ();
                // CEN
                valoracionCEN = new  ValoracionCEN (CPSession.UnitRepo.ValoracionRepository);

                // EN
                valoracionEN = valoracionCEN.GetByOID(p_Valoracion_OID);

                // Cambio de nota
                valoracionEN.Nota = p_nota;
                valoracionCEN.get_IValoracionRepository().ModifyDefault(valoracionEN);

                //recalcular media del videojuego
                //videojuegoCEN = new VideojuegoCEN(valoracionEN.Videojuego_valorado);


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
