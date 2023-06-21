using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hojas : MonoBehaviour
{
    public GameObject CanvasSelCaso;
    public GameObject hoja;
    public GameObject ZonaLuz;

    [Header("Ui laser")]
    public GameObject Laser;
    public GameObject TextoLaser;

    private bool playerIngresoInter = false;
    public bool PlayerIngresoEn
    {
        get { return playerIngresoInter; }
        set { playerIngresoInter = value; }
    }
    [Header("Animador")]
    public Animator anime;
    //etse metodo activa cuando el jugador esta dentro de la zona el canvas de caso
    public void activarInteraccion()
    {
        if (playerIngresoInter)
        {
            hoja.SetActive(false);
            CanvasSelCaso.SetActive(true);
        }
        else
        {
            hoja.SetActive(true);
            CanvasSelCaso.SetActive(false);
        }
        ZonaLuz.SetActive(!playerIngresoInter);
    }
    //metodo ontigger para detectar cuando el jugador esta dentro de la zona
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Laser.SetActive(true);
            TextoLaser.SetActive(true);
            playerIngresoInter = true;
            activarInteraccion();
        }
    }
    //metodo ontigger para detectar cuando el jugador sale de la zona
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Laser.SetActive(false);
            TextoLaser.SetActive(false);

            playerIngresoInter = false;
            activarInteraccion();
        }
    }
    void Start()
    {
        hoja.SetActive(true);
        CanvasSelCaso.SetActive(false);
        
        Laser.SetActive(false);
        TextoLaser.SetActive(false);
    }
}








