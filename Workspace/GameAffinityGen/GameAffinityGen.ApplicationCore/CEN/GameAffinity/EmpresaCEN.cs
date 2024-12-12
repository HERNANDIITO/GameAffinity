

using System;
using System.Text;
using System.Collections.Generic;

using GameAffinityGen.ApplicationCore.Exceptions;

using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;


namespace GameAffinityGen.ApplicationCore.CEN.GameAffinity
{
/*
 *      Definition of the class EmpresaCEN
 *
 */
public partial class EmpresaCEN
{
private IEmpresaRepository _IEmpresaRepository;

public EmpresaCEN(IEmpresaRepository _IEmpresaRepository)
{
        this._IEmpresaRepository = _IEmpresaRepository;
}

public IEmpresaRepository get_IEmpresaRepository ()
{
        return this._IEmpresaRepository;
}

public int New_ (string p_nombre, string p_descripcion, float p_nota)
{
        EmpresaEN empresaEN = null;
        int oid;

        //Initialized EmpresaEN
        empresaEN = new EmpresaEN ();
        empresaEN.Nombre = p_nombre;

        empresaEN.Descripcion = p_descripcion;

        empresaEN.Nota = p_nota;



        oid = _IEmpresaRepository.New_ (empresaEN);
        return oid;
}

public void Modify (int p_Empresa_OID, string p_nombre, string p_descripcion, float p_nota)
{
        EmpresaEN empresaEN = null;

        //Initialized EmpresaEN
        empresaEN = new EmpresaEN ();
        empresaEN.Id = p_Empresa_OID;
        empresaEN.Nombre = p_nombre;
        empresaEN.Descripcion = p_descripcion;
        empresaEN.Nota = p_nota;
        //Call to EmpresaRepository

        _IEmpresaRepository.Modify (empresaEN);
}

public void Destroy (int id
                     )
{
        _IEmpresaRepository.Destroy (id);
}

public EmpresaEN GetByOID (int id
                           )
{
        EmpresaEN empresaEN = null;

        empresaEN = _IEmpresaRepository.GetByOID (id);
        return empresaEN;
}

public System.Collections.Generic.IList<EmpresaEN> GetAll (int first, int size)
{
        System.Collections.Generic.IList<EmpresaEN> list = null;

        list = _IEmpresaRepository.GetAll (first, size);
        return list;
}
        
public void AnyadirJuegoDesarrollado (int p_Empresa_OID, System.Collections.Generic.IList<int> p_videojuegos_OIDs)
{
        //Call to EmpresaRepository

        _IEmpresaRepository.AnyadirJuegoDesarrollado (p_Empresa_OID, p_videojuegos_OIDs);
}
public void EilminarJuegoDesarrollado (int p_Empresa_OID, System.Collections.Generic.IList<int> p_videojuegos_OIDs)
{
        //Call to EmpresaRepository

        _IEmpresaRepository.EilminarJuegoDesarrollado (p_Empresa_OID, p_videojuegos_OIDs);
}
public void AnyadirIndividuo (int p_Empresa_OID, System.Collections.Generic.IList<int> p_individuos_OIDs)
{
        //Call to EmpresaRepository

        _IEmpresaRepository.AnyadirIndividuo (p_Empresa_OID, p_individuos_OIDs);
}
public void EliminarIndividuo (int p_Empresa_OID, System.Collections.Generic.IList<int> p_individuos_OIDs)
{
        //Call to EmpresaRepository

        _IEmpresaRepository.EliminarIndividuo (p_Empresa_OID, p_individuos_OIDs);
}
}
}
