
using System;
using System.Text;
using System.Collections.Generic;
using GameAffinityGen.ApplicationCore.Exceptions;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;


/*PROTECTED REGION ID(usingGameAffinityGen.ApplicationCore.CEN.GameAffinity_Registrado_aceptar_mentoria) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace GameAffinityGen.ApplicationCore.CEN.GameAffinity
{
public partial class RegistradoCEN
{
public void Aceptar_mentoria (int p_Registrado_OID, string p_nombre, string p_email, string p_nick, bool p_es_mentor, bool p_notificaciones, String p_contrasenya)
{
        /*PROTECTED REGION ID(GameAffinityGen.ApplicationCore.CEN.GameAffinity_Registrado_aceptar_mentoria_customized) START*/

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

        _IRegistradoRepository.Aceptar_mentoria (registradoEN);

        /*PROTECTED REGION END*/
}
}
}
