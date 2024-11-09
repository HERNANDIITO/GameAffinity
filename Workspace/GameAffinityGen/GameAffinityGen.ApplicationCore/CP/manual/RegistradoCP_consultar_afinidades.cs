
using System;
using System.Text;

using System.Collections.Generic;
using GameAffinityGen.ApplicationCore.Exceptions;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;
using GameAffinityGen.ApplicationCore.CEN.GameAffinity;



/*PROTECTED REGION ID(usingGameAffinityGen.ApplicationCore.CP.GameAffinity_Registrado_consultar_afinidades) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace GameAffinityGen.ApplicationCore.CP.GameAffinity
{
public partial class RegistradoCP : GenericBasicCP
{
public int Consultar_afinidades (int p_oid, int user_ID)
{
        /*PROTECTED REGION ID(GameAffinityGen.ApplicationCore.CP.GameAffinity_Registrado_consultar_afinidades) ENABLED START*/

        RegistradoCEN registradoCEN = null;

        int result = -1;


        try
        {
                CPSession.SessionInitializeTransaction ();
                registradoCEN = new  RegistradoCEN (CPSession.UnitRepo.RegistradoRepository);



                // Write here your custom transaction ...

                throw new NotImplementedException ("Method Consultar_afinidades() not yet implemented.");



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
        return result;


        /*PROTECTED REGION END*/
}
}
}
