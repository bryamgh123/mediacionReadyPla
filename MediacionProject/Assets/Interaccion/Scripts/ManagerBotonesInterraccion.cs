using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReadyPlayerMe.AvatarLoader;
using System.Linq;
using UnityEngine.UI;
using System;
public class ManagerBotonesInterraccion : MonoBehaviour
{

    [Header("Opciones Botones")]
    public GameObject UiMediador;
    public GameObject Ubicacion1;
    public GameObject Ubicacion2;
    public GameObject Boton1; 
    public GameObject Boton2;
    public Text textOp1;
    public Text textOp2;

    [Header("Contadores")]
    public int paquetescorrecto = 0;
    public int paquetesincorrecto = 0;

    [Header("Banderas")]
    bool opcioncorrecta = false;
    bool opcionincorrecta = false;
    

    [Header("Resultados")]
    private int Errores = 0;
    public GameObject UiResultados;
    public Text textResultados;

    [Header("referencias")]
    public ManagerDialogos managerDialogos;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    //estos son los botones que permiten selecionar que pasa en la mediacion
    public void BotonesOpcionDelMediador(int id)
    {
        try
        {
            UiMediador.SetActive(false);
            if (id == 0)
            {
                opcionincorrecta = false;
                opcioncorrecta = true;
                object obtenerParametrosCorrecto = managerDialogos.obtenerParametrosCorrecto();
                managerDialogos.StartCoroutine(managerDialogos.obtenerParametrosCorrecto());
                paquetescorrecto++;
                paquetesincorrecto++;
                managerDialogos.contadoropciones++;
                MostarOpcionesBotones();
                AleatoriosBotones();
            }
            else if (id == 1)
            {
                opcioncorrecta = false;
                opcionincorrecta = true;
                managerDialogos.StartCoroutine(managerDialogos.obtenerParametrosIncorrecto());
                Errores++;
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Error en OpcionDelMediador: " + ex.Message);
        }
    }
    //metodo para cambiar la posicion de las opciones en los botones
    public void AleatoriosBotones()
    {
        Vector3 Posicion1canvas = Ubicacion1.transform.position;
        Vector3 Posicion2canvas = Ubicacion2.transform.position;
        int aleatorio = UnityEngine.Random.Range(0, 2);
        if (aleatorio == 0)
        {
            Boton1.transform.position = Posicion1canvas;
            Boton2.transform.position = Posicion2canvas;
        }
        else
        {
            Boton1.transform.position = Posicion2canvas;
            Boton2.transform.position = Posicion1canvas;
        }
    }
    //Metodo para mostrar el texto en los botones
    public void MostarOpcionesBotones()
    {
        try
        {
            if (managerDialogos.contadoropciones <= managerDialogos.limiteopciones - 1)
            {
                textOp1.text = managerDialogos.OpcionesBuenas[managerDialogos.contadoropciones];
                textOp2.text = managerDialogos.OpcionesMalas[managerDialogos.contadoropciones];
            }
            else
            {
                Debug.Log("No hay mas textos");
                UiMediador.SetActive(false);
                UiResultados.SetActive(true);
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("Error en MostarOpcionesBotones: " + ex.Message);
        }
    }















}
