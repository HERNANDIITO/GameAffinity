
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
 * Clase Registrado:
 *
 */

namespace GameAffinityGen.Infraestructure.Repository.GameAffinity
{
public partial class RegistradoRepository : BasicRepository, IRegistradoRepository
{
public RegistradoRepository() : base ()
{
}


public RegistradoRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public RegistradoEN ReadOIDDefault (int id
                                    )
{
        RegistradoEN registradoEN = null;

        try
        {
                SessionInitializeTransaction ();
                registradoEN = (RegistradoEN)session.Get (typeof(RegistradoNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return registradoEN;
}

public System.Collections.Generic.IList<RegistradoEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<RegistradoEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(RegistradoNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<RegistradoEN>();
                        else
                                result = session.CreateCriteria (typeof(RegistradoNH)).List<RegistradoEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in RegistradoRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (RegistradoEN registrado)
{
        try
        {
                SessionInitializeTransaction ();
                RegistradoNH registradoNH = (RegistradoNH)session.Load (typeof(RegistradoNH), registrado.Id);

                registradoNH.Nombre = registrado.Nombre;


                registradoNH.Email = registrado.Email;


                registradoNH.Nick = registrado.Nick;


                registradoNH.Es_mentor = registrado.Es_mentor;






                registradoNH.Notificaciones = registrado.Notificaciones;


                registradoNH.Contrasenya = registrado.Contrasenya;



                registradoNH.Img = registrado.Img;

                session.Update (registradoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in RegistradoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public void Seguir_perfiles (int p_Registrado_OID, System.Collections.Generic.IList<int> p_seguidos_OIDs)
{
        GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN registradoEN = null;
        try
        {
                SessionInitializeTransaction ();
                registradoEN = (RegistradoEN)session.Load (typeof(RegistradoNH), p_Registrado_OID);
                GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN seguidosENAux = null;
                if (registradoEN.Seguidos == null) {
                        registradoEN.Seguidos = new System.Collections.Generic.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN>();
                }

                foreach (int item in p_seguidos_OIDs) {
                        seguidosENAux = new GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN ();
                        seguidosENAux = (GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN)session.Load (typeof(GameAffinityGen.Infraestructure.EN.GameAffinity.RegistradoNH), item);

                        registradoEN.Seguidos.Add (seguidosENAux);
                }


                session.Update (registradoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in RegistradoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void Dejar_de_seguir_perfiles (int p_Registrado_OID, System.Collections.Generic.IList<int> p_seguidos_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN registradoEN = null;
                registradoEN = (RegistradoEN)session.Load (typeof(RegistradoNH), p_Registrado_OID);

                GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN seguidosENAux = null;
                if (registradoEN.Seguidos != null) {
                        foreach (int item in p_seguidos_OIDs) {
                                seguidosENAux = (GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN)session.Load (typeof(GameAffinityGen.Infraestructure.EN.GameAffinity.RegistradoNH), item);
                                if (registradoEN.Seguidos.Contains (seguidosENAux) == true) {
                                        registradoEN.Seguidos.Remove (seguidosENAux);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_seguidos_OIDs you are trying to unrelationer, doesn't exist in RegistradoEN");
                        }
                }

                session.Update (registradoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in RegistradoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Alternar_notificaciones (RegistradoEN registrado)
{
        try
        {
                SessionInitializeTransaction ();
                RegistradoNH registradoNH = (RegistradoNH)session.Load (typeof(RegistradoNH), registrado.Id);
                session.Update (registradoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in RegistradoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Aceptar_mentoria (RegistradoEN registrado)
{
        try
        {
                SessionInitializeTransaction ();
                RegistradoNH registradoNH = (RegistradoNH)session.Load (typeof(RegistradoNH), registrado.Id);
                session.Update (registradoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in RegistradoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public int New_ (RegistradoEN registrado)
{
        RegistradoNH registradoNH = new RegistradoNH (registrado);

        try
        {
                SessionInitializeTransaction ();

                session.Save (registradoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in RegistradoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return registradoNH.Id;
}

public void Modify (RegistradoEN registrado)
{
        try
        {
                SessionInitializeTransaction ();
                RegistradoNH registradoNH = (RegistradoNH)session.Load (typeof(RegistradoNH), registrado.Id);

                registradoNH.Nombre = registrado.Nombre;


                registradoNH.Email = registrado.Email;


                registradoNH.Nick = registrado.Nick;


                registradoNH.Es_mentor = registrado.Es_mentor;


                registradoNH.Notificaciones = registrado.Notificaciones;


                registradoNH.Contrasenya = registrado.Contrasenya;


                registradoNH.Img = registrado.Img;

                session.Update (registradoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in RegistradoRepository.", ex);
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
                RegistradoNH registradoNH = (RegistradoNH)session.Load (typeof(RegistradoNH), id);
                session.Delete (registradoNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in RegistradoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: GetByOID
//Con e: RegistradoEN
public RegistradoEN GetByOID (int id
                              )
{
        RegistradoEN registradoEN = null;

        try
        {
                SessionInitializeTransaction ();
                registradoEN = (RegistradoEN)session.Get (typeof(RegistradoNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return registradoEN;
}

public System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN> GetMentores (bool ? es_mentor)
{
        System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM RegistradoNH self where FROM RegistradoNH WHERE es_mentor = :es_mentor";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("RegistradoNHgetMentoresHQL");
                query.SetParameter ("es_mentor", es_mentor);

                result = query.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in RegistradoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void DarLike (int p_Registrado_OID, System.Collections.Generic.IList<int> p_interaccion_OIDs)
{
        GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN registradoEN = null;
        try
        {
                SessionInitializeTransaction ();
                registradoEN = (RegistradoEN)session.Load (typeof(RegistradoNH), p_Registrado_OID);
                GameAffinityGen.ApplicationCore.EN.GameAffinity.InteraccionEN interaccionENAux = null;
                if (registradoEN.Interaccion == null) {
                        registradoEN.Interaccion = new System.Collections.Generic.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.InteraccionEN>();
                }

                foreach (int item in p_interaccion_OIDs) {
                        interaccionENAux = new GameAffinityGen.ApplicationCore.EN.GameAffinity.InteraccionEN ();
                        interaccionENAux = (GameAffinityGen.ApplicationCore.EN.GameAffinity.InteraccionEN)session.Load (typeof(GameAffinityGen.Infraestructure.EN.GameAffinity.InteraccionNH), item);
                        interaccionENAux.Autor = registradoEN;

                        registradoEN.Interaccion.Add (interaccionENAux);
                }


                session.Update (registradoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in RegistradoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void QuitarLike (int p_Registrado_OID, System.Collections.Generic.IList<int> p_interaccion_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN registradoEN = null;
                registradoEN = (RegistradoEN)session.Load (typeof(RegistradoNH), p_Registrado_OID);

                GameAffinityGen.ApplicationCore.EN.GameAffinity.InteraccionEN interaccionENAux = null;
                if (registradoEN.Interaccion != null) {
                        foreach (int item in p_interaccion_OIDs) {
                                interaccionENAux = (GameAffinityGen.ApplicationCore.EN.GameAffinity.InteraccionEN)session.Load (typeof(GameAffinityGen.Infraestructure.EN.GameAffinity.InteraccionNH), item);
                                if (registradoEN.Interaccion.Contains (interaccionENAux) == true) {
                                        registradoEN.Interaccion.Remove (interaccionENAux);
                                        interaccionENAux.Autor = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_interaccion_OIDs you are trying to unrelationer, doesn't exist in RegistradoEN");
                        }
                }

                session.Update (registradoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in RegistradoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void CrearValoracion (int p_Registrado_OID, System.Collections.Generic.IList<int> p_valoraciones_OIDs)
{
        GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN registradoEN = null;
        try
        {
                SessionInitializeTransaction ();
                registradoEN = (RegistradoEN)session.Load (typeof(RegistradoNH), p_Registrado_OID);
                GameAffinityGen.ApplicationCore.EN.GameAffinity.ValoracionEN valoracionesENAux = null;
                if (registradoEN.Valoraciones == null) {
                        registradoEN.Valoraciones = new System.Collections.Generic.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.ValoracionEN>();
                }

                foreach (int item in p_valoraciones_OIDs) {
                        valoracionesENAux = new GameAffinityGen.ApplicationCore.EN.GameAffinity.ValoracionEN ();
                        valoracionesENAux = (GameAffinityGen.ApplicationCore.EN.GameAffinity.ValoracionEN)session.Load (typeof(GameAffinityGen.Infraestructure.EN.GameAffinity.ValoracionNH), item);
                        valoracionesENAux.Autor_valoracion = registradoEN;

                        registradoEN.Valoraciones.Add (valoracionesENAux);
                }


                session.Update (registradoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in RegistradoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void EliminarValoracion (int p_Registrado_OID, System.Collections.Generic.IList<int> p_valoraciones_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN registradoEN = null;
                registradoEN = (RegistradoEN)session.Load (typeof(RegistradoNH), p_Registrado_OID);

                GameAffinityGen.ApplicationCore.EN.GameAffinity.ValoracionEN valoracionesENAux = null;
                if (registradoEN.Valoraciones != null) {
                        foreach (int item in p_valoraciones_OIDs) {
                                valoracionesENAux = (GameAffinityGen.ApplicationCore.EN.GameAffinity.ValoracionEN)session.Load (typeof(GameAffinityGen.Infraestructure.EN.GameAffinity.ValoracionNH), item);
                                if (registradoEN.Valoraciones.Contains (valoracionesENAux) == true) {
                                        registradoEN.Valoraciones.Remove (valoracionesENAux);
                                        valoracionesENAux.Autor_valoracion = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_valoraciones_OIDs you are trying to unrelationer, doesn't exist in RegistradoEN");
                        }
                }

                session.Update (registradoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in RegistradoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void CrearLista (int p_Registrado_OID, System.Collections.Generic.IList<int> p_listas_OIDs)
{
        GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN registradoEN = null;
        try
        {
                SessionInitializeTransaction ();
                registradoEN = (RegistradoEN)session.Load (typeof(RegistradoNH), p_Registrado_OID);
                GameAffinityGen.ApplicationCore.EN.GameAffinity.ListaEN listasENAux = null;
                if (registradoEN.Listas == null) {
                        registradoEN.Listas = new System.Collections.Generic.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.ListaEN>();
                }

                foreach (int item in p_listas_OIDs) {
                        listasENAux = new GameAffinityGen.ApplicationCore.EN.GameAffinity.ListaEN ();
                        listasENAux = (GameAffinityGen.ApplicationCore.EN.GameAffinity.ListaEN)session.Load (typeof(GameAffinityGen.Infraestructure.EN.GameAffinity.ListaNH), item);
                        listasENAux.Autor_lista = registradoEN;

                        registradoEN.Listas.Add (listasENAux);
                }


                session.Update (registradoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in RegistradoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void EliminarLista (int p_Registrado_OID, System.Collections.Generic.IList<int> p_listas_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN registradoEN = null;
                registradoEN = (RegistradoEN)session.Load (typeof(RegistradoNH), p_Registrado_OID);

                GameAffinityGen.ApplicationCore.EN.GameAffinity.ListaEN listasENAux = null;
                if (registradoEN.Listas != null) {
                        foreach (int item in p_listas_OIDs) {
                                listasENAux = (GameAffinityGen.ApplicationCore.EN.GameAffinity.ListaEN)session.Load (typeof(GameAffinityGen.Infraestructure.EN.GameAffinity.ListaNH), item);
                                if (registradoEN.Listas.Contains (listasENAux) == true) {
                                        registradoEN.Listas.Remove (listasENAux);
                                        listasENAux.Autor_lista = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_listas_OIDs you are trying to unrelationer, doesn't exist in RegistradoEN");
                        }
                }

                session.Update (registradoEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in RegistradoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN GetByEmail (string email)
{
        GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM RegistradoNH self where FROM RegistradoNH WHERE email = :email";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("RegistradoNHgetByEmailHQL");
                query.SetParameter ("email", email);


                result = query.UniqueResult<GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in RegistradoRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
