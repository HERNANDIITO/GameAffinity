
using System;
using System.Text;

using System.Collections.Generic;
using GameAffinityGen.ApplicationCore.Exceptions;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;
using GameAffinityGen.ApplicationCore.CEN.GameAffinity;



/*PROTECTED REGION ID(usingGameAffinityGen.ApplicationCore.CP.GameAffinity_Interaccion_modify) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace GameAffinityGen.ApplicationCore.CP.GameAffinity
{
public partial class InteraccionCP : GenericBasicCP
{
public void Modify (int p_Interaccion_OID, bool p_disliked, bool p_liked, int p_id_resenya)
{
        /*PROTECTED REGION ID(GameAffinityGen.ApplicationCore.CP.GameAffinity_Interaccion_modify) ENABLED START*/

        InteraccionCEN interaccionCEN = null;



        try
        {
                CPSession.SessionInitializeTransaction ();
                interaccionCEN = new  InteraccionCEN (CPSession.UnitRepo.InteraccionRepository);




                InteraccionEN interaccionEN = null;
                //Initialized InteraccionEN
                interaccionEN = new InteraccionEN ();
                interaccionEN.Id = p_Interaccion_OID;
                interaccionEN.Disliked = p_disliked;
                interaccionEN.Liked = p_liked;
                interaccionEN.Id_resenya = p_id_resenya;
                interaccionCEN.get_IInteraccionRepository ().Modify (interaccionEN);


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
