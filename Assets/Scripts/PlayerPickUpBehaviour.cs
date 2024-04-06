//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PlayerPickUpBehaviour : MonoBehaviour
//{
//    [SerializeField] private float throwSpeed;
//    [SerializeField] private GameObject pickedUpObject;
//    [SerializeField] private List<GameObject> potentialPickUpObjects = new List<GameObject>();
//    private PlayerMovement playerMovement;

//    private void Start()
//    {
//        playerMovement = GetComponent<PlayerMovement>();
//    }

//    private void OnThrowPickUp()
//    {
//        //Check if we already have an object picked up
//        if (pickedUpObject == null)
//        {
//            if (potentialPickUpObjects.Count < 1)
//                return;

//            pickedUpObject = potentialPickUpObjects[0];
//            pickedUpObject.gameObject.transform.parent = transform;
//            potentialPickUpObjects.Remove(potentialPickUpObjects[0]);
//            pickedUpObject.gameObject.GetComponent<Collider2D>().enabled = false;
//            return;
//        }

//        if (pickedUpObject != null)
//        {
//            InitializeProjectile();
//            pickedUpObject.transform.parent = null;
//            pickedUpObject = null;
//        }

        
//    }
//    public void InitializeProjectile()
//    {
//        Rigidbody2D rigidbody = pickedUpObject.GetComponent<Rigidbody2D>();
//        rigidbody.velocity = new Vector2(playerMovement.lastMovementInput.x * throwSpeed, playerMovement.lastMovementInput.y * throwSpeed);
//    }

//    private void OnTriggerEnter2D(Collider2D other)
//    {
//        if (other.gameObject.CompareTag("Pickup") && !potentialPickUpObjects.Contains(other.gameObject))
//        {
//            potentialPickUpObjects.Add(other.gameObject);
//        }
//    }

//    private void OnTriggerExit2D(Collider2D other)
//    {
//        if (other.gameObject.CompareTag("Pickup"))
//        {
//            potentialPickUpObjects.Remove(other.gameObject);
//        }
//    }
//}
