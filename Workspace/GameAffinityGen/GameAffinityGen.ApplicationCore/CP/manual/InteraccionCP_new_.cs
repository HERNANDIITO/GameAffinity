
using System;
using System.Text;

using System.Collections.Generic;
using GameAffinityGen.ApplicationCore.Exceptions;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;
using GameAffinityGen.ApplicationCore.CEN.GameAffinity;



/*PROTECTED REGION ID(usingGameAffinityGen.ApplicationCore.CP.GameAffinity_Interaccion_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace GameAffinityGen.ApplicationCore.CP.GameAffinity
{
public partial class InteraccionCP : GenericBasicCP
{
public GameAffinityGen.ApplicationCore.EN.GameAffinity.InteraccionEN New_ (int p_autor, bool p_disliked, bool p_liked, int p_id_resenya, int p_resenya)
{
        /*PROTECTED REGION ID(GameAffinityGen.ApplicationCore.CP.GameAffinity_Interaccion_new_) ENABLED START*/

        InteraccionCEN interaccionCEN = null;
        ResenyaCEN resenyaCEN = null;
        GameAffinityGen.ApplicationCore.EN.GameAffinity.InteraccionEN result = null;


        try
        {
                CPSession.SessionInitializeTransaction ();
                interaccionCEN = new  InteraccionCEN (CPSession.UnitRepo.InteraccionRepository);
                resenyaCEN = new ResenyaCEN(CPSession.UnitRepo.ResenyaRepository);



                int oid;
                //Initialized InteraccionEN
                InteraccionEN interaccionEN;
                interaccionEN = new InteraccionEN ();

                if (p_autor != -1) {
                        interaccionEN.Autor = new GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN ();
                        interaccionEN.Autor.Id = p_autor;
                }

                interaccionEN.Disliked = p_disliked;

                interaccionEN.Liked = p_liked;

                interaccionEN.Id_resenya = p_id_resenya;


                if (p_resenya != -1) {
                        interaccionEN.Resenya = new GameAffinityGen.ApplicationCore.EN.GameAffinity.ResenyaEN ();
                        interaccionEN.Resenya.Id = p_resenya;
                }

                //da like
                if (interaccionEN.Liked) {
                    interaccionEN.Resenya.Likes_contador++;
                } 
                else if (interaccionEN.Disliked) {
                    interaccionEN.Resenya.Dislikes_contador++;
                }

                resenyaCEN.get_IResenyaRepository().Modify(interaccionEN.Resenya);

                oid = interaccionCEN.get_IInteraccionRepository ().New_ (interaccionEN);

                result = interaccionCEN.get_IInteraccionRepository ().ReadOIDDefault (oid);



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
        return result;


        /*PROTECTED REGION END*/
}
}
}
