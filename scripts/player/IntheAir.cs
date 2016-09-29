using UnityEngine;
using System.Collections;

public class IntheAir : MonoBehaviour {
    public bool airtime = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public bool AirJordan() {
        return airtime;
    }
    void OnTriggerStay(Collider touch)
    {
       if( touch.transform.tag == "terrain")
        {
            airtime = false;
        }

    }
    void OnTriggerExit(Collider touch)
    {
        if (touch.transform.tag == "terrain")
        {
            airtime = true;
        }
    }
}
