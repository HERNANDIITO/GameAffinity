
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
 *	Atributo desarrollado
 */
private System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN> desarrollado;



/**
 *	Atributo trabaja
 */
private System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN> trabaja;






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



public virtual System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN> Desarrollado {
        get { return desarrollado; } set { desarrollado = value;  }
}



public virtual System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN> Trabaja {
        get { return trabaja; } set { trabaja = value;  }
}





public EmpresaEN()
{
        desarrollado = new System.Collections.Generic.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN>();
        trabaja = new System.Collections.Generic.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN>();
}



public EmpresaEN(int id, string nombre, string descripcion, float nota, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN> desarrollado, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN> trabaja
                 )
{
        this.init (Id, nombre, descripcion, nota, desarrollado, trabaja);
}


public EmpresaEN(EmpresaEN empresa)
{
        this.init (empresa.Id, empresa.Nombre, empresa.Descripcion, empresa.Nota, empresa.Desarrollado, empresa.Trabaja);
}

private void init (int id
                   , string nombre, string descripcion, float nota, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN> desarrollado, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN> trabaja)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Descripcion = descripcion;

        this.Nota = nota;

        this.Desarrollado = desarrollado;

        this.Trabaja = trabaja;
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
