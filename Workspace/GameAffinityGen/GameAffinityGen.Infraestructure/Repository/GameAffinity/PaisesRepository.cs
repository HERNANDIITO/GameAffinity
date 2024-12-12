
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
 * Clase Paises:
 *
 */

namespace GameAffinityGen.Infraestructure.Repository.GameAffinity
{
public partial class PaisesRepository : BasicRepository, IPaisesRepository
{
public PaisesRepository() : base ()
{
}


public PaisesRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public PaisesEN ReadOIDDefault (int id
                                )
{
        PaisesEN paisesEN = null;

        try
        {
                SessionInitializeTransaction ();
                paisesEN = (PaisesEN)session.Get (typeof(PaisesNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return paisesEN;
}

public System.Collections.Generic.IList<PaisesEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PaisesEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PaisesNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<PaisesEN>();
                        else
                                result = session.CreateCriteria (typeof(PaisesNH)).List<PaisesEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in PaisesRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PaisesEN paises)
{
        try
        {
                SessionInitializeTransaction ();
                PaisesNH paisesNH = (PaisesNH)session.Load (typeof(PaisesNH), paises.Id);

                paisesNH.Nombre = paises.Nombre;


                session.Update (paisesNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in PaisesRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (PaisesEN paises)
{
        PaisesNH paisesNH = new PaisesNH (paises);

        try
        {
                SessionInitializeTransaction ();

                session.Save (paisesNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in PaisesRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return paisesNH.Id;
}

public void Modify (PaisesEN paises)
{
        try
        {
                SessionInitializeTransaction ();
                PaisesNH paisesNH = (PaisesNH)session.Load (typeof(PaisesNH), paises.Id);

                paisesNH.Nombre = paises.Nombre;

                session.Update (paisesNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in PaisesRepository.", ex);
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
                PaisesNH paisesNH = (PaisesNH)session.Load (typeof(PaisesNH), id);
                session.Delete (paisesNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in PaisesRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: PaisesEN
public PaisesEN ReadOID (int id
                         )
{
        PaisesEN paisesEN = null;

        try
        {
                SessionInitializeTransaction ();
                paisesEN = (PaisesEN)session.Get (typeof(PaisesNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return paisesEN;
}

public System.Collections.Generic.IList<PaisesEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PaisesEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PaisesNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<PaisesEN>();
                else
                        result = session.CreateCriteria (typeof(PaisesNH)).List<PaisesEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in PaisesRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
