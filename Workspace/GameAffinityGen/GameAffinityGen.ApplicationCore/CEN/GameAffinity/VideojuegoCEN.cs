

using System;
using System.Text;
using System.Collections.Generic;

using GameAffinityGen.ApplicationCore.Exceptions;

using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;


namespace GameAffinityGen.ApplicationCore.CEN.GameAffinity
{
/*
 *      Definition of the class VideojuegoCEN
 *
 */
public partial class VideojuegoCEN
{
private IVideojuegoRepository _IVideojuegoRepository;

public VideojuegoCEN(IVideojuegoRepository _IVideojuegoRepository)
{
        this._IVideojuegoRepository = _IVideojuegoRepository;
}

public IVideojuegoRepository get_IVideojuegoRepository ()
{
        return this._IVideojuegoRepository;
}

public int New_ (string p_nombre, string p_descripcion, float p_nota_media, GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.GenerosEnum p_genero, Nullable<DateTime> p_fechaDeLanzamiento, string p_imagen)
{
        VideojuegoEN videojuegoEN = null;
        int oid;

        //Initialized VideojuegoEN
        videojuegoEN = new VideojuegoEN ();
        videojuegoEN.Nombre = p_nombre;

        videojuegoEN.Descripcion = p_descripcion;

        videojuegoEN.Nota_media = p_nota_media;

        videojuegoEN.Genero = p_genero;

        videojuegoEN.FechaDeLanzamiento = p_fechaDeLanzamiento;

        videojuegoEN.Imagen = p_imagen;



        oid = _IVideojuegoRepository.New_ (videojuegoEN);
        return oid;
}

public void Modify (int p_Videojuego_OID, string p_nombre, string p_descripcion, float p_nota_media, GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.GenerosEnum p_genero, Nullable<DateTime> p_fechaDeLanzamiento, string p_imagen)
{
        VideojuegoEN videojuegoEN = null;

        //Initialized VideojuegoEN
        videojuegoEN = new VideojuegoEN ();
        videojuegoEN.Id = p_Videojuego_OID;
        videojuegoEN.Nombre = p_nombre;
        videojuegoEN.Descripcion = p_descripcion;
        videojuegoEN.Nota_media = p_nota_media;
        videojuegoEN.Genero = p_genero;
        videojuegoEN.FechaDeLanzamiento = p_fechaDeLanzamiento;
        videojuegoEN.Imagen = p_imagen;
        //Call to VideojuegoRepository

        _IVideojuegoRepository.Modify (videojuegoEN);
}

public void Destroy (int id
                     )
{
        _IVideojuegoRepository.Destroy (id);
}

public VideojuegoEN GetByoID (int id
                              )
{
        VideojuegoEN videojuegoEN = null;

        videojuegoEN = _IVideojuegoRepository.GetByoID (id);
        return videojuegoEN;
}

public System.Collections.Generic.IList<VideojuegoEN> GetAll (int first, int size)
{
        System.Collections.Generic.IList<VideojuegoEN> list = null;

        list = _IVideojuegoRepository.GetAll (first, size);
        return list;
}
public System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN> GetByGenero (GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.GenerosEnum ? genero)
{
        return _IVideojuegoRepository.GetByGenero (genero);
}
public System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN> GetByEmpresa (int ? empresa_id)
{
        return _IVideojuegoRepository.GetByEmpresa (empresa_id);
}
public System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN> GetByIndividuo (int ? individuo_id)
{
        return _IVideojuegoRepository.GetByIndividuo (individuo_id);
}
public System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN> GetRecienPublicados ()
{
        return _IVideojuegoRepository.GetRecienPublicados ();
}
public System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN> GetPopular ()
{
        return _IVideojuegoRepository.GetPopular ();
}
public System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN> GetLanzamientosProximos ()
{
        return _IVideojuegoRepository.GetLanzamientosProximos ();
}
}
}
