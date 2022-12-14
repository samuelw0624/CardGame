using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    #region Singleton
    public static ObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    //pools class
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    //list of pools with the Pool class attributes
    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    public List<Card> cardPool = new List<Card>();

    public Card randomCard_m;

    // Start is called before the first frame update
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        //reference card pool from GameManager script
        cardPool = GameManager.instance.cardPool;

        //for each pool in the list of pools
        foreach (Pool p in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            //for each object in each pool, iterate pool size times
            for (int i = 0; i < p.size; i++)
            {
                //assign card prefab in the pool with random card SO
                randomCard_m = cardPool[Random.Range(0, cardPool.Count)];
                //display the SO information on card
                p.prefab.GetComponent<CardDisplay>().card = randomCard_m;
                //instantiate this prefab deactivated
                GameObject obj = Instantiate(p.prefab, GameManager.instance.gameCanvas.transform);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(p.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool (string tag, Vector3 position)
    {
        //dequeues the object from pool so it can be shown
        GameObject objectToSpawn =  poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;

        //enqueu the object again so it can be used
        poolDictionary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        //keep updating cardPool reference
        cardPool = GameManager.instance.cardPool;
    }
}
