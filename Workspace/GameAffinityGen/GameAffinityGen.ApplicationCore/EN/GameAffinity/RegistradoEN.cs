
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
 *	Atributo escrita
 */
private System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ResenyaEN> escrita;



/**
 *	Atributo pertenece
 */
private System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ValoracionEN> pertenece;



/**
 *	Atributo creada
 */
private System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ListaEN> creada;



/**
 *	Atributo notificaciones
 */
private bool notificaciones;



/**
 *	Atributo contrasenya
 */
private String contrasenya;



/**
 *	Atributo hecho_por
 */
private System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.LikeEN> hecho_por;






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



public virtual System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ResenyaEN> Escrita {
        get { return escrita; } set { escrita = value;  }
}



public virtual System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ValoracionEN> Pertenece {
        get { return pertenece; } set { pertenece = value;  }
}



public virtual System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ListaEN> Creada {
        get { return creada; } set { creada = value;  }
}



public virtual bool Notificaciones {
        get { return notificaciones; } set { notificaciones = value;  }
}



public virtual String Contrasenya {
        get { return contrasenya; } set { contrasenya = value;  }
}



public virtual System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.LikeEN> Hecho_por {
        get { return hecho_por; } set { hecho_por = value;  }
}





public RegistradoEN()
{
        seguidos = new System.Collections.Generic.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN>();
        escrita = new System.Collections.Generic.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.ResenyaEN>();
        pertenece = new System.Collections.Generic.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.ValoracionEN>();
        creada = new System.Collections.Generic.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.ListaEN>();
        hecho_por = new System.Collections.Generic.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.LikeEN>();
}



public RegistradoEN(int id, string nombre, string email, string nick, bool es_mentor, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN> seguidos, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ResenyaEN> escrita, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ValoracionEN> pertenece, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ListaEN> creada, bool notificaciones, String contrasenya, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.LikeEN> hecho_por
                    )
{
        this.init (Id, nombre, email, nick, es_mentor, seguidos, escrita, pertenece, creada, notificaciones, contrasenya, hecho_por);
}


public RegistradoEN(RegistradoEN registrado)
{
        this.init (registrado.Id, registrado.Nombre, registrado.Email, registrado.Nick, registrado.Es_mentor, registrado.Seguidos, registrado.Escrita, registrado.Pertenece, registrado.Creada, registrado.Notificaciones, registrado.Contrasenya, registrado.Hecho_por);
}

private void init (int id
                   , string nombre, string email, string nick, bool es_mentor, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN> seguidos, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ResenyaEN> escrita, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ValoracionEN> pertenece, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ListaEN> creada, bool notificaciones, String contrasenya, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.LikeEN> hecho_por)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Email = email;

        this.Nick = nick;

        this.Es_mentor = es_mentor;

        this.Seguidos = seguidos;

        this.Escrita = escrita;

        this.Pertenece = pertenece;

        this.Creada = creada;

        this.Notificaciones = notificaciones;

        this.Contrasenya = contrasenya;

        this.Hecho_por = hecho_por;
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
