
using System;
// Definición clase PaisesEN
namespace GameAffinityGen.ApplicationCore.EN.GameAffinity
{
public partial class PaisesEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo individuos_de_nacion
 */
private System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN> individuos_de_nacion;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN> Individuos_de_nacion {
        get { return individuos_de_nacion; } set { individuos_de_nacion = value;  }
}





public PaisesEN()
{
        individuos_de_nacion = new System.Collections.Generic.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN>();
}



public PaisesEN(int id, string nombre, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN> individuos_de_nacion
                )
{
        this.init (Id, nombre, individuos_de_nacion);
}


public PaisesEN(PaisesEN paises)
{
        this.init (paises.Id, paises.Nombre, paises.Individuos_de_nacion);
}

private void init (int id
                   , string nombre, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN> individuos_de_nacion)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Individuos_de_nacion = individuos_de_nacion;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PaisesEN t = obj as PaisesEN;
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
