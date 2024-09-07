using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float speed;     
    public float turnSpeed;
    // Start is called before the first frame update
    private float horizontalInput;  
    private float forwardInput;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     // Move forward
        // transform.Translate(0, 0, 1);
        // Which is the same as...
        // transform.Translate(Vector3.forward);
        // Move forward 20 meters/second if speed is set to 20
        // transform.Translate(Vector3.forward * Time.deltaTime * speed);

        // Get Input - Do this in Update()
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // Move player side-to-side with horizontal Input
        // transform.Translate(Vector3.right * turnSpeed * Time.deltaTime * horizontalInput);

        // Move player forward with forwardInput
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        // Rotate player with horizontal Input
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);   
    }
}
