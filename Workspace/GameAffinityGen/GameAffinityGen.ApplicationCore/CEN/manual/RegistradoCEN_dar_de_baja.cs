
using System;
using System.Text;
using System.Collections.Generic;
using GameAffinityGen.ApplicationCore.Exceptions;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;


/*PROTECTED REGION ID(usingGameAffinityGen.ApplicationCore.CEN.GameAffinity_Registrado_dar_de_baja) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace GameAffinityGen.ApplicationCore.CEN.GameAffinity
{
public partial class RegistradoCEN
{
public void Dar_de_baja (int p_oid)
{
        /*PROTECTED REGION ID(GameAffinityGen.ApplicationCore.CEN.GameAffinity_Registrado_dar_de_baja) ENABLED START*/

        // Write here your custom code...

        RegistradoEN registrado = this.GetByOID (p_oid);

        registrado.Email = "Anonimo";
        registrado.Contrasenya = "Anonimo";
        registrado.Nick = "Anonimo";
        registrado.Es_mentor = false;
        registrado.Nombre = "Anonimo";
        registrado.Seguidos = [];

        this.get_IRegistradoRepository().ModifyDefault(registrado);

        /*PROTECTED REGION END*/
}
}
}
