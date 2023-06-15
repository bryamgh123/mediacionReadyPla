// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PuertasAbrir : MonoBehaviour
// {
//     public float interactDistance = 2.0f;

//     // Actualiza cada frame
//     void Update()
//     {
//         // Si el jugador presiona la tecla 'E'
//         if (Input.GetKeyDown(KeyCode.E))
//         {
//             // Lanza un raycast frente al jugador
//             Ray ray = new Ray(transform.position, transform.forward);
//             RaycastHit hit;

//             // Si el raycast golpea a un objeto dentro del alcance de interacción
//             if (Physics.Raycast(ray, out hit, interactDistance))
//             {
//                 // Si el objeto golpeado tiene un controlador de puerta, cambia el estado de la puerta
//                 PuertaControlador door = hit.transform.GetComponent<PuertaControlador>();
//                 if (door)
//                 {
//                     door.ChangeDoorState();
//                 }
//             }
//         }
//     }
// }
