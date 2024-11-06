
using System;
using System.Text;

using System.Collections.Generic;
using GameAffinityGen.ApplicationCore.Exceptions;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;
using GameAffinityGen.ApplicationCore.CEN.GameAffinity;



/*PROTECTED REGION ID(usingGameAffinityGen.ApplicationCore.CP.GameAffinity_Like_destroy) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace GameAffinityGen.ApplicationCore.CP.GameAffinity
{
public partial class LikeCP : GenericBasicCP
{
public void Destroy (int p_Like_OID)
{
        /*PROTECTED REGION ID(GameAffinityGen.ApplicationCore.CP.GameAffinity_Like_destroy) ENABLED START*/

        LikeCEN likeCEN = null;

        try
        {
                CPSession.SessionInitializeTransaction ();
                likeCEN = new LikeCEN (CPSession.UnitRepo.LikeRepository);
                ResenyaCEN resenyaCEN = new ResenyaCEN (CPSession.UnitRepo.ResenyaRepository);

                LikeEN like = CPSession.UnitRepo.LikeRepository.ReadOIDDefault (p_Like_OID);
                ResenyaEN re = CPSession.UnitRepo.ResenyaRepository.ReadOIDDefault (like.Id_resenya);

                if (like.Disliked) {
                        re.Dislikes_contador--;
                }
                else if (like.Liked) {
                        re.Likes_contador--;
                }

                likeCEN.get_ILikeRepository ().Destroy (p_Like_OID);

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
