
using System;
using System.Text;
using System.Collections.Generic;
using GameAffinityGen.ApplicationCore.Exceptions;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;


/*PROTECTED REGION ID(usingGameAffinityGen.ApplicationCore.CEN.GameAffinity_Lista_isDefault) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace GameAffinityGen.ApplicationCore.CEN.GameAffinity
{
    public partial class ListaCEN
    {
        public bool IsDefault(int p_oid)
        {
            /*PROTECTED REGION ID(GameAffinityGen.ApplicationCore.CEN.GameAffinity_Lista_isDefault) ENABLED START*/

            // Write here your custom code...

            ListaEN lista = _IListaRepository.Leer_OID_lista(p_oid);
            return lista.Default_;

            /*PROTECTED REGION END*/
        }
    }
}
