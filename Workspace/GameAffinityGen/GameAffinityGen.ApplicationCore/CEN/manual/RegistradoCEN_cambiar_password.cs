
using System;
using System.Text;
using System.Collections.Generic;
using GameAffinityGen.ApplicationCore.Exceptions;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;


/*PROTECTED REGION ID(usingGameAffinityGen.ApplicationCore.CEN.GameAffinity_Registrado_cambiar_password) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace GameAffinityGen.ApplicationCore.CEN.GameAffinity
{
public partial class RegistradoCEN
{
public void Cambiar_password (int p_oid, string new_password)
{
        /*PROTECTED REGION ID(GameAffinityGen.ApplicationCore.CEN.GameAffinity_Registrado_cambiar_password) ENABLED START*/

        // Write here your custom code...

        RegistradoEN registrado = this.GetByOID (p_oid);

        registrado.Contrasenya = new_password;

        this.get_IRegistradoRepository ().ModifyDefault (registrado);

        /*PROTECTED REGION END*/
}
}
}
