

using System;
using System.Text;
using System.Collections.Generic;

using GameAffinityGen.ApplicationCore.Exceptions;

using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;


namespace GameAffinityGen.ApplicationCore.CEN.GameAffinity
{
/*
 *      Definition of the class PaisesCEN
 *
 */
public partial class PaisesCEN
{
private IPaisesRepository _IPaisesRepository;

public PaisesCEN(IPaisesRepository _IPaisesRepository)
{
        this._IPaisesRepository = _IPaisesRepository;
}

public IPaisesRepository get_IPaisesRepository ()
{
        return this._IPaisesRepository;
}

public int New_ (string p_nombre)
{
        PaisesEN paisesEN = null;
        int oid;

        //Initialized PaisesEN
        paisesEN = new PaisesEN ();
        paisesEN.Nombre = p_nombre;



        oid = _IPaisesRepository.New_ (paisesEN);
        return oid;
}

public void Modify (int p_Paises_OID, string p_nombre)
{
        PaisesEN paisesEN = null;

        //Initialized PaisesEN
        paisesEN = new PaisesEN ();
        paisesEN.Id = p_Paises_OID;
        paisesEN.Nombre = p_nombre;
        //Call to PaisesRepository

        _IPaisesRepository.Modify (paisesEN);
}

public void Destroy (int id
                     )
{
        _IPaisesRepository.Destroy (id);
}

public PaisesEN ReadOID (int id
                         )
{
        PaisesEN paisesEN = null;

        paisesEN = _IPaisesRepository.ReadOID (id);
        return paisesEN;
}

public System.Collections.Generic.IList<PaisesEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PaisesEN> list = null;

        list = _IPaisesRepository.ReadAll (first, size);
        return list;
}
}
}
