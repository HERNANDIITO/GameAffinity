
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
 * Clase Lista:
 *
 */

namespace GameAffinityGen.Infraestructure.Repository.GameAffinity
{
public partial class ListaRepository : BasicRepository, IListaRepository
{
public ListaRepository() : base ()
{
}


public ListaRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public ListaEN ReadOIDDefault (int id
                               )
{
        ListaEN listaEN = null;

        try
        {
                SessionInitializeTransaction ();
                listaEN = (ListaEN)session.Get (typeof(ListaNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return listaEN;
}

public System.Collections.Generic.IList<ListaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ListaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ListaNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<ListaEN>();
                        else
                                result = session.CreateCriteria (typeof(ListaNH)).List<ListaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in ListaRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ListaEN lista)
{
        try
        {
                SessionInitializeTransaction ();
                ListaNH listaNH = (ListaNH)session.Load (typeof(ListaNH), lista.Id);

                listaNH.Nombre = lista.Nombre;


                listaNH.Descripcion = lista.Descripcion;


                listaNH.Por_defecto = lista.Por_defecto;



                session.Update (listaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in ListaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public void AnyadirJuego (int p_Lista_OID, int p_videojuego_oid)
{
        GameAffinityGen.ApplicationCore.EN.GameAffinity.ListaEN listaEN = null;
        try
        {
                SessionInitializeTransaction ();
                listaEN = (ListaEN)session.Load (typeof(ListaNH), p_Lista_OID);
                listaEN.Videojuegos = (GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN)session.Load (typeof(GameAffinityGen.Infraestructure.EN.GameAffinity.VideojuegoNH), p_videojuego_oid);

                listaEN.Videojuegos.Lista.Add (listaEN);



                session.Update (listaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in ListaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<ListaEN> GetAll (int first, int size)
{
        System.Collections.Generic.IList<ListaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ListaNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<ListaEN>();
                else
                        result = session.CreateCriteria (typeof(ListaNH)).List<ListaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in ListaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

//Sin e: GetByOID
//Con e: ListaEN
public ListaEN GetByOID (int id
                         )
{
        ListaEN listaEN = null;

        try
        {
                SessionInitializeTransaction ();
                listaEN = (ListaEN)session.Get (typeof(ListaNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return listaEN;
}

public int New_ (ListaEN lista)
{
        ListaNH listaNH = new ListaNH (lista);

        try
        {
                SessionInitializeTransaction ();
                if (lista.Autor_lista != null) {
                        // Argumento OID y no colección.
                        listaNH
                        .Autor_lista = (GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN)session.Load (typeof(GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN), lista.Autor_lista.Id);

                        listaNH.Autor_lista.Listas
                        .Add (listaNH);
                }

                session.Save (listaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in ListaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return listaNH.Id;
}

public void Modify (ListaEN lista)
{
        try
        {
                SessionInitializeTransaction ();
                ListaNH listaNH = (ListaNH)session.Load (typeof(ListaNH), lista.Id);

                listaNH.Nombre = lista.Nombre;


                listaNH.Descripcion = lista.Descripcion;


                listaNH.Por_defecto = lista.Por_defecto;

                session.Update (listaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in ListaRepository.", ex);
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
                ListaNH listaNH = (ListaNH)session.Load (typeof(ListaNH), id);
                session.Delete (listaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in ListaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Cambiar_nombre (ListaEN lista)
{
        try
        {
                SessionInitializeTransaction ();
                ListaNH listaNH = (ListaNH)session.Load (typeof(ListaNH), lista.Id);

                listaNH.Nombre = lista.Nombre;

                session.Update (listaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in ListaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Cambiar_descripcion (ListaEN lista)
{
        try
        {
                SessionInitializeTransaction ();
                ListaNH listaNH = (ListaNH)session.Load (typeof(ListaNH), lista.Id);

                listaNH.Descripcion = lista.Descripcion;

                session.Update (listaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in ListaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void EliminarJuego (int p_Lista_OID, System.Collections.Generic.IList<int> p_videojuegos_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                GameAffinityGen.ApplicationCore.EN.GameAffinity.ListaEN listaEN = null;
                listaEN = (ListaEN)session.Load (typeof(ListaNH), p_Lista_OID);

                GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN videojuegosENAux = null;
                if (listaEN.Videojuegos != null) {
                        foreach (int item in p_videojuegos_OIDs) {
                                videojuegosENAux = (GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN)session.Load (typeof(GameAffinityGen.Infraestructure.EN.GameAffinity.VideojuegoNH), item);
                                if (listaEN.Videojuegos.Contains (videojuegosENAux) == true) {
                                        listaEN.Videojuegos.Remove (videojuegosENAux);
                                        videojuegosENAux.Lista.Remove (listaEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_videojuegos_OIDs you are trying to unrelationer, doesn't exist in ListaEN");
                        }
                }

                session.Update (listaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in ListaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ListaEN> GetByAutor (int ? user)
{
        System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ListaEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM ListaNH self where FROM ListaNH WHERE autor_lista = :user";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("ListaNHgetByAutorHQL");
                query.SetParameter ("user", user);

                result = query.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.ListaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in ListaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
