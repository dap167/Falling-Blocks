using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public float speed = 2;
    float screenHalfWidthInWorldUnits;
    float screenHalfHeightInWorldUnits;
    float startY;

    // Start is called before the first frame update
    void Start()
    {
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize;
        screenHalfHeightInWorldUnits = screenHalfWidthInWorldUnits * 2;
        float startX = Random.Range(-screenHalfWidthInWorldUnits, screenHalfWidthInWorldUnits);
        startY = screenHalfHeightInWorldUnits - transform.localScale.y / 2;
        Vector2 startLocation = new Vector2(startX, startY);
        transform.position = startLocation;
    }

    // Update is called once per frame
    void Update()
    {
        float moveAmount = speed * Time.deltaTime;
        transform.Translate(Vector2.down * moveAmount);

        if(transform.position.y < -screenHalfHeightInWorldUnits - transform.localScale.y / 2)
        {
            float randomX = Random.Range(-screenHalfWidthInWorldUnits, screenHalfWidthInWorldUnits);
            transform.position = new Vector2(randomX, startY);
        }
    }
}
