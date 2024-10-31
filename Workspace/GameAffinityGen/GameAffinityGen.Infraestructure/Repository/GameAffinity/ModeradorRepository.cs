
using System;
using System.Text;
using GameAffinityGen.ApplicationCore.CEN.GameAffinity;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.Exceptions;
using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;
using GameAffinityGen.ApplicationCore.CP.GameAffinity;
using GameAffinityGen.Infraestructure.EN.GameAffinity;


/*
 * Clase Moderador:
 *
 */

namespace GameAffinityGen.Infraestructure.Repository.GameAffinity
{
public partial class ModeradorRepository : BasicRepository, IModeradorRepository
{
public ModeradorRepository() : base ()
{
}


public ModeradorRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ModeradorEN ReadOIDDefault (int id
                                   )
{
        ModeradorEN moderadorEN = null;

        try
        {
                SessionInitializeTransaction ();
                moderadorEN = (ModeradorEN)session.Get (typeof(ModeradorNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return moderadorEN;
}

public System.Collections.Generic.IList<ModeradorEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ModeradorEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ModeradorNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ModeradorEN>();
                        else
                                result = session.CreateCriteria (typeof(ModeradorNH)).List<ModeradorEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in ModeradorRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ModeradorEN moderador)
{
        try
        {
                SessionInitializeTransaction ();
                ModeradorNH moderadorNH = (ModeradorNH)session.Load (typeof(ModeradorNH), moderador.Id);
                session.Update (moderadorNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in ModeradorRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (ModeradorEN moderador)
{
        ModeradorNH moderadorNH = new ModeradorNH (moderador);

        try
        {
                SessionInitializeTransaction ();

                session.Save (moderadorNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in ModeradorRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return moderadorNH.Id;
}

public void Modify (ModeradorEN moderador)
{
        try
        {
                SessionInitializeTransaction ();
                ModeradorNH moderadorNH = (ModeradorNH)session.Load (typeof(ModeradorNH), moderador.Id);

                moderadorNH.Nombre = moderador.Nombre;


                moderadorNH.Email = moderador.Email;


                moderadorNH.Nick = moderador.Nick;


                moderadorNH.Es_mentor = moderador.Es_mentor;


                moderadorNH.Notificaciones = moderador.Notificaciones;


                moderadorNH.Contrasenya = moderador.Contrasenya;

                session.Update (moderadorNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in ModeradorRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                ModeradorNH moderadorNH = (ModeradorNH)session.Load (typeof(ModeradorNH), id);
                session.Delete (moderadorNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in ModeradorRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<ModeradorEN> Leer_moderador (int first, int size)
{
        System.Collections.Generic.IList<ModeradorEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ModeradorNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<ModeradorEN>();
                else
                        result = session.CreateCriteria (typeof(ModeradorNH)).List<ModeradorEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in ModeradorRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

//Sin e: Leer_OID_moderador
//Con e: ModeradorEN
public ModeradorEN Leer_OID_moderador (int id
                                       )
{
        ModeradorEN moderadorEN = null;

        try
        {
                SessionInitializeTransaction ();
                moderadorEN = (ModeradorEN)session.Get (typeof(ModeradorNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return moderadorEN;
}
}
}
