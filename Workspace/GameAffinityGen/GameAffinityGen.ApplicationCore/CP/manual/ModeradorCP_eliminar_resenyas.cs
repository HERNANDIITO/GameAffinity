
using System;
using System.Text;

using System.Collections.Generic;
using GameAffinityGen.ApplicationCore.Exceptions;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;
using GameAffinityGen.ApplicationCore.CEN.GameAffinity;



/*PROTECTED REGION ID(usingGameAffinityGen.ApplicationCore.CP.GameAffinity_Moderador_eliminar_resenyas) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace GameAffinityGen.ApplicationCore.CP.GameAffinity
{
public partial class ModeradorCP : GenericBasicCP
{
public void Eliminar_resenyas (int p_oid, int resenya_ID)
{
        /*PROTECTED REGION ID(GameAffinityGen.ApplicationCore.CP.GameAffinity_Moderador_eliminar_resenyas) ENABLED START*/

        ModeradorCEN moderadorCEN = null;



        try
        {
                CPSession.SessionInitializeTransaction ();
                moderadorCEN = new  ModeradorCEN (CPSession.UnitRepo.ModeradorRepository);



                // Write here your custom transaction ...

                throw new NotImplementedException ("Method Eliminar_resenyas() not yet implemented.");



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
