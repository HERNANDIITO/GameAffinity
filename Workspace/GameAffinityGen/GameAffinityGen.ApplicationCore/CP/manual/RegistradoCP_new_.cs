
using System;
using System.Text;

using System.Collections.Generic;
using GameAffinityGen.ApplicationCore.Exceptions;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;
using GameAffinityGen.ApplicationCore.CEN.GameAffinity;



/*PROTECTED REGION ID(usingGameAffinityGen.ApplicationCore.CP.GameAffinity_Registrado_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace GameAffinityGen.ApplicationCore.CP.GameAffinity
{
public partial class RegistradoCP : GenericBasicCP
{
public GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN New_ (string p_nombre, string p_email, string p_nick, bool p_es_mentor, bool p_notificaciones, String p_contrasenya, string p_img)
{
        /*PROTECTED REGION ID(GameAffinityGen.ApplicationCore.CP.GameAffinity_Registrado_new_) ENABLED START*/


        GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN result = null;

        try
        {
                CPSession.SessionInitializeTransaction ();
                RegistradoCEN   registradoCEN   = new RegistradoCEN(CPSession.UnitRepo.RegistradoRepository);
                ListaCEN        listaCEN        = new ListaCEN(CPSession.UnitRepo.ListaRepository);

                int oid;
                //Initialized RegistradoEN
                RegistradoEN registradoEN;
                registradoEN = new RegistradoEN ();
                registradoEN.Nombre = p_nombre;

                registradoEN.Email = p_email;

                registradoEN.Nick = p_nick;

                registradoEN.Es_mentor = p_es_mentor;

                registradoEN.Notificaciones = p_notificaciones;

                registradoEN.Contrasenya = Utils.Util.GetEncondeMD5 (p_contrasenya);

                registradoEN.Img = p_img;

                oid = registradoCEN.get_IRegistradoRepository ().New_ (registradoEN);

                result = registradoCEN.get_IRegistradoRepository ().ReadOIDDefault (oid);

                int juegosCompletados   = listaCEN.New_(
                    "Juegos completados",
                    "Lista de juegos compeltados",
                    true, oid, "");

                int juegosPendientes = listaCEN.New_(
                    "Juegos pendientes",
                    "Lista de juegos que tienes pensado jugaR",
                    true, oid, "");

                int juegosDroppeados = listaCEN.New_(
                    "Juegos abandonados", 
                    "Lista de juegos que empezaste y no planeas terminar",
                    true, oid, "");

                int juegosValorados = listaCEN.New_(
                    "Juegos valorados",
                    "Lista de juegos que has valorado",
                    true, oid, "");

                int juegosJugando = listaCEN.New_(
                    "Juegos completados",
                    "Lista de juegos que estás jugando ahora mismo",
                    true, oid, "");

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
