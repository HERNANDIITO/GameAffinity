
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


System.Collections.Generic.IList<ResenyaEN> GetAll (int first, int size);


ResenyaEN GetByOID (int id
                    );


int New_ (ResenyaEN resenya);
}
}
