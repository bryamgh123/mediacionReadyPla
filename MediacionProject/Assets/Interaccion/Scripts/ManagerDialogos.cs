using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReadyPlayerMe;
using System.Linq;
using UnityEngine.UI;
using System;

public class ManagerDialogos : MonoBehaviour
{
    [Header("Opciones de dialogo")]
    public GameObject AudiosBuenas;
    public GameObject AudiosMalas;
    public GameObject opcionesPreguntas;
    public string[] OpcionesBuenas;
    public string[] OpcionesMalas;
    public int contadoropciones;
    public int limiteopciones;

    [Header("Obtener Parametros")]
    public ParametrosManager parametrosManager;

    [Header("Referencias de avatares")]
    public GameObject[] EspaciosGenerarAvatar = new GameObject[3];
    private AudioClip[] misClips;
    private AudioClip[] misClipsin;
    private VoiceHandler[] misControladoresDeAudio = new VoiceHandler[3];

    [Header("Opciones Botones")]
    public ManagerBotonesInterraccion managerBotonesInterraccion;

    [Header("Opciones animaciones")]
    public Animator[] Animaciones = new Animator[3];
    public Animaciones animaciones;

    [Header("banderas")]
    public bool navfindedialogo = true;
    [Header("para listar personajes y obtener datos")]
    public string[] lista = { "EspacioAvatarMediador", "EspacioAvatar1", "EspacioAvatar2" };
    [Header("Listar Audios")]
    public PaquetesAudios[] listaDatos;

    private void Start()
    {
        managerBotonesInterraccion.UiMediador.SetActive(false);
        managerBotonesInterraccion.AleatoriosBotones();
    }

    // este metodo se usa para obtener la informacion de los audios, avatares y preguntas que se van a usar en la interaccion
    public void ObtenerDatosInteraccion()
    {
        // obtener datos de los avatares
        for (int i = 0; i < lista.Length; i++)
        {
            EspaciosGenerarAvatar[i] = GameObject.Find(lista[i]);
            misControladoresDeAudio[i] = EspaciosGenerarAvatar[i].GetComponentInChildren<VoiceHandler>();
            Animaciones[i] = EspaciosGenerarAvatar[i].GetComponentInChildren<Animator>();

        }

        //recuperar las opciones del gameobjet opciones
        OpcionesBuenas = opcionesPreguntas.GetComponent<Opciones>().opcionesCorrectas;
        OpcionesMalas = opcionesPreguntas.GetComponent<Opciones>().opcionesIncorrectas;
        AudiosLista audioListBuenas = AudiosBuenas.GetComponent<AudiosLista>();
        AudiosLista audioListMalas = AudiosMalas.GetComponent<AudiosLista>();
        // Llenar los arrays de AudioClip
        misClips = audioListBuenas.audioClips.ToArray();
        misClipsin = audioListMalas.audioClips.ToArray();
        // este para llenar el limite
        limiteopciones = Mathf.Min(OpcionesBuenas.Length, OpcionesMalas.Length);
        managerBotonesInterraccion.MostarOpcionesBotones();
        //UiMediador.SetActive(true);
    }

    //reproducir los audios
    public IEnumerator ReproducirClips(AudioClip[] clips, VoiceHandler[] misControladoresDeAudio, int AudioNumero, int indiceAvatar)
    {
        //añadir un tiempo antes variable 
        yield return new WaitForSecondsRealtime(0.5f);
        misControladoresDeAudio[indiceAvatar].PlayAudioClip(clips[AudioNumero]);
        //metodo iniciar animacion
        Asignaranimacion(clips, AudioNumero, indiceAvatar);

    }

    // este metodo para obtener los parametros de la opcion correcta en la otra clase los trae y que corra la rutina
    public IEnumerator obtenerParametrosCorrecto()
    {
        float tiempo = 0;
        var parametrosCorrectos = parametrosManager.GetPaqueteCorrecto(managerBotonesInterraccion.paquetescorrecto);
        if (parametrosCorrectos != null)
        {
            List<Vector2Int> parametros = (List<Vector2Int>)parametrosCorrectos;
            for (int i = 0; i < parametros.Count; i++)
            {
                StartCoroutine(ReproducirClips(misClips, misControladoresDeAudio, parametros[i].x, parametros[i].y));
                tiempo = misClips[parametros[i].x].length;
                yield return new WaitForSecondsRealtime(tiempo);
                //finaliza animacion
                animaciones.DetenerAnimacion(Animaciones[parametros[i].y], "quieto", tiempo);
            }
        }
        managerBotonesInterraccion.UiMediador.SetActive(true);
    }
    //este metodo para obtener los parametros der la opcion incorrecta en la otra clase los trae y que corra la rutina
    public IEnumerator obtenerParametrosIncorrecto()
    {
        float tiempo = 0;
        var parametrosIncorrectos = parametrosManager.GetPaqueteIncorrecto(managerBotonesInterraccion.paquetesincorrecto);
        if (parametrosIncorrectos != null)
        {
            List<Vector2Int> parametros = (List<Vector2Int>)parametrosIncorrectos;
            for (int i = 0; i < parametros.Count; i++)
            {
                StartCoroutine(ReproducirClips(misClipsin, misControladoresDeAudio, parametros[i].x, parametros[i].y));
                tiempo = misClipsin[parametros[i].x].length;
                yield return new WaitForSecondsRealtime(tiempo);
                //finaliza animacion
                animaciones.DetenerAnimacion(Animaciones[parametros[i].y], "quieto", tiempo);
            }
        }
        managerBotonesInterraccion.UiMediador.SetActive(true);
    }

    public void Asignaranimacion(AudioClip[] clips, int AudioNumero, int indiceAvatar)
    {
        float tiempo = 0;
        try
        {
            if (indiceAvatar == 0)
            {
                tiempo = clips[AudioNumero].length;
                int PosicionMediadorAnimacionAleatoria = animaciones.PosicionMediadorAnimacionAleatoria;
                animaciones.ActivarAnimacionMediador(Animaciones[indiceAvatar], animaciones.nombresAnimacionesPareja[PosicionMediadorAnimacionAleatoria], tiempo);
            }
            else
            {
                tiempo = clips[AudioNumero].length;
                int PosicionParejaAnimacionAleatoria = animaciones.PosicionParejaAnimacionAleatoria;
                animaciones.ActivarAnimacionPareja(Animaciones[indiceAvatar], animaciones.nombresAnimacionesPareja[PosicionParejaAnimacionAleatoria], tiempo);
            };
        }
        catch (Exception ex)
        {
            Debug.LogError("Entramos en animacion de respoaldo por erro de id: " + ex.Message);
            tiempo = clips[AudioNumero].length;
            int PosicionMediadorAnimacionAleatoria = animaciones.PosicionMediadorAnimacionAleatoria;
            animaciones.ActivarAnimacionMediador(Animaciones[indiceAvatar], animaciones.nombresAnimacionesPareja[PosicionMediadorAnimacionAleatoria], tiempo);
        };
    }


}
