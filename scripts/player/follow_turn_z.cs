using UnityEngine;
using System.Collections;

public class follow_turn_z : MonoBehaviour {
    public Transform mouse;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (mouse != null)
        {
            gameObject.transform.position = mouse.position;
            transform.eulerAngles =  new Vector3(0, mouse.eulerAngles.y, 0);
            //gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, new follow.rotation, 1f);
        }
    }
}
