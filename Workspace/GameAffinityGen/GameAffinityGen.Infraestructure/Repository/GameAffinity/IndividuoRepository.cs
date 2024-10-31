
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
 * Clase Individuo:
 *
 */

namespace GameAffinityGen.Infraestructure.Repository.GameAffinity
{
public partial class IndividuoRepository : BasicRepository, IIndividuoRepository
{
public IndividuoRepository() : base ()
{
}


public IndividuoRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public IndividuoEN ReadOIDDefault (int id
                                   )
{
        IndividuoEN individuoEN = null;

        try
        {
                SessionInitializeTransaction ();
                individuoEN = (IndividuoEN)session.Get (typeof(IndividuoNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return individuoEN;
}

public System.Collections.Generic.IList<IndividuoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<IndividuoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(IndividuoNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<IndividuoEN>();
                        else
                                result = session.CreateCriteria (typeof(IndividuoNH)).List<IndividuoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in IndividuoRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (IndividuoEN individuo)
{
        try
        {
                SessionInitializeTransaction ();
                IndividuoNH individuoNH = (IndividuoNH)session.Load (typeof(IndividuoNH), individuo.Id);

                individuoNH.Nombre = individuo.Nombre;


                individuoNH.Apellido = individuo.Apellido;


                individuoNH.FechaNac = individuo.FechaNac;


                individuoNH.Nacionalidad = individuo.Nacionalidad;


                individuoNH.Rol = individuo.Rol;


                individuoNH.Biografia = individuo.Biografia;



                session.Update (individuoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in IndividuoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (IndividuoEN individuo)
{
        IndividuoNH individuoNH = new IndividuoNH (individuo);

        try
        {
                SessionInitializeTransaction ();

                session.Save (individuoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in IndividuoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return individuoNH.Id;
}

public void Modify (IndividuoEN individuo)
{
        try
        {
                SessionInitializeTransaction ();
                IndividuoNH individuoNH = (IndividuoNH)session.Load (typeof(IndividuoNH), individuo.Id);

                individuoNH.Nombre = individuo.Nombre;


                individuoNH.Apellido = individuo.Apellido;


                individuoNH.FechaNac = individuo.FechaNac;


                individuoNH.Nacionalidad = individuo.Nacionalidad;


                individuoNH.Rol = individuo.Rol;


                individuoNH.Biografia = individuo.Biografia;

                session.Update (individuoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in IndividuoRepository.", ex);
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
                IndividuoNH individuoNH = (IndividuoNH)session.Load (typeof(IndividuoNH), id);
                session.Delete (individuoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in IndividuoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<IndividuoEN> Leer_individuo (int first, int size)
{
        System.Collections.Generic.IList<IndividuoEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(IndividuoNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<IndividuoEN>();
                else
                        result = session.CreateCriteria (typeof(IndividuoNH)).List<IndividuoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in IndividuoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

//Sin e: Leer_OID_individuo
//Con e: IndividuoEN
public IndividuoEN Leer_OID_individuo (int id
                                       )
{
        IndividuoEN individuoEN = null;

        try
        {
                SessionInitializeTransaction ();
                individuoEN = (IndividuoEN)session.Get (typeof(IndividuoNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return individuoEN;
}

public System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN> Leer_por_rol (GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.RolesEnum ? rol)
{
        System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM IndividuoNH self where FROM IndividuoNH";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("IndividuoNHleer_por_rolHQL");
                query.SetParameter ("rol", rol);

                result = query.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in IndividuoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN> Leer_por_pais (GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.PaisesEnum ? papis)
{
        System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM IndividuoNH self where FROM IndividuoNH";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("IndividuoNHleer_por_paisHQL");
                query.SetParameter ("papis", papis);

                result = query.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in IndividuoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
