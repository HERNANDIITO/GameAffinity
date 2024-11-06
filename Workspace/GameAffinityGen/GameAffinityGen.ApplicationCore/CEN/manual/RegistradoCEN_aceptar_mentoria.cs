
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
        public void Aceptar_mentoria(int registrado_oid)
        {
            /*PROTECTED REGION ID(GameAffinityGen.ApplicationCore.CEN.GameAffinity_Registrado_aceptar_mentoria_customized) START*/

            RegistradoEN registradoEN = null;

            //Initialized RegistradoEN
            registradoEN = new RegistradoEN();
            registradoEN.Es_mentor = true;
            //Call to RegistradoRepository

            _IRegistradoRepository.Aceptar_mentoria(registradoEN);

            /*PROTECTED REGION END*/
        }
    }
}
