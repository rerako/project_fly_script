using UnityEngine;
using System.Collections;

public class enemySpawn : MonoBehaviour {
    public GameObject EnemyPool;
    public Transform point;
    public int amount;
    bool spawned;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!spawned)
        {
            for (int i = 0; i < amount; i++)
            {
                EnemyPool.GetComponent<objectPool>().startEnemy(point);
            }
            spawned = true;
        }
	}
}
