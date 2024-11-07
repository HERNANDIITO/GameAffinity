
using System;
using System.Text;

using System.Collections.Generic;
using GameAffinityGen.ApplicationCore.Exceptions;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;
using GameAffinityGen.ApplicationCore.CEN.GameAffinity;



/*PROTECTED REGION ID(usingGameAffinityGen.ApplicationCore.CP.GameAffinity_Interaccion_destroy) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace GameAffinityGen.ApplicationCore.CP.GameAffinity
{
public partial class InteraccionCP : GenericBasicCP
{
public void Destroy (int p_Interaccion_OID)
{
        /*PROTECTED REGION ID(GameAffinityGen.ApplicationCore.CP.GameAffinity_Interaccion_destroy) ENABLED START*/

        InteraccionCEN interaccionCEN = null;
        ResenyaCEN resenyaCEN = null;


        try
        {
                CPSession.SessionInitializeTransaction ();
                interaccionCEN = new  InteraccionCEN (CPSession.UnitRepo.InteraccionRepository);
                resenyaCEN = new ResenyaCEN (CPSession.UnitRepo.ResenyaRepository);

                InteraccionEN interaccion = interaccionCEN.GetByOID (p_Interaccion_OID);
                if (interaccion.Disliked) {
                        interaccion.Resenya.Dislikes_contador--;
                }
                else if (interaccion.Liked) {
                        interaccion.Resenya.Likes_contador--;
                }

                resenyaCEN.get_IResenyaRepository ().Modify (interaccion.Resenya);
                interaccionCEN.get_IInteraccionRepository ().Destroy (p_Interaccion_OID);


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
