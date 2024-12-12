
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


EmpresaEN GetByOID (int id
                    );


System.Collections.Generic.IList<EmpresaEN> GetAll (int first, int size);



void AnyadirJuegoDesarrollado (int p_Empresa_OID, System.Collections.Generic.IList<int> p_videojuegos_OIDs);

void EilminarJuegoDesarrollado (int p_Empresa_OID, System.Collections.Generic.IList<int> p_videojuegos_OIDs);

void AnyadirIndividuo (int p_Empresa_OID, System.Collections.Generic.IList<int> p_individuos_OIDs);

void EliminarIndividuo (int p_Empresa_OID, System.Collections.Generic.IList<int> p_individuos_OIDs);
}
}
