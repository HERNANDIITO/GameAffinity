
using System;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.CP.GameAffinity;

namespace GameAffinityGen.ApplicationCore.IRepository.GameAffinity
{
public partial interface IIndividuoRepository
{
void setSessionCP (GenericSessionCP session);

IndividuoEN ReadOIDDefault (int id
                            );

void ModifyDefault (IndividuoEN individuo);

System.Collections.Generic.IList<IndividuoEN> ReadAllDefault (int first, int size);



int New_ (IndividuoEN individuo);

void Modify (IndividuoEN individuo);


void Destroy (int id
              );


System.Collections.Generic.IList<IndividuoEN> Leer_individuo (int first, int size);


IndividuoEN Leer_OID_individuo (int id
                                );


System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN> Leer_por_rol (GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.RolesEnum ? rol);


System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN> Leer_por_pais (GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.PaisesEnum ? papis);


void AnyadirAEmpresa (int p_Individuo_OID, System.Collections.Generic.IList<int> p_trabajador_OIDs);

void EliminarDeEmpresa (int p_Individuo_OID, System.Collections.Generic.IList<int> p_trabajador_OIDs);

void AnyadirAJuego (int p_Individuo_OID, System.Collections.Generic.IList<int> p_participe_OIDs);

void EilminarDeJuego (int p_Individuo_OID, System.Collections.Generic.IList<int> p_participe_OIDs);
}
}
