using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System;

public enum IdPersonaje
{
    Mediador = 0,
    Hombre = 1,
    Mujer = 2
}

[Serializable]
public class ParametrosPaquete
{
    public IdPersonaje TipoMediador;
    public AudioClip ClipPersonaje;
    
    // var parametrosCorrectos = parametrosManager.GetPaqueteCorrecto(managerBotonesInterraccion.paquetescorrecto);

}



