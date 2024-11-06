

using System;
using System.Text;
using System.Collections.Generic;

using GameAffinityGen.ApplicationCore.Exceptions;

using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;


namespace GameAffinityGen.ApplicationCore.CEN.GameAffinity
{
/*
 *      Definition of the class LikeCEN
 *
 */
public partial class LikeCEN
{
private ILikeRepository _ILikeRepository;

public LikeCEN(ILikeRepository _ILikeRepository)
{
        this._ILikeRepository = _ILikeRepository;
}

public ILikeRepository get_ILikeRepository ()
{
        return this._ILikeRepository;
}
}
}
