
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


                individuoNH.Rol = individuo.Rol;


                individuoNH.Biografia = individuo.Biografia;




                individuoNH.Img = individuo.Img;


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
                if (individuo.Nacionalidad != null) {
                        // Argumento OID y no colección.
                        individuoNH
                        .Nacionalidad = (GameAffinityGen.ApplicationCore.EN.GameAffinity.PaisesEN)session.Load (typeof(GameAffinityGen.ApplicationCore.EN.GameAffinity.PaisesEN), individuo.Nacionalidad.Id);

                        individuoNH.Nacionalidad.Individuos_de_nacion
                        .Add (individuoNH);
                }

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


                individuoNH.Rol = individuo.Rol;


                individuoNH.Biografia = individuo.Biografia;


                individuoNH.Img = individuo.Img;

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

public System.Collections.Generic.IList<IndividuoEN> GetAll (int first, int size)
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

//Sin e: GetByOID
//Con e: IndividuoEN
public IndividuoEN GetByOID (int id
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

public System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN> GetByRol (GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.RolesEnum ? rol)
{
        System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM IndividuoNH self where FROM IndividuoNH WHERE rol = :rol";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("IndividuoNHgetByRolHQL");
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
public System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN> GetByPais (GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.PaisesEnum ? pais)
{
        System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM IndividuoNH self where FROM IndividuoNH where nacionalidad = :pais";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("IndividuoNHgetByPaisHQL");
                query.SetParameter ("pais", pais);

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
public void AnyadirVideojuego (int p_Individuo_OID, System.Collections.Generic.IList<int> p_videojuegos_OIDs)
{
        GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN individuoEN = null;
        try
        {
                SessionInitializeTransaction ();
                individuoEN = (IndividuoEN)session.Load (typeof(IndividuoNH), p_Individuo_OID);
                GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN videojuegosENAux = null;
                if (individuoEN.Videojuegos == null) {
                        individuoEN.Videojuegos = new System.Collections.Generic.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN>();
                }

                foreach (int item in p_videojuegos_OIDs) {
                        videojuegosENAux = new GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN ();
                        videojuegosENAux = (GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN)session.Load (typeof(GameAffinityGen.Infraestructure.EN.GameAffinity.VideojuegoNH), item);
                        videojuegosENAux.Individuos.Add (individuoEN);

                        individuoEN.Videojuegos.Add (videojuegosENAux);
                }


                session.Update (individuoEN);
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

public void EilminarVideojuego (int p_Individuo_OID, System.Collections.Generic.IList<int> p_videojuegos_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN individuoEN = null;
                individuoEN = (IndividuoEN)session.Load (typeof(IndividuoNH), p_Individuo_OID);

                GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN videojuegosENAux = null;
                if (individuoEN.Videojuegos != null) {
                        foreach (int item in p_videojuegos_OIDs) {
                                videojuegosENAux = (GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN)session.Load (typeof(GameAffinityGen.Infraestructure.EN.GameAffinity.VideojuegoNH), item);
                                if (individuoEN.Videojuegos.Contains (videojuegosENAux) == true) {
                                        individuoEN.Videojuegos.Remove (videojuegosENAux);
                                        videojuegosENAux.Individuos.Remove (individuoEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_videojuegos_OIDs you are trying to unrelationer, doesn't exist in IndividuoEN");
                        }
                }

                session.Update (individuoEN);
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
}
}
