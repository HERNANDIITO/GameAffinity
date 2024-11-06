
using System;
using System.Text;

using System.Collections.Generic;
using GameAffinityGen.ApplicationCore.Exceptions;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;
using GameAffinityGen.ApplicationCore.CEN.GameAffinity;



/*PROTECTED REGION ID(usingGameAffinityGen.ApplicationCore.CP.GameAffinity_Like_modify) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace GameAffinityGen.ApplicationCore.CP.GameAffinity
{
public partial class LikeCP : GenericBasicCP
{
public void Modify (int p_Like_OID, bool p_disliked, bool p_liked, int p_id_resenya)
{
        /*PROTECTED REGION ID(GameAffinityGen.ApplicationCore.CP.GameAffinity_Like_modify) ENABLED START*/

        LikeCEN likeCEN = null;



        try
        {
                CPSession.SessionInitializeTransaction ();
                likeCEN = new LikeCEN (CPSession.UnitRepo.LikeRepository);
                ResenyaCEN resenyaCEN = new ResenyaCEN (CPSession.UnitRepo.ResenyaRepository);

                //Initialized LikeEN
                LikeEN likeEN = likeCEN.get_ILikeRepository ().ReadOID (p_Like_OID);
                ResenyaEN re = resenyaCEN.get_IResenyaRepository ().ReadOIDDefault (p_id_resenya);

                if (likeEN.Liked) {
                        re.Likes--;
                }
                else if (likeEN.Disliked) {
                        re.Dislikes--;
                }

                likeEN.Id = p_Like_OID;
                likeEN.Disliked = p_disliked;
                likeEN.Liked = p_liked;
                likeEN.Id_resenya = p_id_resenya;
                likeCEN.get_ILikeRepository ().Modify (likeEN);

                if (likeEN.Liked) {
                        re.Likes++;
                }
                else if (likeEN.Disliked) {
                        re.Dislikes++;
                }

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
