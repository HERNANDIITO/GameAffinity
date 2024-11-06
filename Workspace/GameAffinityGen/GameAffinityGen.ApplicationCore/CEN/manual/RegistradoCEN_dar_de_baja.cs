
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

        RegistradoEN registrado = _IRegistradoRepository.GetByOID (p_oid);

        registrado.Email = "An�nimo";
        registrado.Contrasenya = "An�nimo";
        registrado.Nick = "An�nimo";
        registrado.Es_mentor = false;
        registrado.Nombre = "An�nimo";
        registrado.Seguidos = [];

        /*PROTECTED REGION END*/
}
}
}
