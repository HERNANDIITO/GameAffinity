
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
public void EliminarJuego (int p_Lista_OID, System.Collections.Generic.IList<int> p_videojuegos_OIDs)
{
        /*PROTECTED REGION ID(GameAffinityGen.ApplicationCore.CP.GameAffinity_Lista_eliminarJuego) ENABLED START*/

        ListaCEN listaCEN = null;



        try
        {
                CPSession.SessionInitializeTransaction ();
                listaCEN = new  ListaCEN (CPSession.UnitRepo.ListaRepository);







                listaCEN.get_IGameAffinityRepository ().EliminarJuego (p_Lista_OID, p_listado_OIDs);



                CPSession.Commit ();
        }
        catch (Exception ex)
        {
                CPSession.RollBack ();
                throw ex;
        }
        finally
        {
                CPSession.SessionClose ();
        }


        /*PROTECTED REGION END*/
}
}
}
