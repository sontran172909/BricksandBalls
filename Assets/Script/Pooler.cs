using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    #region Singleton

    public bool dontDestroyOnLoad = true;

    public static Pooler Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            if (dontDestroyOnLoad)
            {
                DontDestroyOnLoad(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
        
        LoadInAwake();
    }

    #endregion

    private void LoadInAwake()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (var pool in pools)
        {
            var objPool = new Queue<GameObject>();
            // for (var i = 0; i < pool.size; i++)
            // {
            //     var obj = Instantiate(pool.prefab, transform);
            //     obj.SetActive(false);
            //     objPool.Enqueue(obj);
            // }

            poolDictionary.Add(pool.tag, objPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (poolDictionary.ContainsKey(tag))
        {
            if (poolDictionary[tag].Count == 0)
            {
                var pool = pools.Find(p => p.tag == tag);
                for (var i = 0; i < pool.size; i++)
                {
                    if (transform.childCount > 370) break;
                    var obj = Instantiate(pool.prefab, transform);
                    obj.SetActive(false);
                    poolDictionary[tag].Enqueue(obj);
                }
            }
             var objToSpawn = poolDictionary[tag].Dequeue();
             objToSpawn.SetActive(true);
             objToSpawn.transform.SetPositionAndRotation(position, rotation);
            return objToSpawn;
        }
        else
        {
            //Debug.LogWarning("Tag not exist in pool.");
            return null;
        }
    }

    // public GameObject SpawnFromPool(string tag, Transform parent)
    // {
    //     if (poolDictionary.ContainsKey(tag))
    //     {
    //         if (poolDictionary[tag].Count == 0)
    //         {
    //             var pool = pools.Find(p => p.tag == tag);
    //             for (var i = 0; i < pool.size; i++)
    //             {
    //                 if (transform.childCount >= 350) break;
    //                 var obj = Instantiate(pool.prefab, transform);
    //                 obj.SetActive(false);
    //                 poolDictionary[tag].Enqueue(obj);
    //             }
    //         }
    //
    //         var objToSpawn = poolDictionary[tag].Dequeue();
    //         objToSpawn.SetActive(true);
    //         objToSpawn.transform.SetPositionAndRotation(parent.position, parent.rotation);
    //         return objToSpawn;
    //     }
    //     else
    //     {
    //         //Debug.LogWarning("Tag not exist in pool.");
    //         return null;
    //     }
    // }

    public void AddToPool(string tag, GameObject objToAdd)
    {
        if (poolDictionary.ContainsKey(tag))
        {
            objToAdd.SetActive(false);
            poolDictionary[tag].Enqueue(objToAdd);
        }
        else
        {
            Debug.LogWarning("abc");
        }
    }

  
}