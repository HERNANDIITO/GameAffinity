
using System;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.CP.GameAffinity;

namespace GameAffinityGen.ApplicationCore.IRepository.GameAffinity
{
public partial interface IVideojuegoRepository
{
void setSessionCP (GenericSessionCP session);

VideojuegoEN ReadOIDDefault (int id
                             );

void ModifyDefault (VideojuegoEN videojuego);

System.Collections.Generic.IList<VideojuegoEN> ReadAllDefault (int first, int size);



int New_ (VideojuegoEN videojuego);

void Modify (VideojuegoEN videojuego);


void Destroy (int id
              );


VideojuegoEN GetByoID (int id
                       );


System.Collections.Generic.IList<VideojuegoEN> GetAll (int first, int size);


System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN> GetByGenero (GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.GenerosEnum ? genero);
}
}
