
using System;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.CP.GameAffinity;

namespace GameAffinityGen.ApplicationCore.IRepository.GameAffinity
{
public partial interface IEmpresaRepository
{
void setSessionCP (GenericSessionCP session);

EmpresaEN ReadOIDDefault (int id
                          );

void ModifyDefault (EmpresaEN empresa);

System.Collections.Generic.IList<EmpresaEN> ReadAllDefault (int first, int size);



int New_ (EmpresaEN empresa);

void Modify (EmpresaEN empresa);


void Destroy (int id
              );


EmpresaEN Leer_OID_empresa (int id
                            );


System.Collections.Generic.IList<EmpresaEN> Leer_empresa (int first, int size);
}
}
