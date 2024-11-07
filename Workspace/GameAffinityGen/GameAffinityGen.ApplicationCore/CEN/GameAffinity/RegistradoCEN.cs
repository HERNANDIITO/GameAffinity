

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
public void Aceptar_mentoria (int registrado_oid)
{
        RegistradoEN registradoEN = null;

        //Initialized RegistradoEN
        registradoEN = new RegistradoEN ();
        registradoEN.Es_mentor = true;
        //Call to RegistradoRepository

        _IRegistradoRepository.Aceptar_mentoria (registradoEN);
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

public RegistradoEN GetByOID (int id
                              )
{
        RegistradoEN registradoEN = null;

        registradoEN = _IRegistradoRepository.GetByOID (id);
        return registradoEN;
}

public System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN> GetMentores (bool ? es_mentor)
{
        return _IRegistradoRepository.GetMentores (es_mentor);
}
public void DarLike (int p_Registrado_OID, System.Collections.Generic.IList<int> p_interaccion_OIDs)
{
        //Call to RegistradoRepository

        _IRegistradoRepository.DarLike (p_Registrado_OID, p_interaccion_OIDs);
}
public void QuitarLike (int p_Registrado_OID, System.Collections.Generic.IList<int> p_interaccion_OIDs)
{
        //Call to RegistradoRepository

        _IRegistradoRepository.QuitarLike (p_Registrado_OID, p_interaccion_OIDs);
}
public void CrearValoracion (int p_Registrado_OID, System.Collections.Generic.IList<int> p_valoraciones_OIDs)
{
        //Call to RegistradoRepository

        _IRegistradoRepository.CrearValoracion (p_Registrado_OID, p_valoraciones_OIDs);
}
public void EliminarValoracion (int p_Registrado_OID, System.Collections.Generic.IList<int> p_valoraciones_OIDs)
{
        //Call to RegistradoRepository

        _IRegistradoRepository.EliminarValoracion (p_Registrado_OID, p_valoraciones_OIDs);
}
public void CrearLista (int p_Registrado_OID, System.Collections.Generic.IList<int> p_listas_OIDs)
{
        //Call to RegistradoRepository

        _IRegistradoRepository.CrearLista (p_Registrado_OID, p_listas_OIDs);
}
public void EliminarLista (int p_Registrado_OID, System.Collections.Generic.IList<int> p_listas_OIDs)
{
        //Call to RegistradoRepository

        _IRegistradoRepository.EliminarLista (p_Registrado_OID, p_listas_OIDs);
}
}
}
