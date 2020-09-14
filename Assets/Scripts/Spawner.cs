using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fallingBlockPrefab;
    public float spawnRateMin = .25f;
    public float spawnRateMax = 2f;
    float nextSpawnTime;
    Vector2 screenHalfSizeWorldUnits;
    public float spawnMinScale;
    public float spawnMaxScale;
    public float spawnMaxAngle;

    // Start is called before the first frame update
    void Start()
    {
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            float secondsBetweenSpawns = Mathf.Lerp(spawnRateMax, spawnRateMin, Difficulty.getDifficultyPercent());
            nextSpawnTime = Time.time + secondsBetweenSpawns;
            float spawnSize = Random.Range(spawnMinScale, spawnMaxScale);
            float spawnAngle = Random.Range(-spawnMaxAngle, spawnMaxAngle);
            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + spawnSize);
            GameObject currentSpawn = (GameObject)Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
            currentSpawn.transform.localScale = Vector2.one * spawnSize;
        }
    }
}
