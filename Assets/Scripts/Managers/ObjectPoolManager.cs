using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    //SINGLETON
    public static ObjectPoolManager Instance { get; private set; }

    //LOGIC
    [SerializeField]
    List<GameObject> prefabs;

    List<GameObject> objects;

    //SINGLETON
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //LOGIC
    void Start()
    {
        objects = new List<GameObject>();
    }

    public string[] GetPrefabNames()
    {
        List<string> names = new List<string>();
        prefabs.ForEach((prefab) => names.Add(prefab.name));
        return names.ToArray();
    }

    public GameObject FindOrCreate(string name)
    {
        foreach (var item in objects)
        {
            if (item.name == (name + "(Clone)") && !item.activeSelf)
            {
                item.transform.SetParent(transform);
                return item;
            }
        }

        GameObject newObject = Instantiate(prefabs.Find((prefab) => prefab.name == name));
        newObject.transform.SetParent(transform);
        newObject.SetActive(false);
        objects.Add(newObject);
        return newObject;
    }
}
