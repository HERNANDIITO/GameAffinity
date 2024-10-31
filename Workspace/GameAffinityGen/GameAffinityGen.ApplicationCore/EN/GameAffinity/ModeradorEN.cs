
using System;
// Definición clase ModeradorEN
namespace GameAffinityGen.ApplicationCore.EN.GameAffinity
{
public partial class ModeradorEN                                                                    : GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN


{
public ModeradorEN() : base ()
{
}



public ModeradorEN(int id,
                   string nombre, string email, string nick, bool es_mentor, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN> seguidos, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ResenyaEN> escrita, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ValoracionEN> pertenece, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ListaEN> creada, bool notificaciones, String contrasenya, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.LikeEN> hecho_por
                   )
{
        this.init (Id, nombre, email, nick, es_mentor, seguidos, escrita, pertenece, creada, notificaciones, contrasenya, hecho_por);
}


public ModeradorEN(ModeradorEN moderador)
{
        this.init (moderador.Id, moderador.Nombre, moderador.Email, moderador.Nick, moderador.Es_mentor, moderador.Seguidos, moderador.Escrita, moderador.Pertenece, moderador.Creada, moderador.Notificaciones, moderador.Contrasenya, moderador.Hecho_por);
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
        ModeradorEN t = obj as ModeradorEN;
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
