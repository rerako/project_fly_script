using UnityEngine;
using System.Collections;

public class targ_script : MonoBehaviour {
    public float x;
    public float y;
    public float z;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(x, y, z);

    }
    void OnTriggerEnter(Collider hit)
    {

        if (hit.gameObject.tag == "bullet") {
            Destroy(gameObject);
        }
    }

}
