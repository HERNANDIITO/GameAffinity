

using System;
using System.Text;
using System.Collections.Generic;

using GameAffinityGen.ApplicationCore.Exceptions;

using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;


namespace GameAffinityGen.ApplicationCore.CEN.GameAffinity
{
/*
 *      Definition of the class ListaCEN
 *
 */
public partial class ListaCEN
{
private IListaRepository _IListaRepository;

public ListaCEN(IListaRepository _IListaRepository)
{
        this._IListaRepository = _IListaRepository;
}

public IListaRepository get_IListaRepository ()
{
        return this._IListaRepository;
}

public System.Collections.Generic.IList<ListaEN> GetAll (int first, int size)
{
        System.Collections.Generic.IList<ListaEN> list = null;

        list = _IListaRepository.GetAll (first, size);
        return list;
}
public ListaEN GetByOID (int id
                         )
{
        ListaEN listaEN = null;

        listaEN = _IListaRepository.GetByOID (id);
        return listaEN;
}

public int New_ (string p_nombre, string p_descripcion, bool p_default, int p_autor_lista)
{
        ListaEN listaEN = null;
        int oid;

        //Initialized ListaEN
        listaEN = new ListaEN ();
        listaEN.Nombre = p_nombre;

        listaEN.Descripcion = p_descripcion;

        listaEN.Default_ = p_default;


        if (p_autor_lista != -1) {
                // El argumento p_autor_lista -> Property autor_lista es oid = false
                // Lista de oids id
                listaEN.Autor_lista = new GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN ();
                listaEN.Autor_lista.Id = p_autor_lista;
        }



        oid = _IListaRepository.New_ (listaEN);
        return oid;
}

public void Modify (int p_Lista_OID, string p_nombre, string p_descripcion, bool p_default)
{
        ListaEN listaEN = null;

        //Initialized ListaEN
        listaEN = new ListaEN ();
        listaEN.Id = p_Lista_OID;
        listaEN.Nombre = p_nombre;
        listaEN.Descripcion = p_descripcion;
        listaEN.Default_ = p_default;
        //Call to ListaRepository

        _IListaRepository.Modify (listaEN);
}

public void Destroy (int id
                     )
{
        _IListaRepository.Destroy (id);
}

public System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.ListaEN> GetByAutor (int ? user)
{
        return _IListaRepository.GetByAutor (user);
}
}
}
