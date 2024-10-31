
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


                listaNH.Default_ = lista.Default_;



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


public System.Collections.Generic.IList<ListaEN> Leer_lista (int first, int size)
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

//Sin e: Leer_OID_lista
//Con e: ListaEN
public ListaEN Leer_OID_lista (int id
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
                if (lista.Crea != null) {
                        // Argumento OID y no colección.
                        listaNH
                        .Crea = (GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN)session.Load (typeof(GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN), lista.Crea.Id);

                        listaNH.Crea.Creada
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


                listaNH.Default_ = lista.Default_;

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


                listaNH.Descripcion = lista.Descripcion;


                listaNH.Default_ = lista.Default_;

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

                listaNH.Nombre = lista.Nombre;


                listaNH.Descripcion = lista.Descripcion;


                listaNH.Default_ = lista.Default_;

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
}
}
