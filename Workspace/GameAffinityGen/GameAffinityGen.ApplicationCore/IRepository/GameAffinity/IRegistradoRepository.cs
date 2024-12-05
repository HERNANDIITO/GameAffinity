
using System;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.CP.GameAffinity;

namespace GameAffinityGen.ApplicationCore.IRepository.GameAffinity
{
public partial interface IRegistradoRepository
{
void setSessionCP (GenericSessionCP session);

RegistradoEN ReadOIDDefault (int id
                             );

void ModifyDefault (RegistradoEN registrado);

System.Collections.Generic.IList<RegistradoEN> ReadAllDefault (int first, int size);








void Seguir_perfiles (int p_Registrado_OID, System.Collections.Generic.IList<int> p_seguidos_OIDs);

void Dejar_de_seguir_perfiles (int p_Registrado_OID, System.Collections.Generic.IList<int> p_seguidos_OIDs);

void Alternar_notificaciones (RegistradoEN registrado);


void Aceptar_mentoria (RegistradoEN registrado);


int New_ (RegistradoEN registrado);

void Modify (RegistradoEN registrado);


void Destroy (int id
              );


RegistradoEN GetByOID (int id
                       );

RegistradoEN GetByEmail(string email);


System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN> GetMentores (bool ? es_mentor);


void DarLike (int p_Registrado_OID, System.Collections.Generic.IList<int> p_interaccion_OIDs);

void QuitarLike (int p_Registrado_OID, System.Collections.Generic.IList<int> p_interaccion_OIDs);

void CrearValoracion (int p_Registrado_OID, System.Collections.Generic.IList<int> p_valoraciones_OIDs);

void EliminarValoracion (int p_Registrado_OID, System.Collections.Generic.IList<int> p_valoraciones_OIDs);

void CrearLista (int p_Registrado_OID, System.Collections.Generic.IList<int> p_listas_OIDs);

void EliminarLista (int p_Registrado_OID, System.Collections.Generic.IList<int> p_listas_OIDs);
}
}
