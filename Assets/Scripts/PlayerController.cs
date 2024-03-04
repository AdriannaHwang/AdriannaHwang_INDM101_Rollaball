using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{

 private Rigidbody rb; 
 private int count;
 // Movement along X and Y axes.
 private float movementX;
 private float movementY;
 // Speed at which the player moves.
 public float speed = 0;
 // UI text component to display count of "PickUp" objects collected.
 public TextMeshProUGUI countText;
 // UI object to display winning text.
 public GameObject winTextObject;

 void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }
 
 void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x; 
        movementY = movementVector.y; 
    }

 private void FixedUpdate() 
    {
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
        rb.AddForce(movement * speed); 
    }
 
 void OnTriggerEnter(Collider other) 
    {
 if (other.gameObject.CompareTag("PickUp")) 
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

 void SetCountText() 
    {
        countText.text = "Count: " + count.ToString();
 if (count >= 7)
        {
 // Display the win text.
            winTextObject.SetActive(true);
        }
    }
}
