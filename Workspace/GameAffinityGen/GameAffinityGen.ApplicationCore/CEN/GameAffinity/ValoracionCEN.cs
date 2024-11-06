

using System;
using System.Text;
using System.Collections.Generic;

using GameAffinityGen.ApplicationCore.Exceptions;

using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;


namespace GameAffinityGen.ApplicationCore.CEN.GameAffinity
{
/*
 *      Definition of the class ValoracionCEN
 *
 */
public partial class ValoracionCEN
{
private IValoracionRepository _IValoracionRepository;

public ValoracionCEN(IValoracionRepository _IValoracionRepository)
{
        this._IValoracionRepository = _IValoracionRepository;
}

public IValoracionRepository get_IValoracionRepository ()
{
        return this._IValoracionRepository;
}

public ValoracionEN Leer_OID_valoracion (int id
                                         )
{
        ValoracionEN valoracionEN = null;

        valoracionEN = _IValoracionRepository.Leer_OID_valoracion (id);
        return valoracionEN;
}

public System.Collections.Generic.IList<ValoracionEN> Leer_valoracion (int first, int size)
{
        System.Collections.Generic.IList<ValoracionEN> list = null;

        list = _IValoracionRepository.Leer_valoracion (first, size);
        return list;
}
}
}
