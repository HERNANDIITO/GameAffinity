
using System;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.CP.GameAffinity;

namespace GameAffinityGen.ApplicationCore.IRepository.GameAffinity
{
public partial interface IResenyaRepository
{
void setSessionCP (GenericSessionCP session);

ResenyaEN ReadOIDDefault (int id
                          );

void ModifyDefault (ResenyaEN resenya);

System.Collections.Generic.IList<ResenyaEN> ReadAllDefault (int first, int size);



void Modify (ResenyaEN resenya);


void Destroy (int id
              );


System.Collections.Generic.IList<ResenyaEN> Leer_resenya (int first, int size);


ResenyaEN Leer_OID_resenya (int id
                            );


int New_ (ResenyaEN resenya);
}
}
