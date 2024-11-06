

using System;
using System.Text;
using System.Collections.Generic;

using GameAffinityGen.ApplicationCore.Exceptions;

using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;


namespace GameAffinityGen.ApplicationCore.CEN.GameAffinity
{
/*
 *      Definition of the class ResenyaCEN
 *
 */
public partial class ResenyaCEN
{
private IResenyaRepository _IResenyaRepository;

public ResenyaCEN(IResenyaRepository _IResenyaRepository)
{
        this._IResenyaRepository = _IResenyaRepository;
}

public IResenyaRepository get_IResenyaRepository ()
{
        return this._IResenyaRepository;
}

public void Modify (int p_Resenya_OID, string p_titulo, string p_texto, int p_likes_contador, int p_dislikes_contador)
{
        ResenyaEN resenyaEN = null;

        //Initialized ResenyaEN
        resenyaEN = new ResenyaEN ();
        resenyaEN.Id = p_Resenya_OID;
        resenyaEN.Titulo = p_titulo;
        resenyaEN.Texto = p_texto;
        resenyaEN.Likes_contador = p_likes_contador;
        resenyaEN.Dislikes_contador = p_dislikes_contador;
        //Call to ResenyaRepository

        _IResenyaRepository.Modify (resenyaEN);
}

public void Destroy (int id
                     )
{
        _IResenyaRepository.Destroy (id);
}

public System.Collections.Generic.IList<ResenyaEN> GetAll (int first, int size)
{
        System.Collections.Generic.IList<ResenyaEN> list = null;

        list = _IResenyaRepository.GetAll (first, size);
        return list;
}
public ResenyaEN GetByOID (int id
                           )
{
        ResenyaEN resenyaEN = null;

        resenyaEN = _IResenyaRepository.GetByOID (id);
        return resenyaEN;
}

public int New_ (string p_titulo, string p_texto, int p_likes_contador, int p_dislikes_contador, int p_autor_resenya, int p_videojuego)
{
        ResenyaEN resenyaEN = null;
        int oid;

        //Initialized ResenyaEN
        resenyaEN = new ResenyaEN ();
        resenyaEN.Titulo = p_titulo;

        resenyaEN.Texto = p_texto;

        resenyaEN.Likes_contador = p_likes_contador;

        resenyaEN.Dislikes_contador = p_dislikes_contador;


        if (p_autor_resenya != -1) {
                // El argumento p_autor_resenya -> Property autor_resenya es oid = false
                // Lista de oids id
                resenyaEN.Autor_resenya = new GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN ();
                resenyaEN.Autor_resenya.Id = p_autor_resenya;
        }


        if (p_videojuego != -1) {
                // El argumento p_videojuego -> Property videojuego es oid = false
                // Lista de oids id
                resenyaEN.Videojuego = new GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN ();
                resenyaEN.Videojuego.Id = p_videojuego;
        }



        oid = _IResenyaRepository.New_ (resenyaEN);
        return oid;
}
}
}
