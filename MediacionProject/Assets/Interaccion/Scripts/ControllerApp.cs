using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ReadyPlayerMe;


public class ControllerApp : MonoBehaviour
{
    [Header("Ui Seleccionar Caso")]
    public Text txtNombreCaso;
    public Text txtDescripcionCaso;
    public Image imgCaso;
    public Image imgCasoBloqueo;

    public Button btnSiguiente;
    public Button btnAnterior;
    public GameObject listaCasos;
    private List<Casos> tdosloscasos;
    private int ContadorCasos = 0;
    private int limiteCasos;
    private int idCaso;
    private int idCasoFinal;



    [Header("LLamar Avatares ")]
    public GameObject avatar1;
    public GameObject avatar2;
    private NavAvatar navAvatar1;
    private NavAvatar navAvatar2;
    private GameObject EspacioparaAvatar1;
    private GameObject EspacioparaAvatar2;
    [SerializeField] private AvataresSo avataresso0;
    [SerializeField] private AvataresSo avataresso1;
    [SerializeField] private AvataresSo avataresso2;


    [Header("Interracion UI ")]

    public GameObject CanvasSelCaso;
    public GameObject hoja;
    public GameObject UiMediador;
    public GameObject ZonaInteraccion;
    public GameObject Direccion;

    [Header("llamando Metodos")]
    public ZonaJuego zonaJuego;
    public ManagerDialogos managerDialogos;

    [Header("Informacion Mediador")]
    public GameObject infoL;
    public GameObject infoR;

    //falta desacctivarlos en algun lado o de alguna manera 



    // [Header("Resuiltados")]
    // [Header("Enviar info DB")]
    // Script '''   Conectar a Db

    void Start()
    {
        btnAnterior.interactable = false;
        limiteCasos = listaCasos.transform.childCount;
        tdosloscasos = new List<Casos>();
        for (int i = 0; i <= limiteCasos - 1; i++)
        {
            tdosloscasos.Add(listaCasos.transform.GetChild(i).GetComponent<Casos>());
        }
        obtenerCaso();
        ZonaInteraccion.SetActive(false);
        Direccion.SetActive(false);
        infoL.SetActive(true);
        infoR.SetActive(true);
        seleccionarCaso();
    }
    //con este metodo obtengo los casos y los presento apenas aparese el canvas de seleccion de caso
    public void obtenerCaso()
    {
        idCaso = tdosloscasos[ContadorCasos].IdCaso;
        txtNombreCaso.text = tdosloscasos[ContadorCasos].NombreCaso;
        txtDescripcionCaso.text = tdosloscasos[ContadorCasos].DescripcionCaso;
        imgCaso.sprite = tdosloscasos[ContadorCasos].ImagenCaso;
        imgCasoBloqueo.sprite = tdosloscasos[ContadorCasos].ImagenCasoBloqueo;

    }
    //este metodo se ejecuta cuando el jugador presiona el boton siguiente y cambia el caso ++1
    public void BtnAnteriorCaso()
    {
        if (ContadorCasos != 0)
        {
            ContadorCasos--;
            idCaso = tdosloscasos[ContadorCasos].IdCaso;
            txtNombreCaso.text = tdosloscasos[ContadorCasos].NombreCaso;
            txtDescripcionCaso.text = tdosloscasos[ContadorCasos].DescripcionCaso;
            imgCaso.sprite = tdosloscasos[ContadorCasos].ImagenCaso;
            imgCasoBloqueo.sprite = tdosloscasos[ContadorCasos].ImagenCasoBloqueo;

            btnSiguiente.interactable = true;
            if (ContadorCasos == 0)
            {
                btnAnterior.interactable = false;
                btnSiguiente.interactable = true;
            }
        }
    }
    //este metodo se ejecuta cuando el jugador presiona el boton anterior y cambia el caso --1
    public void BtnSigienteCaso()
    {
        if (ContadorCasos != limiteCasos)
        {
            ContadorCasos++;
            idCaso = tdosloscasos[ContadorCasos].IdCaso;
            txtNombreCaso.text = tdosloscasos[ContadorCasos].NombreCaso;
            txtDescripcionCaso.text = tdosloscasos[ContadorCasos].DescripcionCaso;
            imgCaso.sprite = tdosloscasos[ContadorCasos].ImagenCaso;
            imgCasoBloqueo.sprite = tdosloscasos[ContadorCasos].ImagenCasoBloqueo;

            btnAnterior.interactable = true;
            if (ContadorCasos == limiteCasos - 1)
            {
                btnSiguiente.interactable = false;
            }
        }
    }
    // con este boton selecciona el caso e inicia el evento con los sigientes metodos
    //     public void seleccionarCaso()
    //     {
    //         CanvasSelCaso.SetActive(false);
    //         hoja.SetActive(false);
    //         idCasoFinal = idCaso;
    //         StartCoroutine(uime());
    //         Direccion.SetActive(true);
    //     }
    //     // este metodo inicia la rutina y despues de 9 segundos activa el canvas de interaccion
    //     //este es por ahora despues cambiara para que sea mas interactivo pobria ponerlo en 
    //     // el navvar para que cuando llege lo active pero va tarer problemas talves con uina bool 
    //     //ya se vera como se hace
    //     //
    //     //
    //     //
    //     //
    //    IEnumerator uime()
    //     {
    //         IniciarRutina();
    //         yield return new WaitForSeconds(10);
    //         UiMediador.SetActive(true);
    //     }



