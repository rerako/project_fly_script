using UnityEngine;
using System.Collections;

public class triggermoveH : MonoBehaviour {
    public Transform body;
    public float HSpeed;
    public float VSpeed;
    public bool cho1 = false;
    public bool cho2 = false;
    public bool on;

    // Use this for initialization
    void Start () {
	    
	}

    // Update is called once per frame
    void Update() {
        if (on)
        {
            if (HSpeed > 0)
            {
                cho1 = true;
            }
            if (HSpeed < 0)
            {
                cho2 = true;
            }

        }

    }

    void OnTriggerStay(Collider coll) {
        if (coll.gameObject.tag == "obstacle" || coll.gameObject.CompareTag("enemy") || coll.gameObject.CompareTag("terrain"))
        {

            body.Rotate(body.up * HSpeed * Time.deltaTime, Space.Self);
            on = true;
            
        }
    }
    void OnTriggerExit(Collider coll) {
        if (coll.gameObject.tag == "obstacle" || coll.gameObject.CompareTag("enemy") || coll.gameObject.CompareTag("terrain"))
        {
            on = false;
            if (cho1) {
                cho1 = false;
            }
            if (cho2)
            {
                cho2 = false;
            }
           // body.Rotate(body.up * VSpeed * Time.deltaTime, Space.Self);
        }
    }
}
