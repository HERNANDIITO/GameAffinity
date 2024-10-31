
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

//Sin e: Leer_OID_empresa
//Con e: EmpresaEN
public EmpresaEN Leer_OID_empresa (int id
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

public System.Collections.Generic.IList<EmpresaEN> Leer_empresa (int first, int size)
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
}
}
