using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static ReadyPlayerMe.ExtensionMethods;

public class NavAvatar : MonoBehaviour
{
    //este es pa la silla
    public Transform Silla;
    public Transform AvatarLugar;
    //llamar al animator
    private Animator anim;
    private NavMeshAgent agent;
    private int idAvatar;
    //usar el Quaternion
    [SerializeField] private Transform jugador;
    [SerializeField] private Transform cubos;
    private bool playerIngreso = false;
    public bool PlayerIngreso
    {
        get { return playerIngreso; }
        set { playerIngreso = value; }
    }

    public bool parauimediador = false;
    public ManagerDialogos managerDialogos;


    private Transform SillaObjeto;
    private Vector3 initialPosition;
    private bool isSeated = false;

    private void Start()
    {
        initialPosition = transform.position;
        Silla.parent = null;
    }


    public void MirarObjetivo()
    {
        if (playerIngreso)
        {
            Vector3 direccion = jugador.position - transform.position;
            SetRotation(direccion);
        }
        else
        {
            Vector3 direccion = cubos.position - transform.position;
            SetRotation(direccion);
        }
    }
    private void SetRotation(Vector3 direccion)
    {
        direccion.y = 0;  // Ignora la componente vertical
        Quaternion nuevaRotacion = Quaternion.LookRotation(direccion);
        transform.rotation = nuevaRotacion;
    }

    // este metodo es para usar un solo script para los dos avatars
    // mismo lee el id del avatar y lo asigna a la variable idAvatar
    // con esto le dice en cual de las silla tiene que sentarse y a cual de los cubos tiene que ver
    public void ParametrosNavvar()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        idAvatar = GetComponent<IdAvatar>().idAvatares;
        jugador = GameObject.Find("VistaPlayer").transform;
        managerDialogos = GameObject.Find("DialogosManager").GetComponent<ManagerDialogos>();
        AvatarLugar = GameObject.Find("Avatar").transform;

        if (idAvatar == 1)
        {
            Silla = GameObject.Find("espaciosentar1").transform;
            cubos = GameObject.Find("VistaSilla2").transform;
            SillaObjeto = GameObject.Find("SillaMujer").transform;

        }
        else if (idAvatar == 2)
        {
            Silla = GameObject.Find("espaciosentar2").transform;
            cubos = GameObject.Find("VistaSilla1").transform;
            SillaObjeto = GameObject.Find("SillaHombre").transform;
        }
    }
    //metodo para que el avatar se mueva a la silla

    public void CuandoLlega()
    {
        if (Vector3.Distance(transform.position, Silla.position) < 0.5f)
        {
            // estos son para la animacion
            anim.SetBool("Semueve", false);
            anim.SetBool("Llego", true);

            // El avatar está sentado
            isSeated = true;
            // Disminuye la velocidad de movimiento
            agent.speed = 0.1f; // ajústalo según sea necesario

            // Hacer que la silla sea hija del avatar
            SillaObjeto.parent = transform;

            // Ajustar la posición de la silla para alinearla con el avatar
            SillaObjeto.localPosition = new Vector3(0, -0.1f, -0.04f);

            // Hacer que la silla mire en la misma dirección que el avatar
            SillaObjeto.rotation = transform.rotation;

            // Rotar la silla 180 grados en el eje Y
            SillaObjeto.Rotate(0, 180, 0);

            MirarObjetivo();
            parauimediador = true;
        }
    }



    public void caminarSilla()
    {
        agent.SetDestination(Silla.position);
        anim.SetBool("Semueve", true);
    }
    public void retirada()
    {
        if (managerDialogos.navfindedialogo == true)
        {
            // El avatar ya no está sentado
            isSeated = false;
            // Aumenta la velocidad de movimiento
            agent.speed = 3.5f; // ajústalo a la velocidad normal

            anim.SetBool("Llego", false);
            anim.SetBool("Semueve", true);
            agent.SetDestination(AvatarLugar.localPosition);
        }
    }
    // falta llamarlo pero despues
    IEnumerator destruir()
    {
        // Hacer que el avatar camine de regreso a su posición inicial
        agent.SetDestination(initialPosition);
        anim.SetBool("Semueve", true);

        // Esperar hasta que el avatar llegue a su posición inicial
        while (Vector3.Distance(transform.position, initialPosition) > 0.5f)
        {
            yield return null;
        }

        // Esperar 15 segundos más antes de destruir el avatar
        yield return new WaitForSeconds(15);

        GameObject.Destroy(gameObject);
    }

    void Update()
    {
        //cambiar
        CuandoLlega();

    }

}
