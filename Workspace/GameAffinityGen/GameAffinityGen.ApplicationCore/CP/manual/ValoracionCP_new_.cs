
using System;
using System.Text;

using System.Collections.Generic;
using GameAffinityGen.ApplicationCore.Exceptions;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;
using GameAffinityGen.ApplicationCore.CEN.GameAffinity;



/*PROTECTED REGION ID(usingGameAffinityGen.ApplicationCore.CP.GameAffinity_Valoracion_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace GameAffinityGen.ApplicationCore.CP.GameAffinity
{
    public partial class ValoracionCP : GenericBasicCP
    {
        public GameAffinityGen.ApplicationCore.EN.GameAffinity.ValoracionEN New_(int p_nota, int p_autor_valoracion, int p_videojuego_valorado)
        {
            /*PROTECTED REGION ID(GameAffinityGen.ApplicationCore.CP.GameAffinity_Valoracion_new_) ENABLED START*/

            GameAffinityGen.ApplicationCore.EN.GameAffinity.ValoracionEN result = null;


            try
            {
                CPSession.SessionInitializeTransaction();
                ValoracionCEN valoracionCEN = new ValoracionCEN(CPSession.UnitRepo.ValoracionRepository);
                VideojuegoCEN videojuegoCEN = new VideojuegoCEN(CPSession.UnitRepo.VideojuegoRepository);

                int oid;
                //Initialized ValoracionEN
                ValoracionEN valoracionEN;
                valoracionEN = new ValoracionEN();
                valoracionEN.Nota = p_nota;

                if (p_autor_valoracion != -1)
                {
                    valoracionEN.Autor_valoracion = new GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN();
                    valoracionEN.Autor_valoracion.Id = p_autor_valoracion;
                }

                VideojuegoEN videojuego = videojuegoCEN.GetByoID(p_videojuego_valorado);

                int notaMedia = 0;
                foreach (ValoracionEN videojuego_valoracion in videojuego.Valoracion)
                {
                    notaMedia += videojuego_valoracion.Nota;
                }

                notaMedia = notaMedia / videojuego.Valoracion.Count;

                videojuegoCEN.get_IVideojuegoRepository().ModifyDefault(videojuego);
                oid = valoracionCEN.get_IValoracionRepository().New_(valoracionEN);
                result = valoracionCEN.get_IValoracionRepository().ReadOIDDefault(oid);



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
            return result;


            /*PROTECTED REGION END*/
        }
    }
}
