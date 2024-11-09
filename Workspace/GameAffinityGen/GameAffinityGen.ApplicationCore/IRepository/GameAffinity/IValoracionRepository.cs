
using System;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.CP.GameAffinity;

namespace GameAffinityGen.ApplicationCore.IRepository.GameAffinity
{
public partial interface IValoracionRepository
{
void setSessionCP (GenericSessionCP session);

ValoracionEN ReadOIDDefault (int id
                             );

void ModifyDefault (ValoracionEN valoracion);

System.Collections.Generic.IList<ValoracionEN> ReadAllDefault (int first, int size);



ValoracionEN GetByOID (int id
                       );


System.Collections.Generic.IList<ValoracionEN> GetAll (int first, int size);


int New_ (ValoracionEN valoracion);

void Modify (ValoracionEN valoracion);


void Destroy (int id
              );


System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ValoracionEN> DameValoracionesJuego (int p_id_juego);


System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ValoracionEN> DameValoracionesUsu (int p_id_usu);
}
}
