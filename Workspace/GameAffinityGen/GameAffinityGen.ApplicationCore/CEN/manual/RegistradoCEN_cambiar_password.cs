using System;
using System.Text;
using System.Collections.Generic;
using GameAffinityGen.ApplicationCore.Exceptions;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;
using GameAffinityGen.ApplicationCore.Utils;

/*PROTECTED REGION ID(GameAffinityGen.ApplicationCore.CEN.GameAffinity_Registrado_cambiar_password_customized) START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace GameAffinityGen.ApplicationCore.CEN.GameAffinity
{
    public partial class RegistradoCEN
    {
        public void Cambiar_password(int p_oid, string new_password)
        {
            /*PROTECTED REGION ID(GameAffinityGen.ApplicationCore.CEN.GameAffinity_Registrado_cambiar_password_customized) START*/

            // Obtener el usuario registrado por su ID
            RegistradoEN registrado = this.GetByOID(p_oid);

            // Actualizar la contraseña del usuario
            registrado.Contrasenya = Utils.Util.GetEncondeMD5(new_password);

            // Guardar los cambios en la base de datos
            _IRegistradoRepository.ModifyDefault(registrado);

            /*PROTECTED REGION END*/
        }
    }
}