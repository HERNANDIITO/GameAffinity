

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

public LikeEN GetByOID (int id
                        )
{
        LikeEN likeEN = null;

        likeEN = _ILikeRepository.GetByOID (id);
        return likeEN;
}

public System.Collections.Generic.IList<LikeEN> GetAll (int first, int size)
{
        System.Collections.Generic.IList<LikeEN> list = null;

        list = _ILikeRepository.GetAll (first, size);
        return list;
}
}
}
