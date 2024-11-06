
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
 *	Atributo autor
 */
private GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN autor;



/**
 *	Atributo disliked
 */
private bool disliked;



/**
 *	Atributo liked
 */
private bool liked;



/**
 *	Atributo id_resenya
 */
private int id_resenya;



/**
 *	Atributo resenya
 */
private GameAffinityGen.ApplicationCore.EN.GameAffinity.ResenyaEN resenya;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN Autor {
        get { return autor; } set { autor = value;  }
}



public virtual bool Disliked {
        get { return disliked; } set { disliked = value;  }
}



public virtual bool Liked {
        get { return liked; } set { liked = value;  }
}



public virtual int Id_resenya {
        get { return id_resenya; } set { id_resenya = value;  }
}



public virtual GameAffinityGen.ApplicationCore.EN.GameAffinity.ResenyaEN Resenya {
        get { return resenya; } set { resenya = value;  }
}





public LikeEN()
{
}



public LikeEN(int id, GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN autor, bool disliked, bool liked, int id_resenya, GameAffinityGen.ApplicationCore.EN.GameAffinity.ResenyaEN resenya
              )
{
        this.init (Id, autor, disliked, liked, id_resenya, resenya);
}


public LikeEN(LikeEN like)
{
        this.init (like.Id, like.Autor, like.Disliked, like.Liked, like.Id_resenya, like.Resenya);
}

private void init (int id
                   , GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN autor, bool disliked, bool liked, int id_resenya, GameAffinityGen.ApplicationCore.EN.GameAffinity.ResenyaEN resenya)
{
        this.Id = id;


        this.Autor = autor;

        this.Disliked = disliked;

        this.Liked = liked;

        this.Id_resenya = id_resenya;

        this.Resenya = resenya;
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
