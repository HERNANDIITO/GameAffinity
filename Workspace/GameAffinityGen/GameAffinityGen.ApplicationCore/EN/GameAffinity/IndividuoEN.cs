
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
 *	Atributo empresas
 */
private System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.EmpresaEN> empresas;



/**
 *	Atributo videojuegos
 */
private System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN> videojuegos;



/**
 *	Atributo img
 */
private string img;






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



public virtual System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.EmpresaEN> Empresas {
        get { return empresas; } set { empresas = value;  }
}



public virtual System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN> Videojuegos {
        get { return videojuegos; } set { videojuegos = value;  }
}



public virtual string Img {
        get { return img; } set { img = value;  }
}





public IndividuoEN()
{
        empresas = new System.Collections.Generic.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.EmpresaEN>();
        videojuegos = new System.Collections.Generic.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN>();
}



public IndividuoEN(int id, string nombre, string apellido, Nullable<DateTime> fechaNac, GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.PaisesEnum nacionalidad, GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.RolesEnum rol, string biografia, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.EmpresaEN> empresas, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN> videojuegos, string img
                   )
{
        this.init (Id, nombre, apellido, fechaNac, nacionalidad, rol, biografia, empresas, videojuegos, img);
}


public IndividuoEN(IndividuoEN individuo)
{
        this.init (individuo.Id, individuo.Nombre, individuo.Apellido, individuo.FechaNac, individuo.Nacionalidad, individuo.Rol, individuo.Biografia, individuo.Empresas, individuo.Videojuegos, individuo.Img);
}

private void init (int id
                   , string nombre, string apellido, Nullable<DateTime> fechaNac, GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.PaisesEnum nacionalidad, GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.RolesEnum rol, string biografia, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.EmpresaEN> empresas, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN> videojuegos, string img)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Apellido = apellido;

        this.FechaNac = fechaNac;

        this.Nacionalidad = nacionalidad;

        this.Rol = rol;

        this.Biografia = biografia;

        this.Empresas = empresas;

        this.Videojuegos = videojuegos;

        this.Img = img;
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
