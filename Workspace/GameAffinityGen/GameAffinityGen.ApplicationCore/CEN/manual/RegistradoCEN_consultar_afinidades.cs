
using System;
using System.Text;
using System.Collections.Generic;
using GameAffinityGen.ApplicationCore.Exceptions;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;


/*PROTECTED REGION ID(usingGameAffinityGen.ApplicationCore.CEN.GameAffinity_Registrado_consultar_afinidades) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace GameAffinityGen.ApplicationCore.CEN.GameAffinity
{
public partial class RegistradoCEN
{
public void Consultar_afinidades (int p_oid, int user_ID)
{
        /*PROTECTED REGION ID(GameAffinityGen.ApplicationCore.CEN.GameAffinity_Registrado_consultar_afinidades) ENABLED START*/

        // Write here your custom code...

        RegistradoEN yo = this.GetByOID (p_oid);
        RegistradoEN otro = this.GetByOID (user_ID);

        //  compruebo si existe user_ID en caso negativo throw exception y para ejecucion
        if (otro == null) {
                throw new Exception ("ID del usuario no existente");
        }


        //obtengo 2 vars: todas las resenyas del user_ID y todas las mias, y 1 var:  integers del numero de resenyas que tengo (para hacer luego el calculo)
        var misResenyas = yo.Resenya;
        var otroResenyas = otro.Resenya;

        var NumResenyasMias = misResenyas.Count;
        //creo la variable coincidence que es in int en el que contare las coincidencias
        var coincidencias = 0;
        //dos for eachs, uno dentro de otro, en cada for, hago resenya.juego y comparo la cadena con todas las resenya.juego del otro usuario (metiendo un for en otro for). Por cada coincidencia sumo 1 a la var coincidence
        foreach (var miResenya in misResenyas) {
                foreach (var suResenya in otroResenyas) {
                        // Comparo los nombres de los juegos en ambas rese�as
                        if (miResenya.Videojuego.Nombre == suResenya.Videojuego.Nombre) {
                                coincidencias++;
                        }
                }
        }

        //creo var afinidad (int), y divido el numero de resenyas que tengo entre el numero de coincidencias con mi colega, el valor que obtenga es la afinidad
        var afinidad = 0;
        afinidad = NumResenyasMias / coincidencias;

        // que se imprima la afinidad por pantalla o algo asi

        /*PROTECTED REGION END*/
}
}
}
