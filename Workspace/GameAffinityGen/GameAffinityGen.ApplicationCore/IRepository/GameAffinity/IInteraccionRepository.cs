
using System;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.CP.GameAffinity;

namespace GameAffinityGen.ApplicationCore.IRepository.GameAffinity
{
public partial interface IInteraccionRepository
{
void setSessionCP (GenericSessionCP session);

InteraccionEN ReadOIDDefault (int id
                              );

void ModifyDefault (InteraccionEN interaccion);

System.Collections.Generic.IList<InteraccionEN> ReadAllDefault (int first, int size);



void Modify (InteraccionEN interaccion);


void Destroy (int id
              );


int New_ (InteraccionEN interaccion);

InteraccionEN GetByOID (int id
                        );


System.Collections.Generic.IList<InteraccionEN> GetAll (int first, int size);
}
}
