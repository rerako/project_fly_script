using UnityEngine;
using System.Collections;

public class follow : MonoBehaviour {
    public Transform follower;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
         transform.position = Vector3.Lerp(gameObject.transform.position, follower.position, 0.3f);
         transform.rotation = Quaternion.Lerp(transform.rotation, follower.rotation, 0.3f);

    }
}
