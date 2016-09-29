using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class SwarmHost: MonoBehaviour {
    public GameObject[] bee;
    public Transform target;
    public GameObject[] flyPoints;
    public List<GameObject> TargList = new List<GameObject>();
    public bool firing;
    int z = 0;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider alert) {
        if(alert.gameObject.tag == "Player" || alert.gameObject.tag == "bullet" || alert.gameObject.tag == "enemy")
        {
            TargList.Add(alert.gameObject);
            target = alert.gameObject.transform;
            for (int i = 0; i < bee.Length; i++)
            {          
                    bee[i].GetComponent<beeWorker>().moveBack(target);
            }
            

        }

    }
    void OnTriggerExit(Collider alert) {
        if (alert.gameObject.tag == "Player" || alert.gameObject.tag == "bullet" || alert.gameObject.tag == "enemy") {
            TargList.Remove(alert.gameObject);
                for (int i = 0; i < bee.Length; i++)
            {
                target = flyPoints[i].transform;
                bee[i].GetComponent<beeWorker>().moveBack(target);


            }

        }
    }
    IEnumerator fire() {
        if (!firing) {
            firing = true;
            if (z >= bee.Length) {
                z = 0;
            }
            
            bee[z].GetComponent<beeWorker>().moveBack(target);
            yield return new WaitForSeconds(0.5f);
            firing = false;
            yield return new WaitForSeconds(2f);
            bee[z].GetComponent<beeWorker>().moveBack(flyPoints[z].transform);

            z++;
            
        }
    }
}
