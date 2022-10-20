using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 0;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI timerText;
    public GameObject winTextObject;

    private Rigidbody rb;
    private int count;
    private int timer;
    private float movementX;
    private float movementY;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        timer = 0;

        SetCountText();
        SetTimerText();
        winTextObject.SetActive(false);
    }

    // Update is called once per frame
    void OnMove(InputValue movementValue)
    {

        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Points: " + count.ToString();
        if(count >= 25)
        {
            winTextObject.SetActive(true);
        }
    }

    void SetTimerText()
    {
        timerText.text = "Time Taken: " + timer.ToString();
        if(count > 25)
        {
            timer = timer + 1;
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }
        
        if (other.gameObject.CompareTag("LargePickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 5;

            SetCountText();

        }
        
        if (other.gameObject.CompareTag("AntiPickUp"))
        {
                other.gameObject.SetActive(false);
                count = count - 1;

            SetCountText();

        }
        
    }
}
