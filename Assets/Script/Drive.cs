using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drive : MonoBehaviour
{
    [SerializeField] float speed = 10.0f;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Slider healthBar;
    [SerializeField] private GameObject explosion;

    void Update()
    {
        float translation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        transform.Translate(translation, 0, 0);

        if (Input.GetKeyDown("space"))
        {
            //Instantiate(bullet, transform.position, Quaternion.identity);
            GameObject b = Pool.singleton.Get("Bullet");
            if (b != null)
            {
                b.transform.position = transform.position;
                b.SetActive(true);
            }
        }

        // выравнить объект слайдера из координат канваса по координатам кораблся
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position) + new Vector3(0, -65, 0);
        healthBar.transform.position = screenPos;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Asteroid")
        {
            healthBar.value -= 25;
            
            if (healthBar.value <= 0)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(healthBar.gameObject, 0.1f);
                Destroy(gameObject, 0.1f);
            }
        }
    }
}