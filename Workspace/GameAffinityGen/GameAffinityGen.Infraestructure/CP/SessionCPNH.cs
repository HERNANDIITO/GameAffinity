

using System;
using System.Collections.Generic;
using System.Text;
using GameAffinityGen.ApplicationCore.CP.GameAffinity;
using GameAffinityGen.Infraestructure.Repository.GameAffinity;
using GameAffinityGen.Infraestructure.Repository;
using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;
using NHibernate;

namespace GameAffinityGen.Infraestructure.CP
{
public class SessionCPNHibernate : GenericSessionCP
{
ITransaction tx;

public SessionCPNHibernate(object currentSession)
{
        this.CurrentSession = (ISession)currentSession;
        InsideTransaction = true;
}


public SessionCPNHibernate() : base ()
{
        this.CurrentSession = null;
}
public override void SessionInitializeTransaction ()
{
        if (CurrentSession == null && InsideTransaction) {
                CurrentSession = NHibernateHelper.OpenSession ();
                tx = ((ISession)CurrentSession).BeginTransaction ();
        }
        UnitRepo = new UnitOfWorkRepository (this);
}

public override void SessionInitializeWithoutTransaction ()
{
        if (CurrentSession == null && InsideTransaction) {
                CurrentSession = NHibernateHelper.OpenSession ();
        }
        UnitRepo = new UnitOfWorkRepository (this);
}

public override void Commit ()
{
        if (CurrentSession != null && InsideTransaction)
                tx.Commit ();
}

public override void RollBack ()
{
        if (CurrentSession != null && ((ISession)CurrentSession).IsOpen)
                tx.Rollback ();
}

public override void SessionClose ()
{
        if (CurrentSession != null && ((ISession)CurrentSession).IsOpen && InsideTransaction) {
                ((ISession)CurrentSession).Close ();
                ((ISession)CurrentSession).Dispose ();
                CurrentSession = null;
                tx = null;
                UnitRepo = null;
        }
}
}
}


