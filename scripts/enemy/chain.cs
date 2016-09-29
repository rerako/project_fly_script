using UnityEngine;
using System.Collections;

public class chain : MonoBehaviour {
    public Transform follow;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (follow != null)
        {
            //transform.position = Vector3.Lerp(transform.position, follow.position,0.5f);
            //transform.rotation = Quaternion.Lerp(transform.rotation, follow.rotation, 0.7f);
            transform.position = Vector3.Lerp(transform.position, follow.position, 15 * Time.deltaTime);
            //transform.rotation = Quaternion.Lerp(transform.rotation, follow.rotation, 0.5f * Time.deltaTime);
            transform.LookAt(follow);
        }
        
    }

}
