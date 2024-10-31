
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
 *	Atributo resenya
 */
private System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ResenyaEN> resenya;



/**
 *	Atributo desarrolla
 */
private System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.EmpresaEN> desarrolla;



/**
 *	Atributo lista
 */
private System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ListaEN> lista;



/**
 *	Atributo participa
 */
private System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN> participa;



/**
 *	Atributo aporta
 */
private GameAffinityGen.ApplicationCore.EN.GameAffinity.ValoracionEN aporta;






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



public virtual System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ResenyaEN> Resenya {
        get { return resenya; } set { resenya = value;  }
}



public virtual System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.EmpresaEN> Desarrolla {
        get { return desarrolla; } set { desarrolla = value;  }
}



public virtual System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ListaEN> Lista {
        get { return lista; } set { lista = value;  }
}



public virtual System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN> Participa {
        get { return participa; } set { participa = value;  }
}



public virtual GameAffinityGen.ApplicationCore.EN.GameAffinity.ValoracionEN Aporta {
        get { return aporta; } set { aporta = value;  }
}





public VideojuegoEN()
{
        resenya = new System.Collections.Generic.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.ResenyaEN>();
        desarrolla = new System.Collections.Generic.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.EmpresaEN>();
        lista = new System.Collections.Generic.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.ListaEN>();
        participa = new System.Collections.Generic.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN>();
}



public VideojuegoEN(int id, string nombre, string descripcion, float nota_media, GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.GenerosEnum genero, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ResenyaEN> resenya, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.EmpresaEN> desarrolla, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ListaEN> lista, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN> participa, GameAffinityGen.ApplicationCore.EN.GameAffinity.ValoracionEN aporta
                    )
{
        this.init (Id, nombre, descripcion, nota_media, genero, resenya, desarrolla, lista, participa, aporta);
}


public VideojuegoEN(VideojuegoEN videojuego)
{
        this.init (videojuego.Id, videojuego.Nombre, videojuego.Descripcion, videojuego.Nota_media, videojuego.Genero, videojuego.Resenya, videojuego.Desarrolla, videojuego.Lista, videojuego.Participa, videojuego.Aporta);
}

private void init (int id
                   , string nombre, string descripcion, float nota_media, GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.GenerosEnum genero, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ResenyaEN> resenya, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.EmpresaEN> desarrolla, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ListaEN> lista, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN> participa, GameAffinityGen.ApplicationCore.EN.GameAffinity.ValoracionEN aporta)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Descripcion = descripcion;

        this.Nota_media = nota_media;

        this.Genero = genero;

        this.Resenya = resenya;

        this.Desarrolla = desarrolla;

        this.Lista = lista;

        this.Participa = participa;

        this.Aporta = aporta;
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
