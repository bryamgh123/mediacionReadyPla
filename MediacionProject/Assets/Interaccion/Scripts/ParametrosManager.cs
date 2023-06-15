
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParametrosManager : MonoBehaviour
{
    private Dictionary<int, List<Vector2Int>> parametrosCorrectos = new Dictionary<int, List<Vector2Int>>();
    private Dictionary<int, List<Vector2Int>> parametrosIncorrectos = new Dictionary<int, List<Vector2Int>>();
    public List<object> ListaParametrosCorrecto;
    public List<object> ListaParametrosIncorrecto;

    private void Start()
    {
        ObtenerParametrosCorrectos();
        ObtenerParametrosIncorrectos();
    }
    //metodo para añadir los parametrosCorrectos y añadirlos en la lista ListaParametrosCorrecto
    private void ObtenerParametrosCorrectos()
    {
        // Audios en orden para parametros Correctos
        parametrosCorrectos.Add(0, new List<Vector2Int> { new Vector2Int(0, 0), new Vector2Int(1, 2), new Vector2Int(2, 1) });
        parametrosCorrectos.Add(1, new List<Vector2Int> { new Vector2Int(3, 0), new Vector2Int(4, 1), new Vector2Int(5, 0), new Vector2Int(6, 1), new Vector2Int(7, 0), new Vector2Int(8, 2) });
        parametrosCorrectos.Add(2, new List<Vector2Int> { new Vector2Int(9, 0), new Vector2Int(10, 1) });
        parametrosCorrectos.Add(3, new List<Vector2Int> { new Vector2Int(11, 0), new Vector2Int(12, 1), new Vector2Int(13, 0), new Vector2Int(14, 2), new Vector2Int(15, 0), new Vector2Int(16, 2) });
        parametrosCorrectos.Add(4, new List<Vector2Int> { new Vector2Int(17, 0), new Vector2Int(18, 1), new Vector2Int(19, 2) });
        parametrosCorrectos.Add(5, new List<Vector2Int> { new Vector2Int(20, 0), new Vector2Int(21, 1), new Vector2Int(23, 0) });
        parametrosCorrectos.Add(6, new List<Vector2Int> { new Vector2Int(24, 2), new Vector2Int(25, 0), new Vector2Int(26, 1), new Vector2Int(27, 0), new Vector2Int(28, 2), new Vector2Int(29, 0), new Vector2Int(30, 1), new Vector2Int(31, 2) });
        
        //lista para llamar a los parametros
        ListaParametrosCorrecto = new List<object>();
        foreach (var item in parametrosCorrectos)
        {
            ListaParametrosCorrecto.Add(item.Value);
        }
    }
    //metodo para añadir los parametrosIncorrectos y añadirlos en la lista ListaParametrosIncorrecto
    private void ObtenerParametrosIncorrectos()
    {
        // Audios en orden para parametros Incorrectos
        parametrosIncorrectos.Add(1, new List<Vector2Int> { });
        parametrosIncorrectos.Add(2, new List<Vector2Int> { new Vector2Int(0, 0), new Vector2Int(1, 1), new Vector2Int(2, 2) });
        parametrosIncorrectos.Add(3, new List<Vector2Int> { new Vector2Int(3, 0), new Vector2Int(4, 1), new Vector2Int(5, 2) });
        parametrosIncorrectos.Add(4, new List<Vector2Int> { new Vector2Int(6, 0), new Vector2Int(7, 1), new Vector2Int(8, 2) });
        parametrosIncorrectos.Add(5, new List<Vector2Int> { new Vector2Int(9, 0), new Vector2Int(10, 1), new Vector2Int(11, 2) });
        parametrosIncorrectos.Add(6, new List<Vector2Int> { new Vector2Int(12, 0), new Vector2Int(13, 1), new Vector2Int(14, 2), new Vector2Int(15, 1) });
        parametrosIncorrectos.Add(7, new List<Vector2Int> { new Vector2Int(16, 0), new Vector2Int(17, 1), new Vector2Int(18, 2) });
        //lista para llamar a los parametros
        ListaParametrosIncorrecto = new List<object>();
        foreach (var item in parametrosIncorrectos)
        {
            ListaParametrosIncorrecto.Add(item.Value);
        }
    }
    //recibe el paqueteCorrecto int y retorna a la otra clase el objeto parametrosCorrectos
    public object GetPaqueteCorrecto(int index)
    {
        if (index >= 0 && index < ListaParametrosCorrecto.Count)
        {
            return ListaParametrosCorrecto[index];
        }
        else
        {
            return null;
        }
    }
    //recibe el paqueteIncorrecto int y retorna a la otra clase el objeto parametrosIncorrectos
    public object GetPaqueteIncorrecto(int index)
    {
        if (index >= 0 && index < ListaParametrosIncorrecto.Count)
        {
            return ListaParametrosIncorrecto[index];
        }
        else
        {
            return null;
        }
    }
}







