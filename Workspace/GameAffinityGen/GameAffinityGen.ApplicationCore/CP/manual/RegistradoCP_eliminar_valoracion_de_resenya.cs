
using System;
using System.Text;

using System.Collections.Generic;
using GameAffinityGen.ApplicationCore.Exceptions;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;
using GameAffinityGen.ApplicationCore.CEN.GameAffinity;



/*PROTECTED REGION ID(usingGameAffinityGen.ApplicationCore.CP.GameAffinity_Registrado_eliminar_valoracion_de_resenya) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace GameAffinityGen.ApplicationCore.CP.GameAffinity
{
public partial class RegistradoCP : GenericBasicCP
{
public void Eliminar_valoracion_de_resenya (int p_oid, int resenya_ID)
{
        /*PROTECTED REGION ID(GameAffinityGen.ApplicationCore.CP.GameAffinity_Registrado_eliminar_valoracion_de_resenya) ENABLED START*/

        RegistradoCEN registradoCEN = null;



        try
        {
                CPSession.SessionInitializeTransaction ();

                // Write here your custom transaction ...

                throw new NotImplementedException ("Method Eliminar_valoracion_de_resenya() not yet implemented.");



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
