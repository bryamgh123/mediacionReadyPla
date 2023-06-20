using UnityEngine;

public class PuertasAbrir : MonoBehaviour
{
    public Transform puerta;
    public GameObject puerta2;
    public GameObject PuertaAbrir;
    public GameObject PuertaCerrar;
    public float tiempoAbrir = 1f;
    public float tiempoCerrar = 1f;
    public float maximoAbrir;
    public float maximoCerrar;

    private bool puertaAbierta = false;
    private bool jugadorEnTrigger = false;



    private void Start()
    {
        PuertaAbrir.SetActive(false);
        PuertaCerrar.SetActive(false);

    }
    private void Update()
    {
        if (jugadorEnTrigger && OVRInput.GetDown(OVRInput.Button.One))
        {
            if (!puertaAbierta)
            {
                PuertaAbrir.SetActive(false);
                PuertaCerrar.SetActive(true);
                AbrirPuerta();
                Debug.Log("Abrir Puerta");
            }
            else
            {
                PuertaAbrir.SetActive(true);
                PuertaCerrar.SetActive(false);
                CerrarPuerta();
                Debug.Log("Cerrar Puerta");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorEnTrigger = true;

            if (!puertaAbierta)
            {
                PuertaAbrir.SetActive(true);
                PuertaCerrar.SetActive(false);
            }
            else if (puertaAbierta)
            {
                PuertaAbrir.SetActive(false);
                PuertaCerrar.SetActive(true);
            }
            Debug.Log("jugadorEnTrigger Verdadero");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorEnTrigger = false;
            PuertaAbrir.SetActive(false);
            PuertaCerrar.SetActive(false);
            Debug.Log("jugadorEnTrigger Falso");
        }
    }

    private void AbrirPuerta()
    {
        if (!puertaAbierta)
        {
            puertaAbierta = true;
            Quaternion targetRotation = Quaternion.Euler(0f, maximoAbrir, 0f);
            StartCoroutine(RotarPuerta(targetRotation, tiempoAbrir));
        }
    }

    private void CerrarPuerta()
    {
        if (puertaAbierta)
        {
            puertaAbierta = false;
            Quaternion targetRotation = Quaternion.Euler(0f, maximoCerrar, 0f);
            StartCoroutine(RotarPuerta(targetRotation, tiempoCerrar));
        }
    }

    private System.Collections.IEnumerator RotarPuerta(Quaternion targetRotation, float duration)
    {
        Quaternion startRotation = puerta.rotation;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            puerta.rotation = Quaternion.Lerp(startRotation, targetRotation, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        puerta.rotation = targetRotation;
    }
}
