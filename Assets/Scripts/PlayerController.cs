using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public int speed = 300;

    private Rigidbody rb;

    public TMP_Text black;
    public TMP_Text blue;
    public TMP_Text red;
    public TMP_Text yellow;
    public TMP_Text points;
    public TMP_Text final;

    private bool isMoving = false;

    private Color color;


    public int pointValue = 1;

    public static int totalPoints = 0;

    private int paintedGroundAmmount = 0;

    public static int blackGroundPoints = 0;
    public static int blueGroundPoints = 0;
    public static int redGroundPoints = 0;
    public static int yellowGroundPoints = 0;


    private Vector3 movementSide;

    private String[] coords;
    
    private Boolean canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        color = Color.black;
        
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (isMoving)
        {
            return;
        }
        StartCoroutine(Roll(movementSide));
    }

    private Boolean checkCanMove(Vector3 direction)
    {
        if (direction == Vector3.back)
        {
            if (coords[0] == "0") canMove = false;
        }
        else if (direction == Vector3.forward)
        {
            if (coords[0] == "9") canMove = false;
        }
        else if (direction == Vector3.left)
        {
            if (coords[1] == "0") canMove = false;
        }
        else if (direction == Vector3.right)
        {
            if (coords[1] == "9") canMove = false;
        }
        else
        {
            canMove = true;
        }
        
        return canMove;
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movement = movementValue.Get<Vector2>();

        float movementX = movement.x;
        float movementY = movement.y;

        if (movementX == 1)
        {
            movementSide = Vector3.right;
        }
        else if (movementX == -1)
        {
            movementSide = Vector3.left;
        }
        else if (movementY == 1)
        {
            movementSide = Vector3.forward;
        }
        else if (movementY == -1)
        {
            movementSide = Vector3.back;
        }
        else
        {
            movementSide = Vector3.zero;
        }
    }

    IEnumerator Roll(Vector3 direction)
    {
        if (checkCanMove(direction))
        {
            isMoving = true;
            float remainingAngle = 90;

            Vector3 rotationCenter = transform.position + direction / 2 + Vector3.down / 2;
            Vector3 rotationAxis = Vector3.Cross(Vector3.up, direction);

            while (remainingAngle > 0)
            {
                float rotationAngle = Mathf.Min(Time.deltaTime * speed, remainingAngle);
                transform.RotateAround(rotationCenter, rotationAxis, rotationAngle);
                remainingAngle -= rotationAngle;
                yield return null;
            }

            isMoving = false;
        }
        else

        {
            movementSide = Vector3.zero;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.name.Contains("Collectable"))
        {
            String collectableNumber = (other.name.Split(' '))[1];


            color = other.GetComponent<Renderer>().material.color;

            rb.GetComponent<Renderer>().material.color = color;
            other.gameObject.SetActive(false);

            switch (collectableNumber)
            {
                case "1":
                    pointValue = 2;
                    break;

                case "2":
                    pointValue = 3;
                    break;
                case "3":
                    pointValue = 4;
                    break;
            }
        }
        else
        {
            Material mat = other.GetComponent<Renderer>().material;

            coords = (other.name.Split(' ')[1]).Split(',');

            if (mat.color == Color.white)
            {
                other.GetComponent<Renderer>().material.color = color;

                SetPoints();
            }
        }
    }

    private void SetPoints()
    {
        totalPoints += pointValue;

        points.SetText("Puntación: " + totalPoints);

        switch (pointValue)
        {
            case 1:
                blackGroundPoints++;
                break;
            case 2:
                blueGroundPoints++;
                break;

            case 3:
                redGroundPoints++;
                break;

            case 4:
                yellowGroundPoints++;
                break;
        }

        paintedGroundAmmount++;

        if (paintedGroundAmmount > 99)
        {
            SceneManager.LoadScene("SecondaryScene");
        }
    }

    private void OnJump()
    {
        Vector3 jump = new Vector3(0.0f, 5.0f, 0.0f);
        rb.AddForce( jump, ForceMode.Impulse );
    }
}