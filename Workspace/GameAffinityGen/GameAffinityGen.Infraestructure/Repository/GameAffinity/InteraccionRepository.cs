
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
 * Clase Interaccion:
 *
 */

namespace GameAffinityGen.Infraestructure.Repository.GameAffinity
{
public partial class InteraccionRepository : BasicRepository, IInteraccionRepository
{
public InteraccionRepository() : base ()
{
}


public InteraccionRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public InteraccionEN ReadOIDDefault (int id
                                     )
{
        InteraccionEN interaccionEN = null;

        try
        {
                SessionInitializeTransaction ();
                interaccionEN = (InteraccionEN)session.Get (typeof(InteraccionNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return interaccionEN;
}

public System.Collections.Generic.IList<InteraccionEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<InteraccionEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(InteraccionNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<InteraccionEN>();
                        else
                                result = session.CreateCriteria (typeof(InteraccionNH)).List<InteraccionEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in InteraccionRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (InteraccionEN interaccion)
{
        try
        {
                SessionInitializeTransaction ();
                InteraccionNH interaccionNH = (InteraccionNH)session.Load (typeof(InteraccionNH), interaccion.Id);


                interaccionNH.Disliked = interaccion.Disliked;


                interaccionNH.Liked = interaccion.Liked;


                interaccionNH.Id_resenya = interaccion.Id_resenya;


                session.Update (interaccionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in InteraccionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public void Modify (InteraccionEN interaccion)
{
        try
        {
                SessionInitializeTransaction ();
                InteraccionNH interaccionNH = (InteraccionNH)session.Load (typeof(InteraccionNH), interaccion.Id);

                interaccionNH.Disliked = interaccion.Disliked;


                interaccionNH.Liked = interaccion.Liked;


                interaccionNH.Id_resenya = interaccion.Id_resenya;

                session.Update (interaccionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in InteraccionRepository.", ex);
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
                InteraccionNH interaccionNH = (InteraccionNH)session.Load (typeof(InteraccionNH), id);
                session.Delete (interaccionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in InteraccionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public int New_ (InteraccionEN interaccion)
{
        InteraccionNH interaccionNH = new InteraccionNH (interaccion);

        try
        {
                SessionInitializeTransaction ();
                if (interaccion.Autor != null) {
                        // Argumento OID y no colección.
                        interaccionNH
                        .Autor = (GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN)session.Load (typeof(GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN), interaccion.Autor.Id);

                        interaccionNH.Autor.Interaccion
                        .Add (interaccionNH);
                }
                if (interaccion.Resenya != null) {
                        // Argumento OID y no colección.
                        interaccionNH
                        .Resenya = (GameAffinityGen.ApplicationCore.EN.GameAffinity.ResenyaEN)session.Load (typeof(GameAffinityGen.ApplicationCore.EN.GameAffinity.ResenyaEN), interaccion.Resenya.Id);

                        interaccionNH.Resenya.Interacciones
                        .Add (interaccionNH);
                }

                session.Save (interaccionNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in InteraccionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return interaccionNH.Id;
}

//Sin e: GetByOID
//Con e: InteraccionEN
public InteraccionEN GetByOID (int id
                               )
{
        InteraccionEN interaccionEN = null;

        try
        {
                SessionInitializeTransaction ();
                interaccionEN = (InteraccionEN)session.Get (typeof(InteraccionNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return interaccionEN;
}

public System.Collections.Generic.IList<InteraccionEN> GetAll (int first, int size)
{
        System.Collections.Generic.IList<InteraccionEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(InteraccionNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<InteraccionEN>();
                else
                        result = session.CreateCriteria (typeof(InteraccionNH)).List<InteraccionEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in InteraccionRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
