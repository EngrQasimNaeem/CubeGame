using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerScale : MonoBehaviour
{
    
    private float turnSpeed = 75.0f;
    private float horizontalInput;
    private float forwardInput;
    private float speed = 20f;    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        // if(Input.GetKey("space"))
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.localScale = transform.localScale + new Vector3(3, 3, 3);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            transform.localScale = transform.localScale + new Vector3(-3, -3, -3);
        }
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        
         transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
    }
}

