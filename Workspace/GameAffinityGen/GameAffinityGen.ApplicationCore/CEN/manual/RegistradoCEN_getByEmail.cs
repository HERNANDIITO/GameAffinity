
using System;
using System.Text;
using System.Collections.Generic;
using GameAffinityGen.ApplicationCore.Exceptions;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;
using GameAffinityGen.ApplicationCore.CP.GameAffinity;


// PROTECTED REGION ID(usingGameAffinityGen.ApplicationCore.CEN.GameAffinity_Registrado_getByEmail) ENABLED START/
//  references to other libraries
//PROTECTED REGION END/

namespace GameAffinityGen.ApplicationCore.CEN.GameAffinity
{
    public partial class RegistradoCEN
    {
        public RegistradoEN GetByEmail(string email)
        {
            // PROTECTED REGION ID(GameAffinityGen.ApplicationCore.CEN.GameAffinity_Registrado_getByEmail) ENABLED START/
            RegistradoEN registradoEN = null;

            registradoEN = _IRegistradoRepository.GetByEmail(email);
            return registradoEN;

            // PROTECTED REGION END/
        }
    }
}