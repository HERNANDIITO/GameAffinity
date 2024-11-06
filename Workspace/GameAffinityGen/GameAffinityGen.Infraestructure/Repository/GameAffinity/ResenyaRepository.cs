
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
 * Clase Resenya:
 *
 */

namespace GameAffinityGen.Infraestructure.Repository.GameAffinity
{
public partial class ResenyaRepository : BasicRepository, IResenyaRepository
{
public ResenyaRepository() : base ()
{
}


public ResenyaRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ResenyaEN ReadOIDDefault (int id
                                 )
{
        ResenyaEN resenyaEN = null;

        try
        {
                SessionInitializeTransaction ();
                resenyaEN = (ResenyaEN)session.Get (typeof(ResenyaNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return resenyaEN;
}

public System.Collections.Generic.IList<ResenyaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ResenyaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ResenyaNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ResenyaEN>();
                        else
                                result = session.CreateCriteria (typeof(ResenyaNH)).List<ResenyaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in ResenyaRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ResenyaEN resenya)
{
        try
        {
                SessionInitializeTransaction ();
                ResenyaNH resenyaNH = (ResenyaNH)session.Load (typeof(ResenyaNH), resenya.Id);

                resenyaNH.Titulo = resenya.Titulo;


                resenyaNH.Texto = resenya.Texto;


                resenyaNH.Likes_contador = resenya.Likes_contador;


                resenyaNH.Dislikes_contador = resenya.Dislikes_contador;




                session.Update (resenyaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in ResenyaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public void Modify (ResenyaEN resenya)
{
        try
        {
                SessionInitializeTransaction ();
                ResenyaNH resenyaNH = (ResenyaNH)session.Load (typeof(ResenyaNH), resenya.Id);

                resenyaNH.Titulo = resenya.Titulo;


                resenyaNH.Texto = resenya.Texto;


                resenyaNH.Likes_contador = resenya.Likes_contador;


                resenyaNH.Dislikes_contador = resenya.Dislikes_contador;

                session.Update (resenyaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in ResenyaRepository.", ex);
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
                ResenyaNH resenyaNH = (ResenyaNH)session.Load (typeof(ResenyaNH), id);
                session.Delete (resenyaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in ResenyaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<ResenyaEN> GetAll (int first, int size)
{
        System.Collections.Generic.IList<ResenyaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ResenyaNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<ResenyaEN>();
                else
                        result = session.CreateCriteria (typeof(ResenyaNH)).List<ResenyaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in ResenyaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

//Sin e: GetByOID
//Con e: ResenyaEN
public ResenyaEN GetByOID (int id
                           )
{
        ResenyaEN resenyaEN = null;

        try
        {
                SessionInitializeTransaction ();
                resenyaEN = (ResenyaEN)session.Get (typeof(ResenyaNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return resenyaEN;
}

public int New_ (ResenyaEN resenya)
{
        ResenyaNH resenyaNH = new ResenyaNH (resenya);

        try
        {
                SessionInitializeTransaction ();
                if (resenya.Autor_resenya != null) {
                        // Argumento OID y no colección.
                        resenyaNH
                        .Autor_resenya = (GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN)session.Load (typeof(GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN), resenya.Autor_resenya.Id);

                        resenyaNH.Autor_resenya.Resenya
                        .Add (resenyaNH);
                }
                if (resenya.Videojuego != null) {
                        // Argumento OID y no colección.
                        resenyaNH
                        .Videojuego = (GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN)session.Load (typeof(GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN), resenya.Videojuego.Id);

                        resenyaNH.Videojuego.Resenyas
                        .Add (resenyaNH);
                }

                session.Save (resenyaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in ResenyaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return resenyaNH.Id;
}
}
}
