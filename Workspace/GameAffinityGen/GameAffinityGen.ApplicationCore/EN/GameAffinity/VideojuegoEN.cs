
using System;
// Definición clase VideojuegoEN
namespace GameAffinityGen.ApplicationCore.EN.GameAffinity
{
public partial class VideojuegoEN
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
 *	Atributo nota_media
 */
private float nota_media;



/**
 *	Atributo genero
 */
private GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.GenerosEnum genero;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo resenyas
 */
private System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ResenyaEN> resenyas;



/**
 *	Atributo empresas
 */
private System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.EmpresaEN> empresas;



/**
 *	Atributo lista
 */
private System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ListaEN> lista;



/**
 *	Atributo valoracion
 */
private System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ValoracionEN> valoracion;



/**
 *	Atributo individuos
 */
private System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN> individuos;






public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual float Nota_media {
        get { return nota_media; } set { nota_media = value;  }
}



public virtual GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.GenerosEnum Genero {
        get { return genero; } set { genero = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ResenyaEN> Resenyas {
        get { return resenyas; } set { resenyas = value;  }
}



public virtual System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.EmpresaEN> Empresas {
        get { return empresas; } set { empresas = value;  }
}



public virtual System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ListaEN> Lista {
        get { return lista; } set { lista = value;  }
}



public virtual System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ValoracionEN> Valoracion {
        get { return valoracion; } set { valoracion = value;  }
}



public virtual System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN> Individuos {
        get { return individuos; } set { individuos = value;  }
}





public VideojuegoEN()
{
        resenyas = new System.Collections.Generic.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.ResenyaEN>();
        empresas = new System.Collections.Generic.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.EmpresaEN>();
        lista = new System.Collections.Generic.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.ListaEN>();
        valoracion = new System.Collections.Generic.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.ValoracionEN>();
        individuos = new System.Collections.Generic.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN>();
}



public VideojuegoEN(int id, string nombre, string descripcion, float nota_media, GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.GenerosEnum genero, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ResenyaEN> resenyas, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.EmpresaEN> empresas, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ListaEN> lista, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ValoracionEN> valoracion, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN> individuos
                    )
{
        this.init (Id, nombre, descripcion, nota_media, genero, resenyas, empresas, lista, valoracion, individuos);
}


public VideojuegoEN(VideojuegoEN videojuego)
{
        this.init (videojuego.Id, videojuego.Nombre, videojuego.Descripcion, videojuego.Nota_media, videojuego.Genero, videojuego.Resenyas, videojuego.Empresas, videojuego.Lista, videojuego.Valoracion, videojuego.Individuos);
}

private void init (int id
                   , string nombre, string descripcion, float nota_media, GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.GenerosEnum genero, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ResenyaEN> resenyas, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.EmpresaEN> empresas, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ListaEN> lista, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ValoracionEN> valoracion, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN> individuos)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Descripcion = descripcion;

        this.Nota_media = nota_media;

        this.Genero = genero;

        this.Resenyas = resenyas;

        this.Empresas = empresas;

        this.Lista = lista;

        this.Valoracion = valoracion;

        this.Individuos = individuos;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        VideojuegoEN t = obj as VideojuegoEN;
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
