

using System;
using System.Text;
using System.Collections.Generic;

using GameAffinityGen.ApplicationCore.Exceptions;

using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;


namespace GameAffinityGen.ApplicationCore.CEN.GameAffinity
{
/*
 *      Definition of the class RegistradoCEN
 *
 */
public partial class RegistradoCEN
{
private IRegistradoRepository _IRegistradoRepository;

public RegistradoCEN(IRegistradoRepository _IRegistradoRepository)
{
        this._IRegistradoRepository = _IRegistradoRepository;
}

public IRegistradoRepository get_IRegistradoRepository ()
{
        return this._IRegistradoRepository;
}

public void Seguir_perfiles (int p_Registrado_OID, System.Collections.Generic.IList<int> p_seguidos_OIDs)
{
        //Call to RegistradoRepository

        _IRegistradoRepository.Seguir_perfiles (p_Registrado_OID, p_seguidos_OIDs);
}
public void Dejar_de_seguir_perfiles (int p_Registrado_OID, System.Collections.Generic.IList<int> p_seguidos_OIDs)
{
        //Call to RegistradoRepository

        _IRegistradoRepository.Dejar_de_seguir_perfiles (p_Registrado_OID, p_seguidos_OIDs);
}
public int New_ (string p_nombre, string p_email, string p_nick, bool p_es_mentor, bool p_notificaciones, String p_contrasenya)
{
        RegistradoEN registradoEN = null;
        int oid;

        //Initialized RegistradoEN
        registradoEN = new RegistradoEN ();
        registradoEN.Nombre = p_nombre;

        registradoEN.Email = p_email;

        registradoEN.Nick = p_nick;

        registradoEN.Es_mentor = p_es_mentor;

        registradoEN.Notificaciones = p_notificaciones;

        registradoEN.Contrasenya = Utils.Util.GetEncondeMD5 (p_contrasenya);



        oid = _IRegistradoRepository.New_ (registradoEN);
        return oid; 
}

public void Modify (int p_Registrado_OID, string p_nombre, string p_email, string p_nick, bool p_es_mentor, bool p_notificaciones, String p_contrasenya)
{
        RegistradoEN registradoEN = null;

        //Initialized RegistradoEN
        registradoEN = new RegistradoEN ();
        registradoEN.Id = p_Registrado_OID;
        registradoEN.Nombre = p_nombre;
        registradoEN.Email = p_email;
        registradoEN.Nick = p_nick;
        registradoEN.Es_mentor = p_es_mentor;
        registradoEN.Notificaciones = p_notificaciones;
        registradoEN.Contrasenya = Utils.Util.GetEncondeMD5 (p_contrasenya);
        //Call to RegistradoRepository

        _IRegistradoRepository.Modify (registradoEN);
}

public void Destroy (int id
                     )
{
        _IRegistradoRepository.Destroy (id);
}

public RegistradoEN Leer_OID_registrado (int id
                                         )
{
        RegistradoEN registradoEN = null;

        registradoEN = _IRegistradoRepository.Leer_OID_registrado (id);
        return registradoEN;
}

public System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN> Leer_mentores (bool ? es_mentor)
{
        return _IRegistradoRepository.Leer_mentores (es_mentor);
}
}
}
