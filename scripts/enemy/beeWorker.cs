using UnityEngine;
using System.Collections;

public class beeWorker : MonoBehaviour {
    public Transform target;
    public float speed;

    // Use this for initialization
    void Start () {
        target = null;

	}
	
	// Update is called once per frame
	void LateUpdate () {
        if (target != null) {
            transform.position = Vector3.Lerp(transform.position , target.position, speed * Time.deltaTime);
            transform.LookAt(target.position);

        }
	}

    public void moveBack(Transform delta) {
        target = delta;
    }
    void OnTriggerEnter(Collider hit) {
        if(hit.gameObject.tag == "bullet")
        gameObject.SetActive(false);
    }
}
