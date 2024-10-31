

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

public void Modify (int p_Resenya_OID, string p_titulo, string p_texto, int p_likes, int p_dislikes)
{
        ResenyaEN resenyaEN = null;

        //Initialized ResenyaEN
        resenyaEN = new ResenyaEN ();
        resenyaEN.Id = p_Resenya_OID;
        resenyaEN.Titulo = p_titulo;
        resenyaEN.Texto = p_texto;
        resenyaEN.Likes = p_likes;
        resenyaEN.Dislikes = p_dislikes;
        //Call to ResenyaRepository

        _IResenyaRepository.Modify (resenyaEN);
}

public void Destroy (int id
                     )
{
        _IResenyaRepository.Destroy (id);
}

public System.Collections.Generic.IList<ResenyaEN> Leer_resenya (int first, int size)
{
        System.Collections.Generic.IList<ResenyaEN> list = null;

        list = _IResenyaRepository.Leer_resenya (first, size);
        return list;
}
public ResenyaEN Leer_OID_resenya (int id
                                   )
{
        ResenyaEN resenyaEN = null;

        resenyaEN = _IResenyaRepository.Leer_OID_resenya (id);
        return resenyaEN;
}

public int New_ (string p_titulo, string p_texto, int p_likes, int p_dislikes, int p_escribe, int p_resenyado)
{
        ResenyaEN resenyaEN = null;
        int oid;

        //Initialized ResenyaEN
        resenyaEN = new ResenyaEN ();
        resenyaEN.Titulo = p_titulo;

        resenyaEN.Texto = p_texto;

        resenyaEN.Likes = p_likes;

        resenyaEN.Dislikes = p_dislikes;


        if (p_escribe != -1) {
                // El argumento p_escribe -> Property escribe es oid = false
                // Lista de oids id
                resenyaEN.Escribe = new GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN ();
                resenyaEN.Escribe.Id = p_escribe;
        }


        if (p_resenyado != -1) {
                // El argumento p_resenyado -> Property resenyado es oid = false
                // Lista de oids id
                resenyaEN.Resenyado = new GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN ();
                resenyaEN.Resenyado.Id = p_resenyado;
        }



        oid = _IResenyaRepository.New_ (resenyaEN);
        return oid;
}
}
}
