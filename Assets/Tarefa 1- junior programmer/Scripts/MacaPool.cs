using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MacaPool : MonoBehaviour
{
    // Mudei aqui também para conseguires chamar o script pelo nome novo!
    public static MacaPool SharedInstance;

    [Header("Configurações da Piscina")]
    public List<GameObject> pooledObjects; 
    public GameObject objectToPool;       
    public int amountToPool;               

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();

        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(objectToPool);
            obj.SetActive(false); 
            pooledObjects.Add(obj);
            obj.transform.SetParent(this.transform); 
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
