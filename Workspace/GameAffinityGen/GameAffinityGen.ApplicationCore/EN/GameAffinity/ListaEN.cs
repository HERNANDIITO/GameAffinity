
using System;
// Definición clase ListaEN
namespace GameAffinityGen.ApplicationCore.EN.GameAffinity
{
public partial class ListaEN
{
/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo por_defecto
 */
private bool por_defecto;



/**
 *	Atributo autor_lista
 */
private GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN autor_lista;



/**
 *	Atributo videojuegos
 */
private System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN> videojuegos;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo img
 */
private string img;






public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual bool Por_defecto {
        get { return por_defecto; } set { por_defecto = value;  }
}



public virtual GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN Autor_lista {
        get { return autor_lista; } set { autor_lista = value;  }
}



public virtual System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN> Videojuegos {
        get { return videojuegos; } set { videojuegos = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Img {
        get { return img; } set { img = value;  }
}





public ListaEN()
{
        videojuegos = new System.Collections.Generic.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN>();
}



public ListaEN(int id, string nombre, string descripcion, bool por_defecto, GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN autor_lista, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN> videojuegos, string img
               )
{
        this.init (Id, nombre, descripcion, por_defecto, autor_lista, videojuegos, img);
}


public ListaEN(ListaEN lista)
{
        this.init (lista.Id, lista.Nombre, lista.Descripcion, lista.Por_defecto, lista.Autor_lista, lista.Videojuegos, lista.Img);
}

private void init (int id
                   , string nombre, string descripcion, bool por_defecto, GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN autor_lista, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN> videojuegos, string img)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Descripcion = descripcion;

        this.Por_defecto = por_defecto;

        this.Autor_lista = autor_lista;

        this.Videojuegos = videojuegos;

        this.Img = img;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ListaEN t = obj as ListaEN;
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
