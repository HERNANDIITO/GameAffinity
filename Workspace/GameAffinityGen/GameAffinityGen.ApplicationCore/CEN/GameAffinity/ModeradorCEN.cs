

using System;
using System.Text;
using System.Collections.Generic;

using GameAffinityGen.ApplicationCore.Exceptions;

using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;


namespace GameAffinityGen.ApplicationCore.CEN.GameAffinity
{
/*
 *      Definition of the class ModeradorCEN
 *
 */
public partial class ModeradorCEN
{
private IModeradorRepository _IModeradorRepository;

public ModeradorCEN(IModeradorRepository _IModeradorRepository)
{
        this._IModeradorRepository = _IModeradorRepository;
}

public IModeradorRepository get_IModeradorRepository ()
{
        return this._IModeradorRepository;
}

public int New_ (string p_nombre, string p_email, string p_nick, bool p_es_mentor, bool p_notificaciones, String p_contrasenya)
{
        ModeradorEN moderadorEN = null;
        int oid;

        //Initialized ModeradorEN
        moderadorEN = new ModeradorEN ();
        moderadorEN.Nombre = p_nombre;

        moderadorEN.Email = p_email;

        moderadorEN.Nick = p_nick;

        moderadorEN.Es_mentor = p_es_mentor;

        moderadorEN.Notificaciones = p_notificaciones;

        moderadorEN.Contrasenya = Utils.Util.GetEncondeMD5 (p_contrasenya);



        oid = _IModeradorRepository.New_ (moderadorEN);
        return oid;
}

public void Modify (int p_Moderador_OID, string p_nombre, string p_email, string p_nick, bool p_es_mentor, bool p_notificaciones, String p_contrasenya)
{
        ModeradorEN moderadorEN = null;

        //Initialized ModeradorEN
        moderadorEN = new ModeradorEN ();
        moderadorEN.Id = p_Moderador_OID;
        moderadorEN.Nombre = p_nombre;
        moderadorEN.Email = p_email;
        moderadorEN.Nick = p_nick;
        moderadorEN.Es_mentor = p_es_mentor;
        moderadorEN.Notificaciones = p_notificaciones;
        moderadorEN.Contrasenya = Utils.Util.GetEncondeMD5 (p_contrasenya);
        //Call to ModeradorRepository

        _IModeradorRepository.Modify (moderadorEN);
}

public void Destroy (int id
                     )
{
        _IModeradorRepository.Destroy (id);
}

public System.Collections.Generic.IList<ModeradorEN> Leer_moderador (int first, int size)
{
        System.Collections.Generic.IList<ModeradorEN> list = null;

        list = _IModeradorRepository.Leer_moderador (first, size);
        return list;
}
public ModeradorEN Leer_OID_moderador (int id
                                       )
{
        ModeradorEN moderadorEN = null;

        moderadorEN = _IModeradorRepository.Leer_OID_moderador (id);
        return moderadorEN;
}
}
}
