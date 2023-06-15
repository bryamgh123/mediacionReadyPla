using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opciones : MonoBehaviour
{

    public string[] opcionesCorrectas;
    public string[] opcionesIncorrectas;

    public string[] GetOpcionesCorrectas()
    {
        return opcionesCorrectas;
    }

    public string[] GetOpcionesIncorrectas()
    {
        return opcionesIncorrectas;
    }

}

