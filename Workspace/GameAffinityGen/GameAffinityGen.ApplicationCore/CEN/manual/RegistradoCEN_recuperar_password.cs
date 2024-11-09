
using System;
using System.Text;
using System.Collections.Generic;
using GameAffinityGen.ApplicationCore.Exceptions;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;


/*PROTECTED REGION ID(usingGameAffinityGen.ApplicationCore.CEN.GameAffinity_Registrado_recuperar_password) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace GameAffinityGen.ApplicationCore.CEN.GameAffinity
{
public partial class RegistradoCEN
{
public string Recuperar_password (int p_oid)
{
            /*PROTECTED REGION ID(GameAffinityGen.ApplicationCore.CEN.GameAffinity_Registrado_recuperar_password) ENABLED START*/

            // Obtenemos el usuario por su ID
            RegistradoEN registrado = this.GetByOID(p_oid);

            // Verificamos si el usuario existe
            if (registrado == null)
            {
                throw new Exception("Usuario no encontrado.");
            }
            //Console.WriteLine("Contraseña almacenada en Contrasenya: " + registrado.Contrasenya);
            // Devolvemos la contraseña del usuario
            return registrado.Contrasenya;



        /*PROTECTED REGION END*/
}
}
}
