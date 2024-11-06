
using System;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.CP.GameAffinity;

namespace GameAffinityGen.ApplicationCore.IRepository.GameAffinity
{
    public partial interface IListaRepository
    {
        void setSessionCP(GenericSessionCP session);

        ListaEN ReadOIDDefault(int id
                                );

        void ModifyDefault(ListaEN lista);

        System.Collections.Generic.IList<ListaEN> ReadAllDefault(int first, int size);




        void AnyadirJuego(int p_Lista_OID, System.Collections.Generic.IList<int> p_videojuegos_OIDs, int videojuego_OID);

        System.Collections.Generic.IList<ListaEN> GetAll(int first, int size);


        ListaEN GetByOID(int id
                          );


        int New_(ListaEN lista);

        void Modify(ListaEN lista);


        void Destroy(int id
                      );


        void Cambiar_nombre(ListaEN lista);


        void Cambiar_descripcion(ListaEN lista);


        void EliminarJuego(int p_Lista_OID, System.Collections.Generic.IList<int> p_videojuegos_OIDs, int videojuego_OID);

        System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ListaEN> GetByAutor(int? user);
    }
}
