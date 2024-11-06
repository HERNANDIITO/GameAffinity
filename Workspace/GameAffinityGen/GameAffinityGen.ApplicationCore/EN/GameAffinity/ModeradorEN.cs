
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
                   string nombre, string email, string nick, bool es_mentor, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN> seguidos, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ResenyaEN> resenya, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ValoracionEN> valoraciones, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ListaEN> listas, bool notificaciones, String contrasenya, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.LikeEN> like
                   )
{
        this.init (Id, nombre, email, nick, es_mentor, seguidos, resenya, valoraciones, listas, notificaciones, contrasenya, like);
}


public ModeradorEN(ModeradorEN moderador)
{
        this.init (moderador.Id, moderador.Nombre, moderador.Email, moderador.Nick, moderador.Es_mentor, moderador.Seguidos, moderador.Resenya, moderador.Valoraciones, moderador.Listas, moderador.Notificaciones, moderador.Contrasenya, moderador.Like);
}

private void init (int id
                   , string nombre, string email, string nick, bool es_mentor, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN> seguidos, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ResenyaEN> resenya, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ValoracionEN> valoraciones, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ListaEN> listas, bool notificaciones, String contrasenya, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.LikeEN> like)
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

        this.Like = like;
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
