
using System;
using System.Text;
using System.Collections.Generic;
using GameAffinityGen.ApplicationCore.Exceptions;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;
using GameAffinityGen.ApplicationCore.CEN.GameAffinity;
using GameAffinityGen.ApplicationCore.Utils;



namespace GameAffinityGen.ApplicationCore.CP.GameAffinity
{
public partial class ListaCP : GenericBasicCP
{
public ListaCP(GenericSessionCP currentSession)
        : base (currentSession)
{
}

public ListaCP(GenericSessionCP currentSession, GenericUnitOfWorkUtils unitUtils)
        : base (currentSession, unitUtils)
{
}
}
}
