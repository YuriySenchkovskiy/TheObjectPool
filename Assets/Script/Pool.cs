using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoolItem
{
    [SerializeField] public GameObject prefab;
    [SerializeField] public int amount;
    [SerializeField] public bool expandable;
}

public class Pool : MonoBehaviour
{
    [SerializeField] public static Pool singleton;
    [SerializeField] List<PoolItem> items;
    [SerializeField] private List<GameObject> poolItems;

    private void Awake()
    {
        singleton = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        poolItems = new List<GameObject>();
        foreach (PoolItem item in items)
        {
            for (int i = 0; i < item.amount; i++)
            {
                GameObject obj = Instantiate(item.prefab);
                obj.SetActive(false);
                poolItems.Add(obj);
            }
        }
    }

    public GameObject Get(string tag)
    {
        for (int i = 0; i < poolItems.Count; i++)
        {
            if (!poolItems[i].activeInHierarchy && poolItems[i].tag == tag)
            {
                return poolItems[i];
            }
        }

        // создаем объекты для расширенного списка
        foreach (var item in items)
        {
            if (item.prefab.tag == tag && item.expandable)
            {
                GameObject obj = Instantiate(item.prefab);
                obj.SetActive(false);
                poolItems.Add(obj);
                return obj;
            }
        }

        return null;
    }
}
