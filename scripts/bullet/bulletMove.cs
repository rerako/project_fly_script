using UnityEngine;
using System.Collections;

public class bulletMove : MonoBehaviour {
    public float bSpeed;
    public Transform forward;
    // Use this for initialization
    void Start () {
    
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards( transform.position, forward.position ,bSpeed * Time.deltaTime);
	}

}
