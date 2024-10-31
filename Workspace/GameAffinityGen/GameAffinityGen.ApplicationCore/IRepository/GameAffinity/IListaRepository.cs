
using System;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.CP.GameAffinity;

namespace GameAffinityGen.ApplicationCore.IRepository.GameAffinity
{
public partial interface IListaRepository
{
void setSessionCP (GenericSessionCP session);

ListaEN ReadOIDDefault (int id
                        );

void ModifyDefault (ListaEN lista);

System.Collections.Generic.IList<ListaEN> ReadAllDefault (int first, int size);





System.Collections.Generic.IList<ListaEN> Leer_lista (int first, int size);


ListaEN Leer_OID_lista (int id
                        );


int New_ (ListaEN lista);

void Modify (ListaEN lista);


void Destroy (int id
              );


void Cambiar_nombre (ListaEN lista);


void Cambiar_descripcion (ListaEN lista);
}
}
