using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSR : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.eulerAngles = new Vector3(90,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
