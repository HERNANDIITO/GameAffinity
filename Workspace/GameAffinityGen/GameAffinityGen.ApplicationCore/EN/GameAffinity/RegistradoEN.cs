
using System;
// Definición clase RegistradoEN
namespace GameAffinityGen.ApplicationCore.EN.GameAffinity
{
public partial class RegistradoEN
{
/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo email
 */
private string email;



/**
 *	Atributo nick
 */
private string nick;



/**
 *	Atributo es_mentor
 */
private bool es_mentor;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo seguidos
 */
private System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN> seguidos;



/**
 *	Atributo resenya
 */
private System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ResenyaEN> resenya;



/**
 *	Atributo valoraciones
 */
private System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ValoracionEN> valoraciones;



/**
 *	Atributo listas
 */
private System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ListaEN> listas;



/**
 *	Atributo notificaciones
 */
private bool notificaciones;



/**
 *	Atributo contrasenya
 */
private String contrasenya;



/**
 *	Atributo interaccion
 */
private System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.InteraccionEN> interaccion;






public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual string Nick {
        get { return nick; } set { nick = value;  }
}



public virtual bool Es_mentor {
        get { return es_mentor; } set { es_mentor = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN> Seguidos {
        get { return seguidos; } set { seguidos = value;  }
}



public virtual System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ResenyaEN> Resenya {
        get { return resenya; } set { resenya = value;  }
}



public virtual System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ValoracionEN> Valoraciones {
        get { return valoraciones; } set { valoraciones = value;  }
}



public virtual System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ListaEN> Listas {
        get { return listas; } set { listas = value;  }
}



public virtual bool Notificaciones {
        get { return notificaciones; } set { notificaciones = value;  }
}



public virtual String Contrasenya {
        get { return contrasenya; } set { contrasenya = value;  }
}



public virtual System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.InteraccionEN> Interaccion {
        get { return interaccion; } set { interaccion = value;  }
}





public RegistradoEN()
{
        seguidos = new System.Collections.Generic.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN>();
        resenya = new System.Collections.Generic.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.ResenyaEN>();
        valoraciones = new System.Collections.Generic.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.ValoracionEN>();
        listas = new System.Collections.Generic.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.ListaEN>();
        interaccion = new System.Collections.Generic.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.InteraccionEN>();
}



public RegistradoEN(int id, string nombre, string email, string nick, bool es_mentor, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN> seguidos, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ResenyaEN> resenya, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ValoracionEN> valoraciones, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ListaEN> listas, bool notificaciones, String contrasenya, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.InteraccionEN> interaccion
                    )
{
        this.init (Id, nombre, email, nick, es_mentor, seguidos, resenya, valoraciones, listas, notificaciones, contrasenya, interaccion);
}


public RegistradoEN(RegistradoEN registrado)
{
        this.init (registrado.Id, registrado.Nombre, registrado.Email, registrado.Nick, registrado.Es_mentor, registrado.Seguidos, registrado.Resenya, registrado.Valoraciones, registrado.Listas, registrado.Notificaciones, registrado.Contrasenya, registrado.Interaccion);
}

private void init (int id
                   , string nombre, string email, string nick, bool es_mentor, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN> seguidos, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ResenyaEN> resenya, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ValoracionEN> valoraciones, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ListaEN> listas, bool notificaciones, String contrasenya, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.InteraccionEN> interaccion)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Email = email;

        this.Nick = nick;

        this.Es_mentor = es_mentor;

        this.Seguidos = seguidos;

        this.Resenya = resenya;

        this.Valoraciones = valoraciones;

        this.Listas = listas;

        this.Notificaciones = notificaciones;

        this.Contrasenya = contrasenya;

        this.Interaccion = interaccion;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        RegistradoEN t = obj as RegistradoEN;
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
