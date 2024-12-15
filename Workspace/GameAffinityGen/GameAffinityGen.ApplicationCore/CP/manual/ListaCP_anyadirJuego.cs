using System;
using System.Collections.Generic;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.CEN.GameAffinity;

namespace GameAffinityGen.ApplicationCore.CP.GameAffinity
{
    public partial class ListaCP : GenericBasicCP
    {
        public void AnyadirJuego(int p_Lista_OID, IList<int> p_videojuegos_OIDs, int videojuego_OID)
        {
            try
            {
                CPSession.SessionInitializeTransaction();
                ListaCEN listaCEN = new ListaCEN(CPSession.UnitRepo.ListaRepository);

                // Llamar al método AnyadirVideojuego de ListaCEN
                listaCEN.AnyadirVideojuego(p_Lista_OID, new List<int> { videojuego_OID });

                CPSession.Commit();
            }
            catch (Exception ex)
            {
                CPSession.RollBack();
                throw new Exception("Error al añadir el videojuego a la lista: " + ex.Message);
            }
            finally
            {
                CPSession.SessionClose();
            }
        }
    }
}