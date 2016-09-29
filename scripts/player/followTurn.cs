using UnityEngine;
using System.Collections;

public class followTurn : MonoBehaviour {
    public Transform follow;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(follow != null) {
        gameObject.transform.position = follow.position;
        transform.eulerAngles = Vector3.Lerp(gameObject.transform.eulerAngles, new Vector3(follow.eulerAngles.x, follow.eulerAngles.y, 0f),1f);
            //gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, new follow.rotation, 1f);
        }
    }
}
