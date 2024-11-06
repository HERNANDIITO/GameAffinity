
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
 * Clase Empresa:
 *
 */

namespace GameAffinityGen.Infraestructure.Repository.GameAffinity
{
public partial class EmpresaRepository : BasicRepository, IEmpresaRepository
{
public EmpresaRepository() : base ()
{
}


public EmpresaRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public EmpresaEN ReadOIDDefault (int id
                                 )
{
        EmpresaEN empresaEN = null;

        try
        {
                SessionInitializeTransaction ();
                empresaEN = (EmpresaEN)session.Get (typeof(EmpresaNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return empresaEN;
}

public System.Collections.Generic.IList<EmpresaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<EmpresaEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(EmpresaNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<EmpresaEN>();
                        else
                                result = session.CreateCriteria (typeof(EmpresaNH)).List<EmpresaEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in EmpresaRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (EmpresaEN empresa)
{
        try
        {
                SessionInitializeTransaction ();
                EmpresaNH empresaNH = (EmpresaNH)session.Load (typeof(EmpresaNH), empresa.Id);

                empresaNH.Nombre = empresa.Nombre;


                empresaNH.Descripcion = empresa.Descripcion;


                empresaNH.Nota = empresa.Nota;



                session.Update (empresaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in EmpresaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (EmpresaEN empresa)
{
        EmpresaNH empresaNH = new EmpresaNH (empresa);

        try
        {
                SessionInitializeTransaction ();

                session.Save (empresaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in EmpresaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return empresaNH.Id;
}

public void Modify (EmpresaEN empresa)
{
        try
        {
                SessionInitializeTransaction ();
                EmpresaNH empresaNH = (EmpresaNH)session.Load (typeof(EmpresaNH), empresa.Id);

                empresaNH.Nombre = empresa.Nombre;


                empresaNH.Descripcion = empresa.Descripcion;


                empresaNH.Nota = empresa.Nota;

                session.Update (empresaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in EmpresaRepository.", ex);
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
                EmpresaNH empresaNH = (EmpresaNH)session.Load (typeof(EmpresaNH), id);
                session.Delete (empresaNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in EmpresaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: GetByOID
//Con e: EmpresaEN
public EmpresaEN GetByOID (int id
                           )
{
        EmpresaEN empresaEN = null;

        try
        {
                SessionInitializeTransaction ();
                empresaEN = (EmpresaEN)session.Get (typeof(EmpresaNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return empresaEN;
}

public System.Collections.Generic.IList<EmpresaEN> GetAll (int first, int size)
{
        System.Collections.Generic.IList<EmpresaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(EmpresaNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<EmpresaEN>();
                else
                        result = session.CreateCriteria (typeof(EmpresaNH)).List<EmpresaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in EmpresaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public void AnyadirJuegoDesarrollado (int p_Empresa_OID, System.Collections.Generic.IList<int> p_videojuegos_OIDs)
{
        GameAffinityGen.ApplicationCore.EN.GameAffinity.EmpresaEN empresaEN = null;
        try
        {
                SessionInitializeTransaction ();
                empresaEN = (EmpresaEN)session.Load (typeof(EmpresaNH), p_Empresa_OID);
                GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN videojuegosENAux = null;
                if (empresaEN.Videojuegos == null) {
                        empresaEN.Videojuegos = new System.Collections.Generic.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN>();
                }

                foreach (int item in p_videojuegos_OIDs) {
                        videojuegosENAux = new GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN ();
                        videojuegosENAux = (GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN)session.Load (typeof(GameAffinityGen.Infraestructure.EN.GameAffinity.VideojuegoNH), item);
                        videojuegosENAux.Empresas.Add (empresaEN);

                        empresaEN.Videojuegos.Add (videojuegosENAux);
                }


                session.Update (empresaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in EmpresaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void EilminarJuegoDesarrollado (int p_Empresa_OID, System.Collections.Generic.IList<int> p_videojuegos_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                GameAffinityGen.ApplicationCore.EN.GameAffinity.EmpresaEN empresaEN = null;
                empresaEN = (EmpresaEN)session.Load (typeof(EmpresaNH), p_Empresa_OID);

                GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN videojuegosENAux = null;
                if (empresaEN.Videojuegos != null) {
                        foreach (int item in p_videojuegos_OIDs) {
                                videojuegosENAux = (GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN)session.Load (typeof(GameAffinityGen.Infraestructure.EN.GameAffinity.VideojuegoNH), item);
                                if (empresaEN.Videojuegos.Contains (videojuegosENAux) == true) {
                                        empresaEN.Videojuegos.Remove (videojuegosENAux);
                                        videojuegosENAux.Empresas.Remove (empresaEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_videojuegos_OIDs you are trying to unrelationer, doesn't exist in EmpresaEN");
                        }
                }

                session.Update (empresaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in EmpresaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void AnyadirIndividuo (int p_Empresa_OID, System.Collections.Generic.IList<int> p_individuos_OIDs)
{
        GameAffinityGen.ApplicationCore.EN.GameAffinity.EmpresaEN empresaEN = null;
        try
        {
                SessionInitializeTransaction ();
                empresaEN = (EmpresaEN)session.Load (typeof(EmpresaNH), p_Empresa_OID);
                GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN individuosENAux = null;
                if (empresaEN.Individuos == null) {
                        empresaEN.Individuos = new System.Collections.Generic.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN>();
                }

                foreach (int item in p_individuos_OIDs) {
                        individuosENAux = new GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN ();
                        individuosENAux = (GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN)session.Load (typeof(GameAffinityGen.Infraestructure.EN.GameAffinity.IndividuoNH), item);
                        individuosENAux.Empresas.Add (empresaEN);

                        empresaEN.Individuos.Add (individuosENAux);
                }


                session.Update (empresaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in EmpresaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void EliminarIndividuo (int p_Empresa_OID, System.Collections.Generic.IList<int> p_individuos_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                GameAffinityGen.ApplicationCore.EN.GameAffinity.EmpresaEN empresaEN = null;
                empresaEN = (EmpresaEN)session.Load (typeof(EmpresaNH), p_Empresa_OID);

                GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN individuosENAux = null;
                if (empresaEN.Individuos != null) {
                        foreach (int item in p_individuos_OIDs) {
                                individuosENAux = (GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN)session.Load (typeof(GameAffinityGen.Infraestructure.EN.GameAffinity.IndividuoNH), item);
                                if (empresaEN.Individuos.Contains (individuosENAux) == true) {
                                        empresaEN.Individuos.Remove (individuosENAux);
                                        individuosENAux.Empresas.Remove (empresaEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_individuos_OIDs you are trying to unrelationer, doesn't exist in EmpresaEN");
                        }
                }

                session.Update (empresaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in EmpresaRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
