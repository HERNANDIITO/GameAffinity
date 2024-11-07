
using System;
// Definición clase ValoracionEN
namespace GameAffinityGen.ApplicationCore.EN.GameAffinity
{
public partial class ValoracionEN
{
/**
 *	Atributo nota
 */
private int nota;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo autor_valoracion
 */
private GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN autor_valoracion;



/**
 *	Atributo videojuego_valorado
 */
private GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN videojuego_valorado;






public virtual int Nota {
        get { return nota; } set { nota = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN Autor_valoracion {
        get { return autor_valoracion; } set { autor_valoracion = value;  }
}



public virtual GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN Videojuego_valorado {
        get { return videojuego_valorado; } set { videojuego_valorado = value;  }
}





public ValoracionEN()
{
}



public ValoracionEN(int id, int nota, GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN autor_valoracion, GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN videojuego_valorado
                    )
{
        this.init (Id, nota, autor_valoracion, videojuego_valorado);
}


public ValoracionEN(ValoracionEN valoracion)
{
        this.init (valoracion.Id, valoracion.Nota, valoracion.Autor_valoracion, valoracion.Videojuego_valorado);
}

private void init (int id
                   , int nota, GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN autor_valoracion, GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN videojuego_valorado)
{
        this.Id = id;


        this.Nota = nota;

        this.Autor_valoracion = autor_valoracion;

        this.Videojuego_valorado = videojuego_valorado;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ValoracionEN t = obj as ValoracionEN;
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
