

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

public ValoracionEN GetByOID (int id
                              )
{
        ValoracionEN valoracionEN = null;

        valoracionEN = _IValoracionRepository.GetByOID (id);
        return valoracionEN;
}

public System.Collections.Generic.IList<ValoracionEN> GetAll (int first, int size)
{
        System.Collections.Generic.IList<ValoracionEN> list = null;

        list = _IValoracionRepository.GetAll (first, size);
        return list;
}
public System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ValoracionEN> DameValoracionesJuego (int p_id_juego)
{
        return _IValoracionRepository.DameValoracionesJuego (p_id_juego);
}
public System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ValoracionEN> DameValoracionesUsu (int p_id_usu)
{
        return _IValoracionRepository.DameValoracionesUsu (p_id_usu);
}
}
}
