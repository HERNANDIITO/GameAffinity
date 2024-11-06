
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


System.Collections.Generic.IList<IndividuoEN> GetAll (int first, int size);


IndividuoEN GetByOID (int id
                      );


System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN> GetByRol (GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.RolesEnum ? rol);


System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN> GetByPais (GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.PaisesEnum ? pais);


void AnyadirVideojuego (int p_Individuo_OID, System.Collections.Generic.IList<int> p_videojuegos_OIDs);

void EilminarVideojuego (int p_Individuo_OID, System.Collections.Generic.IList<int> p_videojuegos_OIDs);
}
}
