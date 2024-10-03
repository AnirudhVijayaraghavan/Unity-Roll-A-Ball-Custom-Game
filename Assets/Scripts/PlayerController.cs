using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Security.Cryptography;
using System.Collections.Specialized;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public float hop;
    public TextMeshProUGUI countText;
    private Rigidbody rb;
    //public GameObject winTextObject;
    public Transform respawnPoint;
    public MenuController  menuController;

    private int count;
    private float movementX;
    private float movementY;

    private AudioSource pop;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count=0;
        SetCountText();

        pop = GetComponent<AudioSource>();
        
        //winTextObject.SetActive(false);

    }

    private void Update() {
        if (transform.position.y < -10) {
            Respawn();
        }
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;

    }

    void OnJump (InputValue jumpValue)
    {
        rb.AddForce(Vector3.up * hop, ForceMode.Impulse);

    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 11)
        {
            //winTextObject.SetActive(true);
            menuController.WinGame();
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        //rb.AddForce(movementVector);
        
        rb.AddForce(movement * speed);

    }

    private void OnTriggerEnter(Collider other) { 
        if (other.gameObject.CompareTag("PickUp")) {

            other.gameObject.SetActive(false);
            count += 1;
            pop.Play();  // Start the music
            SetCountText();
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Enemy")) {
            //Respawn();
            EndGame();
        }

    }

    void Respawn() { 
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.Sleep();
        transform.position = respawnPoint.position;
    }

    void EndGame()
    {

        menuController.LoseGame();
        gameObject.SetActive(false);
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
