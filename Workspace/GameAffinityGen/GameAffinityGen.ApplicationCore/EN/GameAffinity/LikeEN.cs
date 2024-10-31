
using System;
// Definición clase LikeEN
namespace GameAffinityGen.ApplicationCore.EN.GameAffinity
{
public partial class LikeEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo user_liked
 */
private GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN user_liked;



/**
 *	Atributo resenya
 */
private GameAffinityGen.ApplicationCore.EN.GameAffinity.ResenyaEN resenya;



/**
 *	Atributo disliked
 */
private bool disliked;



/**
 *	Atributo liked
 */
private bool liked;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN User_liked {
        get { return user_liked; } set { user_liked = value;  }
}



public virtual GameAffinityGen.ApplicationCore.EN.GameAffinity.ResenyaEN Resenya {
        get { return resenya; } set { resenya = value;  }
}



public virtual bool Disliked {
        get { return disliked; } set { disliked = value;  }
}



public virtual bool Liked {
        get { return liked; } set { liked = value;  }
}





public LikeEN()
{
}



public LikeEN(int id, GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN user_liked, GameAffinityGen.ApplicationCore.EN.GameAffinity.ResenyaEN resenya, bool disliked, bool liked
              )
{
        this.init (Id, user_liked, resenya, disliked, liked);
}


public LikeEN(LikeEN like)
{
        this.init (like.Id, like.User_liked, like.Resenya, like.Disliked, like.Liked);
}

private void init (int id
                   , GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN user_liked, GameAffinityGen.ApplicationCore.EN.GameAffinity.ResenyaEN resenya, bool disliked, bool liked)
{
        this.Id = id;


        this.User_liked = user_liked;

        this.Resenya = resenya;

        this.Disliked = disliked;

        this.Liked = liked;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        LikeEN t = obj as LikeEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
