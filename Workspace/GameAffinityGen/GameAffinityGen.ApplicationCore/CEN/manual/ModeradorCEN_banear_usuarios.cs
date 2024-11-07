
using System;
using System.Text;
using System.Collections.Generic;
using GameAffinityGen.ApplicationCore.Exceptions;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;
using GameAffinityGen.ApplicationCore.CP.GameAffinity;


/*PROTECTED REGION ID(usingGameAffinityGen.ApplicationCore.CEN.GameAffinity_Moderador_banear_usuarios) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace GameAffinityGen.ApplicationCore.CEN.GameAffinity
{
    public partial class ModeradorCEN
    {
        public void Banear_usuarios(int p_oid, int user_ID)
        {
            /*PROTECTED REGION ID(GameAffinityGen.ApplicationCore.CEN.GameAffinity_Moderador_banear_usuarios) ENABLED START*/

            // Write here your custom code...
            this

            RegistradoEN listillo = this.GetByOID(user_ID);

            if (listillo == null)
            {
                throw new Exception("ID del usuario no existente");
            }

            //ahora habria que dar de baja pero el programa no hace caso asi que o se hace otra cosa o yoquese
            
            

            /*PROTECTED REGION END*/
        }
    }
}
