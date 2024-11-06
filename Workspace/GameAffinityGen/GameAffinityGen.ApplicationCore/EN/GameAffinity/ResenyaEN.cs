
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
 *	Atributo likes_contador
 */
private int likes_contador;



/**
 *	Atributo dislikes_contador
 */
private int dislikes_contador;



/**
 *	Atributo autor_resenya
 */
private GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN autor_resenya;



/**
 *	Atributo videojuego
 */
private GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN videojuego;



/**
 *	Atributo interacciones
 */
private System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.InteraccionEN> interacciones;






public virtual string Titulo {
        get { return titulo; } set { titulo = value;  }
}



public virtual string Texto {
        get { return texto; } set { texto = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual int Likes_contador {
        get { return likes_contador; } set { likes_contador = value;  }
}



public virtual int Dislikes_contador {
        get { return dislikes_contador; } set { dislikes_contador = value;  }
}



public virtual GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN Autor_resenya {
        get { return autor_resenya; } set { autor_resenya = value;  }
}



public virtual GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN Videojuego {
        get { return videojuego; } set { videojuego = value;  }
}



public virtual System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.InteraccionEN> Interacciones {
        get { return interacciones; } set { interacciones = value;  }
}





public ResenyaEN()
{
        interacciones = new System.Collections.Generic.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.InteraccionEN>();
}



public ResenyaEN(int id, string titulo, string texto, int likes_contador, int dislikes_contador, GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN autor_resenya, GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN videojuego, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.InteraccionEN> interacciones
                 )
{
        this.init (Id, titulo, texto, likes_contador, dislikes_contador, autor_resenya, videojuego, interacciones);
}


public ResenyaEN(ResenyaEN resenya)
{
        this.init (resenya.Id, resenya.Titulo, resenya.Texto, resenya.Likes_contador, resenya.Dislikes_contador, resenya.Autor_resenya, resenya.Videojuego, resenya.Interacciones);
}

private void init (int id
                   , string titulo, string texto, int likes_contador, int dislikes_contador, GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN autor_resenya, GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN videojuego, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.InteraccionEN> interacciones)
{
        this.Id = id;


        this.Titulo = titulo;

        this.Texto = texto;

        this.Likes_contador = likes_contador;

        this.Dislikes_contador = dislikes_contador;

        this.Autor_resenya = autor_resenya;

        this.Videojuego = videojuego;

        this.Interacciones = interacciones;
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
