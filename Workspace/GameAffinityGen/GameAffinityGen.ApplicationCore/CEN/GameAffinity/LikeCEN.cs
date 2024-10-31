

using System;
using System.Text;
using System.Collections.Generic;

using GameAffinityGen.ApplicationCore.Exceptions;

using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;


namespace GameAffinityGen.ApplicationCore.CEN.GameAffinity
{
/*
 *      Definition of the class LikeCEN
 *
 */
public partial class LikeCEN
{
private ILikeRepository _ILikeRepository;

public LikeCEN(ILikeRepository _ILikeRepository)
{
        this._ILikeRepository = _ILikeRepository;
}

public ILikeRepository get_ILikeRepository ()
{
        return this._ILikeRepository;
}

public void Modify (int p_Like_OID, bool p_disliked, bool p_liked)
{
        LikeEN likeEN = null;

        //Initialized LikeEN
        likeEN = new LikeEN ();
        likeEN.Id = p_Like_OID;
        likeEN.Disliked = p_disliked;
        likeEN.Liked = p_liked;
        //Call to LikeRepository

        _ILikeRepository.Modify (likeEN);
}

public void Destroy (int id
                     )
{
        _ILikeRepository.Destroy (id);
}

public int New_ (int p_user_liked, int p_resenya, bool p_disliked, bool p_liked)
{
        LikeEN likeEN = null;
        int oid;

        //Initialized LikeEN
        likeEN = new LikeEN ();

        if (p_user_liked != -1) {
                // El argumento p_user_liked -> Property user_liked es oid = false
                // Lista de oids id
                likeEN.User_liked = new GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN ();
                likeEN.User_liked.Id = p_user_liked;
        }


        if (p_resenya != -1) {
                // El argumento p_resenya -> Property resenya es oid = false
                // Lista de oids id
                likeEN.Resenya = new GameAffinityGen.ApplicationCore.EN.GameAffinity.ResenyaEN ();
                likeEN.Resenya.Id = p_resenya;
        }

        likeEN.Disliked = p_disliked;

        likeEN.Liked = p_liked;



        oid = _ILikeRepository.New_ (likeEN);
        return oid;
}
}
}
