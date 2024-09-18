using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 30f;
    private float leftBound = -15;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        // Use fixedDeltaTime for movement in FixedUpdate
        transform.Translate(Vector3.left * Time.fixedDeltaTime * speed);

        // Destroy object if it moves past the left boundary
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}