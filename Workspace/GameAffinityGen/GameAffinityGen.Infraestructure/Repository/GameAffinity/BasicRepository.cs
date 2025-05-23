using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Exceptions;

using GameAffinityGen.ApplicationCore.Exceptions;
using GameAffinityGen.ApplicationCore.CP.GameAffinity;

namespace GameAffinityGen.Infraestructure.Repository.GameAffinity
{
public class BasicRepository
{
protected ISession session;

protected bool sessionInside;

protected ITransaction tx;

protected BasicRepository()
{
        sessionInside = true;
}

protected BasicRepository(GenericSessionCP sessionAux)
{
        session = (ISession)sessionAux.CurrentSession;
        sessionInside = false;
}

protected void SessionInitializeTransaction ()
{
        if (session == null) {
                session = NHibernateHelper.OpenSession ();
                tx = session.BeginTransaction ();
        }
}

protected void SessionCommit ()
{
        if (sessionInside && session != null)
                tx.Commit ();
}

protected void SessionRollBack ()
{
        if (sessionInside && session != null && session.IsOpen)
                tx.Rollback ();
}

protected void SessionClose ()
{
        if (sessionInside && session != null && session.IsOpen) {
                session.Close ();
                session.Dispose ();
                session = null;
        }
}
}
}
