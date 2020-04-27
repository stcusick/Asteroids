using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroid : MonoBehaviour
{
    public Camera MainCamera;
    public GameObject[] asteroids;
    public float spawnDelay = 10f;
    private float nextSpawnTime;
    private Vector2 screenBounds;

    void Start()
    {
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
    }

    void Update()
    {
        if (shouldSpawn())
        {
            spawnLoaction();
            spawn();
        }
    }

    private bool shouldSpawn()
    {
        return Time.time >= nextSpawnTime;
    }
    private void spawnLoaction()
    {
        Vector3 newLocation = new Vector3(0,0,0);
        float side = Random.Range(0f, 4f);
        if(side <= 1)
        {
            newLocation.y = screenBounds.y + 3;
            newLocation.x = Random.Range(-screenBounds.x, screenBounds.x);

        }
        else if (side > 1 && side <= 2)
        {
            newLocation.y = -screenBounds.y - 3;
            newLocation.x = Random.Range(-screenBounds.x, screenBounds.x);

        }
        else if (side > 2 && side <= 3)
        {
            newLocation.x = screenBounds.x + 3;
            newLocation.y = Random.Range(-screenBounds.y, screenBounds.y);

        }
        else if (side > 3 && side <= 4)
        {
            newLocation.x = -screenBounds.x - 3;
            newLocation.y = Random.Range(-screenBounds.y, screenBounds.y);
            
        }
        transform.position = newLocation;
    }
    private void spawn()
    {
        GameObject asteroid = asteroids[Random.Range(0, asteroids.Length)];
        nextSpawnTime = Time.time + spawnDelay;
        Instantiate(asteroid, transform.position, transform.rotation);
    } 


    
}
