
using System;
// Definición clase IndividuoEN
namespace GameAffinityGen.ApplicationCore.EN.GameAffinity
{
public partial class IndividuoEN
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
 *	Atributo apellido
 */
private string apellido;



/**
 *	Atributo fechaNac
 */
private Nullable<DateTime> fechaNac;



/**
 *	Atributo nacionalidad
 */
private GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.PaisesEnum nacionalidad;



/**
 *	Atributo rol
 */
private GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.RolesEnum rol;



/**
 *	Atributo biografia
 */
private string biografia;



/**
 *	Atributo participe
 */
private System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN> participe;



/**
 *	Atributo trabajador
 */
private System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.EmpresaEN> trabajador;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Apellido {
        get { return apellido; } set { apellido = value;  }
}



public virtual Nullable<DateTime> FechaNac {
        get { return fechaNac; } set { fechaNac = value;  }
}



public virtual GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.PaisesEnum Nacionalidad {
        get { return nacionalidad; } set { nacionalidad = value;  }
}



public virtual GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.RolesEnum Rol {
        get { return rol; } set { rol = value;  }
}



public virtual string Biografia {
        get { return biografia; } set { biografia = value;  }
}



public virtual System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN> Participe {
        get { return participe; } set { participe = value;  }
}



public virtual System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.EmpresaEN> Trabajador {
        get { return trabajador; } set { trabajador = value;  }
}





public IndividuoEN()
{
        participe = new System.Collections.Generic.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN>();
        trabajador = new System.Collections.Generic.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.EmpresaEN>();
}



public IndividuoEN(int id, string nombre, string apellido, Nullable<DateTime> fechaNac, GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.PaisesEnum nacionalidad, GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.RolesEnum rol, string biografia, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN> participe, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.EmpresaEN> trabajador
                   )
{
        this.init (Id, nombre, apellido, fechaNac, nacionalidad, rol, biografia, participe, trabajador);
}


public IndividuoEN(IndividuoEN individuo)
{
        this.init (individuo.Id, individuo.Nombre, individuo.Apellido, individuo.FechaNac, individuo.Nacionalidad, individuo.Rol, individuo.Biografia, individuo.Participe, individuo.Trabajador);
}

private void init (int id
                   , string nombre, string apellido, Nullable<DateTime> fechaNac, GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.PaisesEnum nacionalidad, GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.RolesEnum rol, string biografia, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN> participe, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.EmpresaEN> trabajador)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Apellido = apellido;

        this.FechaNac = fechaNac;

        this.Nacionalidad = nacionalidad;

        this.Rol = rol;

        this.Biografia = biografia;

        this.Participe = participe;

        this.Trabajador = trabajador;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        IndividuoEN t = obj as IndividuoEN;
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
