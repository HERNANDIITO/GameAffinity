
using System;
using System.Text;
using System.Collections.Generic;
using GameAffinityGen.ApplicationCore.Exceptions;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;


/*PROTECTED REGION ID(usingGameAffinityGen.ApplicationCore.CEN.GameAffinity_Lista_cambiar_nombre) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace GameAffinityGen.ApplicationCore.CEN.GameAffinity
{
public partial class ListaCEN
{
public void Cambiar_nombre (int p_Lista_OID, string p_nombre, string p_descripcion, bool p_default)
{
        /*PROTECTED REGION ID(GameAffinityGen.ApplicationCore.CEN.GameAffinity_Lista_cambiar_nombre_customized) START*/

            //Initialized ListaEN
            ListaCEN listaCEN = new ListaCEN(_IListaRepository);
            ListaEN lista = listaCEN.Leer_OID_lista(p_Lista_OID);
            lista.Nombre = p_nombre;
            //Call to ListaRepository

            _IListaRepository.Cambiar_nombre(lista);

        /*PROTECTED REGION END*/
}
}
}
