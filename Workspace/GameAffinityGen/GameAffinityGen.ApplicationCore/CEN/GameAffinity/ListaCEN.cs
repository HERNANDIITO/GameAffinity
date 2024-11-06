

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

public void AnyadirJuego (int p_Lista_OID, System.Collections.Generic.IList<int> p_listado_OIDs)
{
        //Call to ListaRepository

        _IListaRepository.AnyadirJuego (p_Lista_OID, p_listado_OIDs);
}
public System.Collections.Generic.IList<ListaEN> Leer_lista (int first, int size)
{
        System.Collections.Generic.IList<ListaEN> list = null;

        list = _IListaRepository.Leer_lista (first, size);
        return list;
}
public ListaEN Leer_OID_lista (int id
                               )
{
        ListaEN listaEN = null;

        listaEN = _IListaRepository.Leer_OID_lista (id);
        return listaEN;
}

public int New_ (string p_nombre, string p_descripcion, bool p_default, int p_crea)
{
        ListaEN listaEN = null;
        int oid;

        //Initialized ListaEN
        listaEN = new ListaEN ();
        listaEN.Nombre = p_nombre;

        listaEN.Descripcion = p_descripcion;

        listaEN.Default_ = p_default;


        if (p_crea != -1) {
                // El argumento p_crea -> Property crea es oid = false
                // Lista de oids id
                listaEN.Crea = new GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN ();
                listaEN.Crea.Id = p_crea;
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

public void EliminarJuego (int p_Lista_OID, System.Collections.Generic.IList<int> p_listado_OIDs)
{
        //Call to ListaRepository

        _IListaRepository.EliminarJuego (p_Lista_OID, p_listado_OIDs);
}
}
}
