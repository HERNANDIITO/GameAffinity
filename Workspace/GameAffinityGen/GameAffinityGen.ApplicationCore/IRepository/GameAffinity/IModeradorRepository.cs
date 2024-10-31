
using System;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.CP.GameAffinity;

namespace GameAffinityGen.ApplicationCore.IRepository.GameAffinity
{
public partial interface IModeradorRepository
{
void setSessionCP (GenericSessionCP session);

ModeradorEN ReadOIDDefault (int id
                            );

void ModifyDefault (ModeradorEN moderador);

System.Collections.Generic.IList<ModeradorEN> ReadAllDefault (int first, int size);





int New_ (ModeradorEN moderador);

void Modify (ModeradorEN moderador);


void Destroy (int id
              );


System.Collections.Generic.IList<ModeradorEN> Leer_moderador (int first, int size);


ModeradorEN Leer_OID_moderador (int id
                                );
}
}
