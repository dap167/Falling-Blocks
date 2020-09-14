using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    public float speedMin;
    public float speedMax;
    float speed;
    Vector2 screenHalfSizeWorldUnits;

    void Start()
    {
        speed = Mathf.Lerp(speedMin, speedMax, Difficulty.getDifficultyPercent());
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    void Update()
    {
        if(transform.position.y < -screenHalfSizeWorldUnits.y - transform.localScale.y)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}
