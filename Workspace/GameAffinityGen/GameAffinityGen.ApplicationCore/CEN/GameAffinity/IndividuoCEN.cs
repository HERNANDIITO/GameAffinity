

using System;
using System.Text;
using System.Collections.Generic;

using GameAffinityGen.ApplicationCore.Exceptions;

using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;


namespace GameAffinityGen.ApplicationCore.CEN.GameAffinity
{
/*
 *      Definition of the class IndividuoCEN
 *
 */
public partial class IndividuoCEN
{
private IIndividuoRepository _IIndividuoRepository;

public IndividuoCEN(IIndividuoRepository _IIndividuoRepository)
{
        this._IIndividuoRepository = _IIndividuoRepository;
}

public IIndividuoRepository get_IIndividuoRepository ()
{
        return this._IIndividuoRepository;
}

public int New_ (string p_nombre, string p_apellido, Nullable<DateTime> p_fechaNac, GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.PaisesEnum p_nacionalidad, GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.RolesEnum p_rol, string p_biografia)
{
        IndividuoEN individuoEN = null;
        int oid;

        //Initialized IndividuoEN
        individuoEN = new IndividuoEN ();
        individuoEN.Nombre = p_nombre;

        individuoEN.Apellido = p_apellido;

        individuoEN.FechaNac = p_fechaNac;

        individuoEN.Nacionalidad = p_nacionalidad;

        individuoEN.Rol = p_rol;

        individuoEN.Biografia = p_biografia;



        oid = _IIndividuoRepository.New_ (individuoEN);
        return oid;
}

public void Modify (int p_Individuo_OID, string p_nombre, string p_apellido, Nullable<DateTime> p_fechaNac, GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.PaisesEnum p_nacionalidad, GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.RolesEnum p_rol, string p_biografia)
{
        IndividuoEN individuoEN = null;

        //Initialized IndividuoEN
        individuoEN = new IndividuoEN ();
        individuoEN.Id = p_Individuo_OID;
        individuoEN.Nombre = p_nombre;
        individuoEN.Apellido = p_apellido;
        individuoEN.FechaNac = p_fechaNac;
        individuoEN.Nacionalidad = p_nacionalidad;
        individuoEN.Rol = p_rol;
        individuoEN.Biografia = p_biografia;
        //Call to IndividuoRepository

        _IIndividuoRepository.Modify (individuoEN);
}

public void Destroy (int id
                     )
{
        _IIndividuoRepository.Destroy (id);
}

public System.Collections.Generic.IList<IndividuoEN> Leer_individuo (int first, int size)
{
        System.Collections.Generic.IList<IndividuoEN> list = null;

        list = _IIndividuoRepository.Leer_individuo (first, size);
        return list;
}
public IndividuoEN Leer_OID_individuo (int id
                                       )
{
        IndividuoEN individuoEN = null;

        individuoEN = _IIndividuoRepository.Leer_OID_individuo (id);
        return individuoEN;
}

public System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN> Leer_por_rol (GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.RolesEnum ? rol)
{
        return _IIndividuoRepository.Leer_por_rol (rol);
}
public System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN> Leer_por_pais (GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.PaisesEnum ? papis)
{
        return _IIndividuoRepository.Leer_por_pais (papis);
}
public void AnyadirAEmpresa (int p_Individuo_OID, System.Collections.Generic.IList<int> p_trabajador_OIDs)
{
        //Call to IndividuoRepository

        _IIndividuoRepository.AnyadirAEmpresa (p_Individuo_OID, p_trabajador_OIDs);
}
public void EliminarDeEmpresa (int p_Individuo_OID, System.Collections.Generic.IList<int> p_trabajador_OIDs)
{
        //Call to IndividuoRepository

        _IIndividuoRepository.EliminarDeEmpresa (p_Individuo_OID, p_trabajador_OIDs);
}
public void AnyadirAJuego (int p_Individuo_OID, System.Collections.Generic.IList<int> p_participe_OIDs)
{
        //Call to IndividuoRepository

        _IIndividuoRepository.AnyadirAJuego (p_Individuo_OID, p_participe_OIDs);
}
public void EilminarDeJuego (int p_Individuo_OID, System.Collections.Generic.IList<int> p_participe_OIDs)
{
        //Call to IndividuoRepository

        _IIndividuoRepository.EilminarDeJuego (p_Individuo_OID, p_participe_OIDs);
}
}
}
