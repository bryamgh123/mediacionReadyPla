
// using UnityEngine;

// public class HeadAnimatorRotation : MonoBehaviour
// {
//     public Transform player;  // Jugador al que seguir
//     public Animator animator; // Animator del avatar

//     // Actualizará en cada frame
//     void Update()
//     {
//         // Comprobar si el jugador y el Animator no son nulos
//         if (player != null && animator != null)
//         {
//             animator.SetLookAtPosition(player.position);
//             animator.SetLookAtWeight(1.0f);
//         }
//     }
// }

using UnityEngine;

public class HeadAnimatorRotation : MonoBehaviour
{
    public Transform player;  // Jugador al que seguir
    public float rotationSpeed = 1.0f;  // Velocidad de rotación

    // Actualizará en cada frame
    void Update()
    {
        // Comprobar si el jugador no es nulo
        if (player != null)
        {
            RotateHead();
        }
    }

    // Método para rotar la cabeza hacia el jugador
    private void RotateHead()
    {
        // Obtener la dirección del jugador
        Vector3 direction = player.position - transform.position;
        direction.y = 0; // Esto es para que la cabeza solo gire alrededor del eje Y

        // Calcular la rotación que se necesita para mirar al jugador
        Quaternion rotation = Quaternion.LookRotation(direction);

        // Girar suavemente la cabeza hacia la dirección del jugador
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
    }
}
