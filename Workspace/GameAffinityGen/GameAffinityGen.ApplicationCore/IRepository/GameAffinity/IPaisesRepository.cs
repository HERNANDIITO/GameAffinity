
using System;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.CP.GameAffinity;

namespace GameAffinityGen.ApplicationCore.IRepository.GameAffinity
{
public partial interface IPaisesRepository
{
void setSessionCP (GenericSessionCP session);

PaisesEN ReadOIDDefault (int id
                         );

void ModifyDefault (PaisesEN paises);

System.Collections.Generic.IList<PaisesEN> ReadAllDefault (int first, int size);



int New_ (PaisesEN paises);

void Modify (PaisesEN paises);


void Destroy (int id
              );


PaisesEN ReadOID (int id
                  );


System.Collections.Generic.IList<PaisesEN> ReadAll (int first, int size);
}
}
