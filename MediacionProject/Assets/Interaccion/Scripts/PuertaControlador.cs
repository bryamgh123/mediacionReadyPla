// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PuertaControlador : MonoBehaviour
// {

//     [SerializeField]
//     private float rotationSpeed = 50f;

//     private Vector3 defaultRotation;
//     private OVRGrabber handGrabbing;

//     private void Start()
//     {
//         defaultRotation = transform.eulerAngles;
//     }

//     public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
//     {
//         base.GrabBegin(hand, grabPoint);
//         handGrabbing = hand;
//     }

//     public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
//     {
//         base.GrabEnd(Vector3.zero, Vector3.zero);
//         handGrabbing = null;
//     }

//     private void Update()
//     {
//         if (isGrabbed && handGrabbing)
//         {
//             RotateDoor();
//         }
//     }

//     private void RotateDoor()
//     {
//         float rotationAmount = handGrabbing.transform.eulerAngles.z - transform.eulerAngles.z;
//         rotationAmount *= rotationSpeed * Time.deltaTime;

//         // Aquí controlas hasta qué punto se puede abrir la puerta.
//         float rotationZ = Mathf.Clamp(transform.eulerAngles.z + rotationAmount, defaultRotation.z, defaultRotation.z + 90f);

//         transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, rotationZ);
//     }





// }
