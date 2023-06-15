using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaJuego : MonoBehaviour
{
    public NavAvatar navAvatar1;
    public NavAvatar navAvatar2;
    private GameObject EspacioparaAvatar1;
    private GameObject EspacioparaAvatar2;
    public GameObject avatarmediador;
    
    public GameObject Direccion;


    private void Start()
    {
        avatarmediador.SetActive(false);

    }
    public void vermediador()
    {
        avatarmediador.SetActive(true);
         Direccion.SetActive(false);

    }
    public void novermediador()
    {
        avatarmediador.SetActive(false); 
        Direccion.SetActive(false);
    }
    private void Update()
    {
        ObtenerParametros();
    }
    // este es para obtener las referencias de los avarates la llamo en el start por que este gameobjet esta 
    // desabilitado y ya apenas lo activo desde ControllerApp.cs se ejecuta el metodo ObtenerParametros()
    public void ObtenerParametros()
    {
        EspacioparaAvatar1 = GameObject.Find("EspacioAvatar1");
        EspacioparaAvatar2 = GameObject.Find("EspacioAvatar2");
        navAvatar1 = EspacioparaAvatar1.GetComponentInChildren<NavAvatar>();
        navAvatar2 = EspacioparaAvatar2.GetComponentInChildren<NavAvatar>();
    }
    //el ontriggerenter se ejecuta cuando el  jugador entra en la zona luminoza y activa las acciones 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            navAvatar1.PlayerIngreso = true;
            navAvatar2.PlayerIngreso = true;
            novermediador();
        }
    }
    //el ontriggerenter se ejecuta cuando el  jugador entra en la zona luminoza y activa las acciones o las desacctiva

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            navAvatar1.PlayerIngreso = false;
            navAvatar2.PlayerIngreso = false;
            vermediador();
        }
    }
}
