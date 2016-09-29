using UnityEngine;
using System.Collections;

public class bulletcoll : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "terrain")
        {
           // gameObject.SetActive(false);
        }
        else if (coll.gameObject.tag == "Player")
        {
            //gameObject.SetActive(false);
        }
        else if (coll.gameObject.tag == "enemy")
        {
            gameObject.SetActive(false);
        }
    }
}
