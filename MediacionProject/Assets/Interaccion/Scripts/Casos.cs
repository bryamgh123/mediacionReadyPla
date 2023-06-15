using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casos : MonoBehaviour
{
    [SerializeField] private int idCaso;
    [SerializeField] private string nombreCaso;
    [SerializeField] private string descripcionCaso;
    //este es para imagen
    [SerializeField] private Sprite imagenCaso;
    [SerializeField] private Sprite imagenCasoBloqueo;

    public int IdCaso
    {
        get { return idCaso; }
        set { idCaso = value; }
    }
    public string NombreCaso
    {
        get { return nombreCaso; }
        set { nombreCaso = value; }
    }
    public string DescripcionCaso
    {
        get { return descripcionCaso; }
        set { descripcionCaso = value; }
    }
    public Sprite ImagenCaso
    {
        get { return imagenCaso; }
        set { imagenCaso = value; }
    }
     public Sprite ImagenCasoBloqueo
    {
        get { return imagenCasoBloqueo; }
        set { imagenCasoBloqueo = value; }
    }

}
