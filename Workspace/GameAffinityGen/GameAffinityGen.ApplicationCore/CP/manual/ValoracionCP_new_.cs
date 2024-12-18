
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
public GameAffinityGen.ApplicationCore.EN.GameAffinity.ValoracionEN New_ (int p_nota, int p_autor_valoracion, int p_videojuego_valorado)
{
        /*PROTECTED REGION ID(GameAffinityGen.ApplicationCore.CP.GameAffinity_Valoracion_new_) ENABLED START*/

        GameAffinityGen.ApplicationCore.EN.GameAffinity.ValoracionEN result = null;


        try
        {
                CPSession.SessionInitializeTransaction ();
                ValoracionCEN valoracionCEN = new ValoracionCEN (CPSession.UnitRepo.ValoracionRepository);
                VideojuegoCEN videojuegoCEN = new VideojuegoCEN (CPSession.UnitRepo.VideojuegoRepository);

                VideojuegoEN videojuego = videojuegoCEN.GetByoID (p_videojuego_valorado);

                int oid;
                //Initialized ValoracionEN
                ValoracionEN valoracionEN;
                valoracionEN = new ValoracionEN ();
                valoracionEN.Nota = p_nota;

                if (p_autor_valoracion != -1) {
                        valoracionEN.Autor_valoracion = new GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN ();
                        valoracionEN.Autor_valoracion.Id = p_autor_valoracion;
                }

                if (p_videojuego_valorado != -1) {
                        valoracionEN.Videojuego_valorado = new GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN ();
                        valoracionEN.Videojuego_valorado.Id = p_videojuego_valorado;
                }


                int notaMedia = 0;
                IList<ValoracionEN> listaValoraciones = valoracionCEN.DameValoracionesJuego (p_videojuego_valorado);
                //aqui necesitais una lista de valoraciones de un videojuego. ya que videojuego.Valoracion no es una lista
                if (listaValoraciones.Count > 0) {
                        foreach (ValoracionEN val in listaValoraciones) {
                                notaMedia += val.Nota;
                        }
                        notaMedia += p_nota; // A�adir la nueva nota
                        notaMedia = notaMedia / (listaValoraciones.Count + 1); // Calcular la media incluyendo la nueva nota
                }
                else{
                        notaMedia = p_nota;
                }

                videojuego.Nota_media = notaMedia;

                oid = valoracionCEN.get_IValoracionRepository ().New_ (valoracionEN);
                result = valoracionCEN.get_IValoracionRepository ().ReadOIDDefault (oid);
                videojuegoCEN.get_IVideojuegoRepository ().ModifyDefault (videojuego);

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
