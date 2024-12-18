
using System;
using System.Text;

using System.Collections.Generic;
using GameAffinityGen.ApplicationCore.Exceptions;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;
using GameAffinityGen.ApplicationCore.CEN.GameAffinity;



/*PROTECTED REGION ID(usingGameAffinityGen.ApplicationCore.CP.GameAffinity_Valoracion_destroy) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace GameAffinityGen.ApplicationCore.CP.GameAffinity
{
public partial class ValoracionCP : GenericBasicCP
{
public void Destroy (int p_Valoracion_OID)
{
        /*PROTECTED REGION ID(GameAffinityGen.ApplicationCore.CP.GameAffinity_Valoracion_destroy) ENABLED START*/

        try
        {
                CPSession.SessionInitializeTransaction ();
                ValoracionCEN valoracionCEN = new ValoracionCEN (CPSession.UnitRepo.ValoracionRepository);
                VideojuegoCEN videojuegoCEN = new VideojuegoCEN (CPSession.UnitRepo.VideojuegoRepository);
                EmpresaCEN empresaCEN = new EmpresaCEN(CPSession.UnitRepo.EmpresaRepository);


                Console.WriteLine ("VALORACION DESTROY ID: " + p_Valoracion_OID);
                ValoracionEN valoracionEN = valoracionCEN.GetByOID (p_Valoracion_OID);
                VideojuegoEN videojuego = videojuegoCEN.GetByoID (valoracionEN.Videojuego_valorado.Id);

                // Recalculamos la nota media
                float notaMedia = 0;
                IList<ValoracionEN> listaValoraciones = valoracionCEN.DameValoracionesJuego (videojuego.Id);
                listaValoraciones.Remove (valoracionEN);

                foreach (ValoracionEN videojuego_valoracion in listaValoraciones) {
                        notaMedia += videojuego_valoracion.Nota;
                }

                if (videojuego.Valoracion.Count > 0) {
                        notaMedia = notaMedia / videojuego.Valoracion.Count;
                }
                else{
                        notaMedia = 0;
                }

                //Sobreescribimos la nota media
                videojuego.Nota_media = (float)Math.Truncate(notaMedia * 100) / 100;


                foreach (var empresa in videojuego.Empresas)
                {
                    float notaTotal = 0;

                    foreach (var juego in empresa.Videojuegos)
                    {
                        notaTotal += juego.Nota_media;
                    }

                    float notaMediaEmpresa = notaTotal / empresa.Videojuegos.Count;
                    empresa.Nota = (float)Math.Truncate(notaMediaEmpresa * 100) / 100; ;

                    empresaCEN.get_IEmpresaRepository().ModifyDefault(empresa);
                }


                //Aplicamos cambios
                videojuegoCEN.get_IVideojuegoRepository ().ModifyDefault (videojuego);
                valoracionCEN.get_IValoracionRepository ().Destroy (p_Valoracion_OID);

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
