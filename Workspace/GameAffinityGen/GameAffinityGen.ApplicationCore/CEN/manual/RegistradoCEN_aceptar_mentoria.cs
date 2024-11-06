using System;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.Exceptions;
using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;

namespace GameAffinityGen.ApplicationCore.CEN.GameAffinity
{
    public partial class RegistradoCEN
    {
        public void AceptarMentoria(int p_Registrado_OID)
        {
            
            RegistradoEN registradoEN = _IRegistradoRepository.Leer_OID_registrado(p_Registrado_OID);

            if (registradoEN == null)
            {
                throw new ModelException("El usuario no existe.");
            }
            
            registradoEN.Es_mentor = true;

            
            _IRegistradoRepository.Modify(registradoEN);
        }
    }
}