using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInvis : MonoBehaviour
{
    //унитожить объект, когда он становится невидимым
    private void OnBecameInvisible()
    {
        //Destroy(gameObject);
        gameObject.SetActive(false); // тут у нас все настройки у объекта вернутся к дефолтным
    }
}
