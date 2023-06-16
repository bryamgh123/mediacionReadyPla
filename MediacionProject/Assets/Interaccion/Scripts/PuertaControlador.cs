using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaControlador : MonoBehaviour
{
[Header("Sonidos puertas")]
    // public GameObject botonAbrir;
    // public GameObject botonCerrar;
    // public GameObject puerta;

    // public float tiempoAbrir = 1f;
    // public float tiempoCerrar = 1f;

    // public float maximoAbrir = 90f;
    // public float maximoCerrar = 0f;

    // private bool puertaAbierta = false;

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         if (!puertaAbierta)
    //         {
    //             botonAbrir.SetActive(true);
    //         }
    //     }
    // }

    // private void OnTriggerExit(Collider other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         botonAbrir.SetActive(false);
    //         botonCerrar.SetActive(false);
    //         CancelInvoke("CerrarPuerta");
    //     }
    // }

    // public void AbrirPuerta()
    // {
    //     if (!puertaAbierta)
    //     {
    //         puertaAbierta = true;
    //         puerta.transform.rotation = Quaternion.Euler(0f, maximoAbrir, 0f);
    //         botonAbrir.SetActive(false);
    //         botonCerrar.SetActive(true);
    //         Invoke("CerrarPuerta", tiempoAbrir);
    //     }
    // }

    // public void CerrarPuerta()
    // {
    //     if (puertaAbierta)
    //     {
    //         puertaAbierta = false;
    //         puerta.transform.rotation = Quaternion.Euler(0f, maximoCerrar, 0f);
    //         botonCerrar.SetActive(false);
    //         botonAbrir.SetActive(true);
    //         Invoke("AbrirPuerta", tiempoCerrar);
    //     }
    // }

    public GameObject puerta;

    public float tiempoAbrir = 1f;
    public float tiempoCerrar = 1f;

    public float maximoAbrir = 90f;
    public float maximoCerrar = 0f;

    private bool puertaAbierta = false;
    private bool jugadorEnTrigger = false;

    private void Update()
    {
        if (jugadorEnTrigger && OVRInput.GetDown(OVRInput.Button.One))
        {
            if (!puertaAbierta)
            {
                AbrirPuerta();
                Debug.Log("Abrir Puerta entro");
            }
            else
            {
                CerrarPuerta();
                Debug.Log("Cerrar puerta entro");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorEnTrigger = true;
            Debug.Log("jugadorEnTrigger Verdadero");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorEnTrigger = false;
            Debug.Log("jugadorEnTrigger Falso");
        }
    }

    private void AbrirPuerta()
    {
        if (!puertaAbierta)
        {
            puertaAbierta = true;
            puerta.transform.rotation = Quaternion.Euler(0f, maximoAbrir, 0f);
            Debug.Log(" puerta rotacion" + puerta);
            //Invoke("CerrarPuerta", tiempoAbrir);
        }
    }

    private void CerrarPuerta()
    {
        if (puertaAbierta)
        {
            puertaAbierta = false;
            puerta.transform.rotation = Quaternion.Euler(0f, maximoCerrar, 0f);
            Debug.Log(" puerta rotacion" + puerta);
            //Invoke("AbrirPuerta", tiempoCerrar);
        }
    }

}