    public void seleccionarCaso()
    {
        if (CanvasSelCaso != null && hoja != null && Direccion != null && UiMediador != null)
        {
            CanvasSelCaso.SetActive(false);
            hoja.SetActive(false);
            idCasoFinal = idCaso;
            StartCoroutine(uime());
            //cambios
        // IniciarRutina();
            Direccion.SetActive(true);
        }
        else
        {
            Debug.LogError("un objeto no esta asignado.");
        }
    }

    IEnumerator uime()
    {
        IniciarRutina();
        yield return new WaitForSeconds(10);
        if (UiMediador != null)
        {
            UiMediador.SetActive(true);
        }
        else
        {
            Debug.LogError("UiMediador no esta asignado.");
        }
    }




    //este metodo llama a otros metodos de esta clase y de otras para usar los dialogos
    public void IniciarRutina()
    {
        //ObtenerAvatares();
        ObtenerParametrosParaControllerApp();
        navAvatar1.ParametrosNavvar();
        navAvatar2.ParametrosNavvar();
        ZonaInteraccion.SetActive(true);
        managerDialogos.ObtenerDatosInteraccion();
        StartCoroutine(MoverAvatares());
    }
    // este metodo espera 2 segundos y llama al metodo de navvavatr caminarSilla() 
    IEnumerator MoverAvatares()
    {
        yield return new WaitForSeconds(2);
        navAvatar1.caminarSilla();
        navAvatar2.caminarSilla();
    }
    //este metodo es para obtener los parametros y referencias de los avatares una ves que se generen 
    public void ObtenerParametrosParaControllerApp()
    {
        EspacioparaAvatar1 = GameObject.Find("EspacioAvatar1");
        EspacioparaAvatar2 = GameObject.Find("EspacioAvatar2");
        navAvatar1 = EspacioparaAvatar1.GetComponentInChildren<NavAvatar>();
        navAvatar2 = EspacioparaAvatar2.GetComponentInChildren<NavAvatar>();
    }
    // este metodo llama a los avatares segun el id del caso que el usuario selecciono
    public void ObtenerAvatares()
    {
        if (idCasoFinal == 0)
        {
            avatar1 = Instantiate(avataresso0.avatar1, avatar1.transform);
            avatar2 = Instantiate(avataresso0.avatar2, avatar2.transform);
            Debug.Log("Insertando avatares del caso o");
        }
        else if (idCasoFinal == 1)
        {
            avatar1 = Instantiate(avataresso1.avatar1, avatar1.transform);
            avatar2 = Instantiate(avataresso1.avatar2, avatar2.transform);
            Debug.Log("Insertando avatares del caso 1");
        }
        else if (idCasoFinal == 2)
        {
            avatar1 = Instantiate(avataresso2.avatar1, avatar1.transform);
            avatar2 = Instantiate(avataresso2.avatar2, avatar2.transform);
            Debug.Log("Insertando avatares del caso 2");
        }
    }
}
