
using System;
using System.Text;
using System.Collections.Generic;
using GameAffinityGen.ApplicationCore.Exceptions;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;


/*PROTECTED REGION ID(usingGameAffinityGen.ApplicationCore.CEN.GameAffinity_Registrado_alternar_notificaciones) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace GameAffinityGen.ApplicationCore.CEN.GameAffinity
{
public partial class RegistradoCEN
{
public void Alternar_notificaciones (int registrado_OID)
{
        /*PROTECTED REGION ID(GameAffinityGen.ApplicationCore.CEN.GameAffinity_Registrado_alternar_notificaciones_customized) START*/

        RegistradoEN registradoEN = null;

        //Initialized RegistradoEN
        registradoEN = new RegistradoEN ();
        registradoEN.Id = registrado_OID;
        //Call to RegistradoRepository

        _IRegistradoRepository.Alternar_notificaciones (registradoEN);

        /*PROTECTED REGION END*/
}
}
}
