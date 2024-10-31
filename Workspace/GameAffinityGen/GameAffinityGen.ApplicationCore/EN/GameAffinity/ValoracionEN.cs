
using System;
// Definición clase ValoracionEN
namespace GameAffinityGen.ApplicationCore.EN.GameAffinity
{
public partial class ValoracionEN
{
/**
 *	Atributo nota
 */
private int nota;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo valora
 */
private GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN valora;



/**
 *	Atributo aportado
 */
private System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN> aportado;






public virtual int Nota {
        get { return nota; } set { nota = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN Valora {
        get { return valora; } set { valora = value;  }
}



public virtual System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN> Aportado {
        get { return aportado; } set { aportado = value;  }
}





public ValoracionEN()
{
        aportado = new System.Collections.Generic.List<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN>();
}



public ValoracionEN(int id, int nota, GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN valora, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN> aportado
                    )
{
        this.init (Id, nota, valora, aportado);
}


public ValoracionEN(ValoracionEN valoracion)
{
        this.init (valoracion.Id, valoracion.Nota, valoracion.Valora, valoracion.Aportado);
}

private void init (int id
                   , int nota, GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN valora, System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN> aportado)
{
        this.Id = id;


        this.Nota = nota;

        this.Valora = valora;

        this.Aportado = aportado;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ValoracionEN t = obj as ValoracionEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
