using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReadyPlayerMe.AvatarLoader;
using System.Linq;
using UnityEngine.UI;

public class Animaciones : MonoBehaviour
{
    [Header("Opciones animaciones")]
    public int PosicionParejaAnimacionAleatoria;
    public int PosicionMediadorAnimacionAleatoria;
    public string[] nombresAnimacionesPareja = { "dialogo1", "dialogo2", "dialogo3", "dialogo4", "dialogo5", "dialogo6", "dialogo7" };
    public string[] nombresAnimacionesMediador = { "dialogo1", "dialogo2", "dialogo3", "dialogo4", "dialogo5", "dialogo6", "dialogo7" };

    [Header("banderas")]
    private bool IniciarAnimando;
    private bool DetenerAnimando;

    [Header("Referencias")]
    public ManagerDialogos managerDialogos;

    [Header("Lookat")]
    public Transform player;

    private void Start()
    {
        DetenerAnimando = true;
        IniciarAnimando = false;
    }
    //animaciones para la pareja
    public void NombreAnimacionPareja()
    {
        PosicionParejaAnimacionAleatoria = UnityEngine.Random.Range(0, 6);
    }
    public void ActivarAnimacionPareja(Animator Animaciones, string nombresAnimacionesPareja, float tiempo)
    {
        IniciarAnimando = true;
        NombreAnimacionPareja();
        Animaciones.CrossFade(nombresAnimacionesPareja, 0.1f);
        // animador.CrossFade(nombreAnimacion, tiempo);
        Debug.Log("animacion " + nombresAnimacionesPareja);
    }


    // animaciones para el mediador
    //mmm innesesario? 
    public void NombreAnimacionMediador()
    {
        PosicionMediadorAnimacionAleatoria = UnityEngine.Random.Range(0, 6);
    }

    public void ActivarAnimacionMediador(Animator Animaciones, string nombresAnimacionesMediador, float tiempo)
    {
        NombreAnimacionMediador();
        Animaciones.CrossFade(nombresAnimacionesMediador, 0.1f);
        Debug.Log("animacion " + nombresAnimacionesMediador);
    }

    //detener todas las animaciones
    public void DetenerAnimacion(Animator Animaciones, string nombreAnimacion, float tiempo)
    {
        DetenerAnimando = true;
        Animaciones.CrossFade("quieto", 0.1f);
    }

    //para animar la cabeza y que miere al jugador


    // void Update()
    // {
    //     // Comprobar si el jugador y el Animator no son nulos
    //     if (player != null && animator != null)
    //     {
    //         animator.SetLookAtPosition(player.position);
    //         animator.SetLookAtWeight(1.0f);
    //     }
    // }








}
