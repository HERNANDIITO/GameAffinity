
using System;
// Definición clase EmpresaEN
namespace GameAffinityGen.ApplicationCore.EN.GameAffinity
{
public partial class EmpresaEN
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
 *	Atributo nota
 */
private float nota;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo videojuegos
 */
private System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN> videojuegos;



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



public virtual float Nota {
        get { return nota; } set { nota = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN> Videojuegos {
        get { return videojuegos; } set { videojuegos = value;  }
}



public virtual System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN> Individuos {
        get { return individuos; } set { individuos = value;  }
}





public EmpresaEN()
{
        videojuegos = new System.Collections.Generic.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN>();
        individuos = new System.Collections.Generic.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN>();
}



public EmpresaEN(int id, string nombre, string descripcion, float nota, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN> videojuegos, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN> individuos
                 )
{
        this.init (Id, nombre, descripcion, nota, videojuegos, individuos);
}


public EmpresaEN(EmpresaEN empresa)
{
        this.init (empresa.Id, empresa.Nombre, empresa.Descripcion, empresa.Nota, empresa.Videojuegos, empresa.Individuos);
}

private void init (int id
                   , string nombre, string descripcion, float nota, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN> videojuegos, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN> individuos)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Descripcion = descripcion;

        this.Nota = nota;

        this.Videojuegos = videojuegos;

        this.Individuos = individuos;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        EmpresaEN t = obj as EmpresaEN;
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
