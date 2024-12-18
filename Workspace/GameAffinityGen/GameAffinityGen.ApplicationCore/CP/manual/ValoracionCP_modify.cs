
using System;
using System.Text;

using System.Collections.Generic;
using GameAffinityGen.ApplicationCore.Exceptions;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;
using GameAffinityGen.ApplicationCore.CEN.GameAffinity;



/*PROTECTED REGION ID(usingGameAffinityGen.ApplicationCore.CP.GameAffinity_Valoracion_modify) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace GameAffinityGen.ApplicationCore.CP.GameAffinity
{
public partial class ValoracionCP : GenericBasicCP
{
public void Modify (int p_Valoracion_OID, int p_nota)
{
        /*PROTECTED REGION ID(GameAffinityGen.ApplicationCore.CP.GameAffinity_Valoracion_modify) ENABLED START*/

        try
        {
                CPSession.SessionInitializeTransaction ();
                // CEN
                ValoracionCEN valoracionCEN = new ValoracionCEN (CPSession.UnitRepo.ValoracionRepository);
                VideojuegoCEN videojuegoCEN = new VideojuegoCEN (CPSession.UnitRepo.VideojuegoRepository);
                EmpresaCEN empresaCEN = new EmpresaCEN(CPSession.UnitRepo.EmpresaRepository);


                // EN
                ValoracionEN valoracionEN = valoracionCEN.GetByOID (p_Valoracion_OID);
                VideojuegoEN videojuegoEN = videojuegoCEN.GetByoID (valoracionEN.Videojuego_valorado.Id);

                // Cambio de nota
                valoracionEN.Nota = p_nota;

                //recalcular media del videojuego
                float notaMedia = 0;
                IList<ValoracionEN> listaValoraciones = valoracionCEN.DameValoracionesJuego (videojuegoEN.Id);
                foreach (ValoracionEN videojuego_valoracion in videojuegoEN.Valoracion) {
                        notaMedia += videojuego_valoracion.Nota;
                }

                if (videojuegoEN.Valoracion.Count > 0) {
                        notaMedia = notaMedia / videojuegoEN.Valoracion.Count;
                }
                else{
                        notaMedia = p_nota;
                }

                // Sobreescribimos la nota media
                videojuegoEN.Nota_media = (float)Math.Truncate(notaMedia * 100) / 100;


                foreach (var empresa in videojuegoEN.Empresas)
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

                // Aplicamos cambios
                videojuegoCEN.get_IVideojuegoRepository ().ModifyDefault (videojuegoEN);
                valoracionCEN.get_IValoracionRepository ().ModifyDefault (valoracionEN);

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
