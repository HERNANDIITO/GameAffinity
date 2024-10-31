
using System;
// Definición clase ResenyaEN
namespace GameAffinityGen.ApplicationCore.EN.GameAffinity
{
public partial class ResenyaEN
{
/**
 *	Atributo titulo
 */
private string titulo;



/**
 *	Atributo texto
 */
private string texto;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo likes
 */
private int likes;



/**
 *	Atributo dislikes
 */
private int dislikes;



/**
 *	Atributo escribe
 */
private GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN escribe;



/**
 *	Atributo resenyado
 */
private GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN resenyado;



/**
 *	Atributo mg
 */
private System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.LikeEN> mg;






public virtual string Titulo {
        get { return titulo; } set { titulo = value;  }
}



public virtual string Texto {
        get { return texto; } set { texto = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual int Likes {
        get { return likes; } set { likes = value;  }
}



public virtual int Dislikes {
        get { return dislikes; } set { dislikes = value;  }
}



public virtual GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN Escribe {
        get { return escribe; } set { escribe = value;  }
}



public virtual GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN Resenyado {
        get { return resenyado; } set { resenyado = value;  }
}



public virtual System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.LikeEN> Mg {
        get { return mg; } set { mg = value;  }
}





public ResenyaEN()
{
        mg = new System.Collections.Generic.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.LikeEN>();
}



public ResenyaEN(int id, string titulo, string texto, int likes, int dislikes, GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN escribe, GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN resenyado, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.LikeEN> mg
                 )
{
        this.init (Id, titulo, texto, likes, dislikes, escribe, resenyado, mg);
}


public ResenyaEN(ResenyaEN resenya)
{
        this.init (resenya.Id, resenya.Titulo, resenya.Texto, resenya.Likes, resenya.Dislikes, resenya.Escribe, resenya.Resenyado, resenya.Mg);
}

private void init (int id
                   , string titulo, string texto, int likes, int dislikes, GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN escribe, GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN resenyado, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.LikeEN> mg)
{
        this.Id = id;


        this.Titulo = titulo;

        this.Texto = texto;

        this.Likes = likes;

        this.Dislikes = dislikes;

        this.Escribe = escribe;

        this.Resenyado = resenyado;

        this.Mg = mg;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ResenyaEN t = obj as ResenyaEN;
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
