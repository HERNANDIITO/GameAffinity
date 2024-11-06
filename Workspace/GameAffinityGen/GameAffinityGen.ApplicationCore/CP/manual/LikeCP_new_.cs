
using System;
using System.Text;

using System.Collections.Generic;
using GameAffinityGen.ApplicationCore.Exceptions;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;
using GameAffinityGen.ApplicationCore.CEN.GameAffinity;



/*PROTECTED REGION ID(usingGameAffinityGen.ApplicationCore.CP.GameAffinity_Like_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace GameAffinityGen.ApplicationCore.CP.GameAffinity
{
    public partial class LikeCP : GenericBasicCP
    {
        public GameAffinityGen.ApplicationCore.EN.GameAffinity.LikeEN New_(int p_autor, bool p_disliked, bool p_liked, int p_id_resenya, int p_resenya)
        {
            /*PROTECTED REGION ID(GameAffinityGen.ApplicationCore.CP.GameAffinity_Like_new_) ENABLED START*/

            LikeCEN likeCEN = null;

            GameAffinityGen.ApplicationCore.EN.GameAffinity.LikeEN result = null;


            try
            {
                CPSession.SessionInitializeTransaction();
                likeCEN = new LikeCEN(CPSession.UnitRepo.LikeRepository);

                int oid;
                //Initialized LikeEN
                LikeEN likeEN;
                likeEN = new LikeEN();

                if (p_autor != -1)
                {
                    likeEN.Autor = new GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN();
                    likeEN.Autor.Id = p_autor;
                }


                if (p_resenya != -1)
                {
                    likeEN.Resenya = new GameAffinityGen.ApplicationCore.EN.GameAffinity.ResenyaEN();
                    likeEN.Resenya.Id = p_resenya;
                }

                likeEN.Disliked = p_disliked;

                likeEN.Liked = p_liked; 

                likeEN.Id_resenya = p_id_resenya;

                ResenyaCEN resenyaCEN = new ResenyaCEN(CPSession.UnitRepo.ResenyaRepository);
                ResenyaEN re = resenyaCEN.get_IResenyaRepository().ReadOIDDefault(p_id_resenya);

                if (likeEN.Liked)
                {
                    re.Likes_contador++;
                }
                else if (likeEN.Disliked)
                {
                    re.Dislikes_contador++;
                }

                oid = likeCEN.get_ILikeRepository().New_(likeEN);
                result = likeCEN.get_ILikeRepository().ReadOIDDefault(oid);

                CPSession.Commit();
            }
            catch (Exception ex)
            {
                CPSession.RollBack();
                throw ex;
            }
            finally
            {
                CPSession.SessionClose();
            }
            return result;


            /*PROTECTED REGION END*/
        }
    }
}
