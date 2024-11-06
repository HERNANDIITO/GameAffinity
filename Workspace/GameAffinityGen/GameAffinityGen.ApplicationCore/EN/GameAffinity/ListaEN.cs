
using System;
// Definición clase ListaEN
namespace GameAffinityGen.ApplicationCore.EN.GameAffinity
{
    public partial class ListaEN
    {
        /**
         *	Atributo nombre
         */
        private string nombre;



        /**
         *	Atributo descripcion
         */
        private string descripcion;



        /**
         *	Atributo default_
         */
        private bool default_;



        /**
         *	Atributo crea
         */
        private GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN crea;



        /**
         *	Atributo listado
         */
        private System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN> listado;



        /**
         *	Atributo id
         */
        private int id;






        public virtual string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }



        public virtual string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }



        public virtual bool Default_
        {
            get { return default_; }
            set { default_ = value; }
        }



        public virtual GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN Crea
        {
            get { return crea; }
            set { crea = value; }
        }



        public virtual System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN> Listado
        {
            get { return listado; }
            set { listado = value; }
        }



        public virtual int Id
        {
            get { return id; }
            set { id = value; }
        }





        public ListaEN()
        {
            listado = new System.Collections.Generic.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN>();
        }



        public ListaEN(int id, string nombre, string descripcion, bool default_, GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN crea, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN> listado
                       )
        {
            this.init(Id, nombre, descripcion, default_, crea, listado);
        }


        public ListaEN(ListaEN lista)
        {
            this.init(lista.Id, lista.Nombre, lista.Descripcion, lista.Default_, lista.Crea, lista.Listado);
        }

        private void init(int id
                           , string nombre, string descripcion, bool default_, GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN crea, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN> listado)
        {
            this.Id = id;


            this.Nombre = nombre;

            this.Descripcion = descripcion;

            this.Default_ = default_;

            this.Crea = crea;

            this.Listado = listado;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            ListaEN t = obj as ListaEN;
            if (t == null)
                return false;
            if (Id.Equals(t.Id))
                return true;
            else
                return false;
        }

        public override int GetHashCode()
        {
            int hash = 13;

            hash += this.Id.GetHashCode();
            return hash;
        }
    }
}
