using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPickUpBehaviourv2 : MonoBehaviour
{
    [SerializeField] float objectRange;
    [SerializeField] private GameObject pickedUpObject;
    [SerializeField] private List<GameObject> potentialPickUpObjects = new List<GameObject>();

    //GetMousePos
    private Camera mainCam;
    private Vector2 mousePos;
    private Vector2 mousePosWorld;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //rotate pickedUpObject
        if(pickedUpObject != null)
        {
            Vector2 rotation = new Vector2(transform.position.x,transform.position.y) - mousePosWorld;
            float rot = Mathf.Atan2(rotation.y,rotation.x) * Mathf.Rad2Deg;
            pickedUpObject.transform.rotation = Quaternion.Euler(0,0,rot + 90);
            pickedUpObject.transform.position = transform.position + ((Vector3)mousePosWorld - transform.position).normalized * objectRange;
        }

        //update mouseposition
        mousePosWorld = mainCam.ScreenToWorldPoint(mousePos);
    }

    private void OnThrowPickUp()
    {
        //Check if we already have an object picked up
        if (pickedUpObject == null)
        {
            if (potentialPickUpObjects.Count < 1)
                return;

            pickedUpObject = potentialPickUpObjects[0];

            if(TryGetComponent<Rigidbody2D>(out var rb2D))
            {
                rb2D.velocity = Vector2.zero;
            }

            //Disable pickedup objects collider
            Collider2D col = pickedUpObject.GetComponent<Collider2D>();
            col.enabled = false;
            

            //set object as child and follow player
            pickedUpObject.gameObject.transform.parent = transform;
            pickedUpObject.gameObject.transform.position = pickedUpObject.transform.parent.position;
            potentialPickUpObjects.Remove(potentialPickUpObjects[0]);
            return;
        }

        if (pickedUpObject != null)
        {
            

            Pickup pickup = pickedUpObject.GetComponent<Pickup>();
            if(pickup != null)
            {
                pickup.Throw(((Vector3)mousePosWorld - transform.position).normalized, 1f);
            }
            Invoke("EnableObjectsCollider", .1f);
        }


    }
    private void OnMousePosition(InputValue inputValue)
    {
        mousePos = inputValue.Get<Vector2>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup") && !potentialPickUpObjects.Contains(other.gameObject))
        {
            potentialPickUpObjects.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            potentialPickUpObjects.Remove(other.gameObject);
        }
    }

    private void EnableObjectsCollider()
    {
        //Enable pickedup objects collider REMAKE THIS. getting to many components
        Collider2D col = pickedUpObject.GetComponent<Collider2D>();
        col.enabled = true;
        pickedUpObject = null;
    }
}
