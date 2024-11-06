
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
 * Clase Like:
 *
 */

namespace GameAffinityGen.Infraestructure.Repository.GameAffinity
{
public partial class LikeRepository : BasicRepository, ILikeRepository
{
public LikeRepository() : base ()
{
}


public LikeRepository(GenericSessionCP sessionAux) : base (sessionAux)
{
}


public void setSessionCP (GenericSessionCP session)
{
        sessionInside = false;
        this.session = (ISession)session.CurrentSession;
}


public LikeEN ReadOIDDefault (int id
                              )
{
        LikeEN likeEN = null;

        try
        {
                SessionInitializeTransaction ();
                likeEN = (LikeEN)session.Get (typeof(LikeNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return likeEN;
}

public System.Collections.Generic.IList<LikeEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<LikeEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(LikeNH)).
                                         SetFirstResult (first).SetMaxResults (size).List<LikeEN>();
                        else
                                result = session.CreateCriteria (typeof(LikeNH)).List<LikeEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in LikeRepository.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (LikeEN like)
{
        try
        {
                SessionInitializeTransaction ();
                LikeNH likeNH = (LikeNH)session.Load (typeof(LikeNH), like.Id);


                likeNH.Disliked = like.Disliked;


                likeNH.Liked = like.Liked;


                likeNH.Id_resenya = like.Id_resenya;


                session.Update (likeNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in LikeRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public void Modify (LikeEN like)
{
        try
        {
                SessionInitializeTransaction ();
                LikeNH likeNH = (LikeNH)session.Load (typeof(LikeNH), like.Id);

                likeNH.Disliked = like.Disliked;


                likeNH.Liked = like.Liked;


                likeNH.Id_resenya = like.Id_resenya;

                session.Update (likeNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in LikeRepository.", ex);
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
                LikeNH likeNH = (LikeNH)session.Load (typeof(LikeNH), id);
                session.Delete (likeNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in LikeRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public int New_ (LikeEN like)
{
        LikeNH likeNH = new LikeNH (like);

        try
        {
                SessionInitializeTransaction ();
                if (like.Autor != null) {
                        // Argumento OID y no colección.
                        likeNH
                        .Autor = (GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN)session.Load (typeof(GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN), like.Autor.Id);

                        likeNH.Autor.Like
                        .Add (likeNH);
                }
                if (like.Resenya != null) {
                        // Argumento OID y no colección.
                        likeNH
                        .Resenya = (GameAffinityGen.ApplicationCore.EN.GameAffinity.ResenyaEN)session.Load (typeof(GameAffinityGen.ApplicationCore.EN.GameAffinity.ResenyaEN), like.Resenya.Id);

                        likeNH.Resenya.Interacciones
                        .Add (likeNH);
                }

                session.Save (likeNH);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in LikeRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return likeNH.Id;
}

//Sin e: GetByOID
//Con e: LikeEN
public LikeEN GetByOID (int id
                        )
{
        LikeEN likeEN = null;

        try
        {
                SessionInitializeTransaction ();
                likeEN = (LikeEN)session.Get (typeof(LikeNH), id);
                SessionCommit ();
        }

        catch (Exception) {
        }


        finally
        {
                SessionClose ();
        }

        return likeEN;
}

public System.Collections.Generic.IList<LikeEN> GetAll (int first, int size)
{
        System.Collections.Generic.IList<LikeEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(LikeNH)).
                                 SetFirstResult (first).SetMaxResults (size).List<LikeEN>();
                else
                        result = session.CreateCriteria (typeof(LikeNH)).List<LikeEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is GameAffinityGen.ApplicationCore.Exceptions.ModelException)
                        throw;
                else throw new GameAffinityGen.ApplicationCore.Exceptions.DataLayerException ("Error in LikeRepository.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
