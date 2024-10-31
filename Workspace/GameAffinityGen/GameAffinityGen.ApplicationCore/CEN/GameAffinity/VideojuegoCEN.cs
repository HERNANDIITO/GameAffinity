

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

public int New_ (string p_nombre, string p_descripcion, float p_nota_media, GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.GenerosEnum p_genero, GameAffinityGen.ApplicationCore.EN.GameAffinity.ValoracionEN p_aporta)
{
        VideojuegoEN videojuegoEN = null;
        int oid;

        //Initialized VideojuegoEN
        videojuegoEN = new VideojuegoEN ();
        videojuegoEN.Nombre = p_nombre;

        videojuegoEN.Descripcion = p_descripcion;

        videojuegoEN.Nota_media = p_nota_media;

        videojuegoEN.Genero = p_genero;

        videojuegoEN.Aporta = p_aporta;



        oid = _IVideojuegoRepository.New_ (videojuegoEN);
        return oid;
}

public void Modify (int p_Videojuego_OID, string p_nombre, string p_descripcion, float p_nota_media, GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.GenerosEnum p_genero)
{
        VideojuegoEN videojuegoEN = null;

        //Initialized VideojuegoEN
        videojuegoEN = new VideojuegoEN ();
        videojuegoEN.Id = p_Videojuego_OID;
        videojuegoEN.Nombre = p_nombre;
        videojuegoEN.Descripcion = p_descripcion;
        videojuegoEN.Nota_media = p_nota_media;
        videojuegoEN.Genero = p_genero;
        //Call to VideojuegoRepository

        _IVideojuegoRepository.Modify (videojuegoEN);
}

public void Destroy (int id
                     )
{
        _IVideojuegoRepository.Destroy (id);
}

public VideojuegoEN Leer_OID (int id
                              )
{
        VideojuegoEN videojuegoEN = null;

        videojuegoEN = _IVideojuegoRepository.Leer_OID (id);
        return videojuegoEN;
}

public System.Collections.Generic.IList<VideojuegoEN> Leer (int first, int size)
{
        System.Collections.Generic.IList<VideojuegoEN> list = null;

        list = _IVideojuegoRepository.Leer (first, size);
        return list;
}
public System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN> Leer_por_genero (GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.GenerosEnum ? genero)
{
        return _IVideojuegoRepository.Leer_por_genero (genero);
}
}
}
