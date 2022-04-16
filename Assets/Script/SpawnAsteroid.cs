using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroid : MonoBehaviour
{
    [SerializeField] private GameObject asteroid;

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 100) < 5)
        {
            // Instantiate(asteroid, 
            //     transform.position + 
            //     new Vector3(Random.Range(-10, 10), 0, 0), Quaternion.identity);
            
            GameObject a = Pool.singleton.Get("Asteroid");
            if (a != null)
            {
                a.transform.position = transform.position + new Vector3(Random.Range(-10,10), 0,0);
                a.SetActive(true);
            }
        }
    }
}
