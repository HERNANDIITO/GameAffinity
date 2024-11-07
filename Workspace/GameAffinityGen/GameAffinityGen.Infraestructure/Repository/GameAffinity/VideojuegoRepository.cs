
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
 * Clase Videojuego:
 *
 */

namespace GameAffinityGen.Infraestructure.Repository.GameAffinity
{
public partial class VideojuegoRepository : BasicRepository, IVideojuegoRepository
{
public VideojuegoRepository() : base ()
{
}


public VideojuegoRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public VideojuegoEN ReadOIDDefault (int id
                                    )
{
        VideojuegoEN videojuegoEN = null;

        try
        {
                SessionInitializeTransaction ();
                videojuegoEN = (VideojuegoEN)session.Get (typeof(VideojuegoNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return videojuegoEN;
}

public System.Collections.Generic.IList<VideojuegoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<VideojuegoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(VideojuegoNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<VideojuegoEN>();
                        else
                                result = session.CreateCriteria (typeof(VideojuegoNH)).List<VideojuegoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in VideojuegoRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (VideojuegoEN videojuego)
{
        try
        {
                SessionInitializeTransaction ();
                VideojuegoNH videojuegoNH = (VideojuegoNH)session.Load (typeof(VideojuegoNH), videojuego.Id);

                videojuegoNH.Nombre = videojuego.Nombre;


                videojuegoNH.Descripcion = videojuego.Descripcion;


                videojuegoNH.Nota_media = videojuego.Nota_media;


                videojuegoNH.Genero = videojuego.Genero;





                session.Update (videojuegoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in VideojuegoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (VideojuegoEN videojuego)
{
        VideojuegoNH videojuegoNH = new VideojuegoNH (videojuego);

        try
        {
                SessionInitializeTransaction ();

                session.Save (videojuegoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in VideojuegoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return videojuegoNH.Id;
}

public void Modify (VideojuegoEN videojuego)
{
        try
        {
                SessionInitializeTransaction ();
                VideojuegoNH videojuegoNH = (VideojuegoNH)session.Load (typeof(VideojuegoNH), videojuego.Id);

                videojuegoNH.Nombre = videojuego.Nombre;


                videojuegoNH.Descripcion = videojuego.Descripcion;


                videojuegoNH.Nota_media = videojuego.Nota_media;


                videojuegoNH.Genero = videojuego.Genero;

                session.Update (videojuegoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in VideojuegoRepository.", ex);
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
                VideojuegoNH videojuegoNH = (VideojuegoNH)session.Load (typeof(VideojuegoNH), id);
                session.Delete (videojuegoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in VideojuegoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: GetByoID
//Con e: VideojuegoEN
public VideojuegoEN GetByoID (int id
                              )
{
        VideojuegoEN videojuegoEN = null;

        try
        {
                SessionInitializeTransaction ();
                videojuegoEN = (VideojuegoEN)session.Get (typeof(VideojuegoNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return videojuegoEN;
}

public System.Collections.Generic.IList<VideojuegoEN> GetAll (int first, int size)
{
        System.Collections.Generic.IList<VideojuegoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(VideojuegoNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<VideojuegoEN>();
                else
                        result = session.CreateCriteria (typeof(VideojuegoNH)).List<VideojuegoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in VideojuegoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN> GetByGenero (GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.GenerosEnum ? genero)
{
        System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM VideojuegoNH self where FROM VideojuegoNH WHERE genero = :genero";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("VideojuegoNHgetByGeneroHQL");
                query.SetParameter ("genero", genero);

                result = query.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in VideojuegoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN> GetByEmpresa (int ? empresa_id)
{
        System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM VideojuegoNH self where FROM VideojuegoNH";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("VideojuegoNHgetByEmpresaHQL");
                query.SetParameter ("empresa_id", empresa_id);

                result = query.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in VideojuegoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN> GetByIndividuo (int ? individuo_id)
{
        System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM VideojuegoNH self where FROM VideojuegoNH";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("VideojuegoNHgetByIndividuoHQL");
                query.SetParameter ("individuo_id", individuo_id);

                result = query.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in VideojuegoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
