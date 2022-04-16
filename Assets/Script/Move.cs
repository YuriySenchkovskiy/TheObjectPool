using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private Vector3 velocity;

    void Update()
    {
        transform.Translate(velocity);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Asteroid")
        {
            //Destroy(col.gameObject);
            col.gameObject.SetActive(false);
        }
    }
}
