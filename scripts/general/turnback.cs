using UnityEngine;
using System.Collections;

public class turnback : MonoBehaviour {
    public Transform point;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerExit(Collider coll) {
        if (coll.gameObject.CompareTag("enemy") ) {
            point.position = resetpoint();
            //coll.gameObject.GetComponent<faceScript>().gazeAt(point);
        }
    }
   public Vector3 resetpoint() {
       return new Vector3(transform.position.x + Random.Range(-100f,100f), transform.position.y + Random.Range(10f,30f), transform.position.z + Random.Range(-100f,100f));
    }
}
