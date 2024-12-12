

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

public int New_ (string p_nombre, string p_apellido, Nullable<DateTime> p_fechaNac, GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.RolesEnum p_rol, string p_biografia, string p_img, int p_nacionalidad)
{
        IndividuoEN individuoEN = null;
        int oid;

        //Initialized IndividuoEN
        individuoEN = new IndividuoEN ();
        individuoEN.Nombre = p_nombre;

        individuoEN.Apellido = p_apellido;

        individuoEN.FechaNac = p_fechaNac;

        individuoEN.Rol = p_rol;

        individuoEN.Biografia = p_biografia;

        individuoEN.Img = p_img;


        if (p_nacionalidad != -1) {
                // El argumento p_nacionalidad -> Property nacionalidad es oid = false
                // Lista de oids id
                individuoEN.Nacionalidad = new GameAffinityGen.ApplicationCore.EN.GameAffinity.PaisesEN ();
                individuoEN.Nacionalidad.Id = p_nacionalidad;
        }



        oid = _IIndividuoRepository.New_ (individuoEN);
        return oid;
}

public void Modify (int p_Individuo_OID, string p_nombre, string p_apellido, Nullable<DateTime> p_fechaNac, GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.RolesEnum p_rol, string p_biografia, string p_img)
{
        IndividuoEN individuoEN = null;

        //Initialized IndividuoEN
        individuoEN = new IndividuoEN ();
        individuoEN.Id = p_Individuo_OID;
        individuoEN.Nombre = p_nombre;
        individuoEN.Apellido = p_apellido;
        individuoEN.FechaNac = p_fechaNac;
        individuoEN.Rol = p_rol;
        individuoEN.Biografia = p_biografia;
        individuoEN.Img = p_img;
        //Call to IndividuoRepository

        _IIndividuoRepository.Modify (individuoEN);
}

public void Destroy (int id
                     )
{
        _IIndividuoRepository.Destroy (id);
}

public System.Collections.Generic.IList<IndividuoEN> GetAll (int first, int size)
{
        System.Collections.Generic.IList<IndividuoEN> list = null;

        list = _IIndividuoRepository.GetAll (first, size);
        return list;
}
public IndividuoEN GetByOID (int id
                             )
{
        IndividuoEN individuoEN = null;

        individuoEN = _IIndividuoRepository.GetByOID (id);
        return individuoEN;
}

public System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN> GetByRol (GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.RolesEnum ? rol)
{
        return _IIndividuoRepository.GetByRol (rol);
}
public System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN> GetByPais (GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.PaisesEnum ? pais)
{
        return _IIndividuoRepository.GetByPais (pais);
}
public void AnyadirVideojuego (int p_Individuo_OID, System.Collections.Generic.IList<int> p_videojuegos_OIDs)
{
        //Call to IndividuoRepository

        _IIndividuoRepository.AnyadirVideojuego (p_Individuo_OID, p_videojuegos_OIDs);
}
public void EilminarVideojuego (int p_Individuo_OID, System.Collections.Generic.IList<int> p_videojuegos_OIDs)
{
        //Call to IndividuoRepository

        _IIndividuoRepository.EilminarVideojuego (p_Individuo_OID, p_videojuegos_OIDs);
}
}
}
