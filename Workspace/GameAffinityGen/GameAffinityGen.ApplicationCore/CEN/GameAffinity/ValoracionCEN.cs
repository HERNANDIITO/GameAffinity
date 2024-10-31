

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
public int New_ (int p_nota, int p_valora)
{
        ValoracionEN valoracionEN = null;
        int oid;

        //Initialized ValoracionEN
        valoracionEN = new ValoracionEN ();
        valoracionEN.Nota = p_nota;


        if (p_valora != -1) {
                // El argumento p_valora -> Property valora es oid = false
                // Lista de oids id
                valoracionEN.Valora = new GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN ();
                valoracionEN.Valora.Id = p_valora;
        }



        oid = _IValoracionRepository.New_ (valoracionEN);
        return oid;
}

public void Modify (int p_Valoracion_OID, int p_nota)
{
        ValoracionEN valoracionEN = null;

        //Initialized ValoracionEN
        valoracionEN = new ValoracionEN ();
        valoracionEN.Id = p_Valoracion_OID;
        valoracionEN.Nota = p_nota;
        //Call to ValoracionRepository

        _IValoracionRepository.Modify (valoracionEN);
}

public void Destroy (int id
                     )
{
        _IValoracionRepository.Destroy (id);
}
}
}
