using UnityEngine;
using System.Collections;

public class closeto : MonoBehaviour {
    public GameObject bulletObjectPool;
    
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        for (int x = 0; x < bulletObjectPool.GetComponent<objectPool>().List.Length; x++)
        {
            if (bulletObjectPool.GetComponent<objectPool>().List[x].activeSelf)
            {
                if (Vector3.Distance(bulletObjectPool.GetComponent<objectPool>().List[x].transform.position, transform.position) < 2)
                {
                    Debug.Log("hit");
                }
            }
        }
	}
}
