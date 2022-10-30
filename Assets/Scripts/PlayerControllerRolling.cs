using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerRolling : MonoBehaviour
{
    
    public float speed = 300;

    private Rigidbody rb;
    private Vector3 eulerAnglevelocity;

    private float movementX;
    private float movementY;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // eulerAnglevelocity = new Vector3(100, 0, 0);
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movement = movementValue.Get<Vector2>();

        movementX = movement.x;
        movementY = movement.y;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        eulerAnglevelocity = new Vector3(movementX * 100, 0, movementY * 100);
        
        Quaternion deltaRotation = Quaternion.Euler(eulerAnglevelocity * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
}
