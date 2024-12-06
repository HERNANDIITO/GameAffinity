

using System;
using System.Text;
using System.Collections.Generic;

using GameAffinityGen.ApplicationCore.Exceptions;

using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;
using Newtonsoft.Json;
using GameAffinityGen.ApplicationCore.CP.GameAffinity;
using static System.Collections.Specialized.BitVector32;


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
        RegistradoEN registradoEN = this.GetByOID(registrado_oid);

        //Initialized RegistradoEN
        registradoEN.Es_mentor = true;

        //Call to RegistradoRepository
        _IRegistradoRepository.ModifyDefault (registradoEN);
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
public string Login (string p_email, string p_pass)
{
        string result = null;
        RegistradoEN en = _IRegistradoRepository.GetByEmail (p_email);

        if (en != null && en.Contrasenya.Equals (Utils.Util.GetEncondeMD5 (p_pass)))
                result = "Logged";

        return result;
}




//private string Encode (int id)
//{
//        var payload = new Dictionary<string, object>(){
//                { "id", id }
//        };
//        string token = Jose.JWT.Encode (payload, Utils.Util.getKey (), Jose.JwsAlgorithm.HS256);

//        return token;
//}

//public string GetToken (int id)
//{
//        RegistradoEN en = _IRegistradoRepository.ReadOIDDefault (id);
//        string token = Encode (en.Id);

//        return token;
//}
//public int CheckToken (string token)
//{
//        int result = -1;

//        try
//        {
//                string decodedToken = Utils.Util.Decode (token);



//                int id = (int)ObtenerID (decodedToken);

//                RegistradoEN en = _IRegistradoRepository.ReadOIDDefault (id);

//                if (en != null && ((long)en.Id).Equals (ObtenerID (decodedToken))
//                    ) {
//                        result = id;
//                }
//                else throw new ModelException ("El token es incorrecto");
//        } catch (Exception)
//        {
//                throw new ModelException ("El token es incorrecto");
//        }

//        return result;
//}


//public long ObtenerID (string decodedToken)
//{
//        try
//        {
//                Dictionary<string, object> results = JsonConvert.DeserializeObject<Dictionary<string, object> >(decodedToken);
//                long id = (long)results ["id"];
//                return id;
//        }
//        catch
//        {
//                throw new Exception ("El token enviado no es correcto");
//        }
//}
}
}
