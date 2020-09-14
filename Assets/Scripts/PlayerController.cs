using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1;
    float screenHalfWidthInWorldUnits;
    float playerHalfWidth;
    Rigidbody2D myRigidbody;
    float velocity;
    float startTime;
    public event System.Action OnPlayerDeath;

    // Start is called before the first frame update
    void Start()
    {
        playerHalfWidth = transform.localScale.x / 2;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize;
        myRigidbody = GetComponent<Rigidbody2D>();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        velocity = inputX * speed;
        float moveAmount = velocity * Time.deltaTime;
        transform.Translate(Vector2.right * moveAmount);

        if (transform.position.x < -screenHalfWidthInWorldUnits - playerHalfWidth)
        {
            transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
        }
        if (transform.position.x > screenHalfWidthInWorldUnits + playerHalfWidth)
        {
            transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
        }
    }
    void FixedUpdate()
    {
        myRigidbody.position += Vector2.right * velocity * Time.fixedDeltaTime;
    }

    void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if(triggerCollider.tag == "Falling Block")
        {
            if(OnPlayerDeath != null)
            {
                OnPlayerDeath();
            }
            Destroy(gameObject);
        }
    }
}
