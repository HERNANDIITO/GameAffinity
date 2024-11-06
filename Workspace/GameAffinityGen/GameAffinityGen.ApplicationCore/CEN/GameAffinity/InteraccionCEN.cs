

using System;
using System.Text;
using System.Collections.Generic;

using GameAffinityGen.ApplicationCore.Exceptions;

using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;


namespace GameAffinityGen.ApplicationCore.CEN.GameAffinity
{
/*
 *      Definition of the class InteraccionCEN
 *
 */
public partial class InteraccionCEN
{
private IInteraccionRepository _IInteraccionRepository;

public InteraccionCEN(IInteraccionRepository _IInteraccionRepository)
{
        this._IInteraccionRepository = _IInteraccionRepository;
}

public IInteraccionRepository get_IInteraccionRepository ()
{
        return this._IInteraccionRepository;
}

public InteraccionEN GetByOID (int id
                               )
{
        InteraccionEN interaccionEN = null;

        interaccionEN = _IInteraccionRepository.GetByOID (id);
        return interaccionEN;
}

public System.Collections.Generic.IList<InteraccionEN> GetAll (int first, int size)
{
        System.Collections.Generic.IList<InteraccionEN> list = null;

        list = _IInteraccionRepository.GetAll (first, size);
        return list;
}
}
}
