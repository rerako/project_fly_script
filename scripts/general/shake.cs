using UnityEngine;
using System.Collections;

public class shake : MonoBehaviour {
    public Transform left;
    public Transform right;
    public float sway_amount;
    public float timer;
    public bool angle;
    public float speed;
    private float step;
	// Use this for initialization
	void Start () {
        timer = sway_amount;
        step = speed * Time.deltaTime;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0) {
            if (angle) { angle = false; }
            else if (!angle) { angle = true; }
            timer += Random.Range(0f,2.5f);
        }
        if (angle)
        {
            transform.position = Vector3.Lerp(transform.position, left.position, step);
        }
        else if (!angle) {
            transform.position = Vector3.Lerp(transform.position, right.position, step);

        }
    }
}
