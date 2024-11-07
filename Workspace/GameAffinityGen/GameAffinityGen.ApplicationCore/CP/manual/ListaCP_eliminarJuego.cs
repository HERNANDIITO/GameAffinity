
using System;
using System.Text;

using System.Collections.Generic;
using GameAffinityGen.ApplicationCore.Exceptions;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;
using GameAffinityGen.ApplicationCore.CEN.GameAffinity;



/*PROTECTED REGION ID(usingGameAffinityGen.ApplicationCore.CP.GameAffinity_Lista_eliminarJuego) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace GameAffinityGen.ApplicationCore.CP.GameAffinity
{
    public partial class ListaCP : GenericBasicCP
    {
        public void EliminarJuego(int p_Lista_OID, System.Collections.Generic.IList<int> p_videojuegos_OIDs, int videojuego_OID)
        {
            /*PROTECTED REGION ID(GameAffinityGen.ApplicationCore.CP.GameAffinity_Lista_eliminarJuego) ENABLED START*/

            try
            {
                CPSession.SessionInitializeTransaction();
                ListaCEN listaCEN = new ListaCEN(CPSession.UnitRepo.ListaRepository);
                VideojuegoCEN videojuegoCEN = new VideojuegoCEN(CPSession.UnitRepo.VideojuegoRepository);

                VideojuegoEN videojuego = videojuegoCEN.GetByoID(videojuego_OID);
                ListaEN lista = listaCEN.get_IListaRepository().ReadOIDDefault(p_Lista_OID);
                lista.Videojuegos.Remove(videojuego);

                listaCEN.get_IListaRepository().ModifyDefault(lista);

                CPSession.Commit();
            }
            catch (Exception ex)
            {
                CPSession.RollBack();
                throw ex;
            }
            finally
            {
                CPSession.SessionClose();
            }

            /*PROTECTED REGION END*/
        }
    }
}
