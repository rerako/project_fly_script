using UnityEngine;
using System.Collections;

public class EnemyCan : MonoBehaviour {
	public Transform target;
	public Transform cannonhole;
    public bool found_Targ;
    public float power;
    public float firerate;
    private Vector3 v_diff;
	private float atan2;
	public GameObject Ebullet;
	private bool shooting;
    private bool bul1;
    public bool pace = false;
	public string point;
    public float range;
    public GameObject bulletPool;
   // int bulletID = 0;

    // Use this for initialization
    void Start () {
        //target = GameObject.FindGameObjectWithTag(point).transform;
        bul1 = false;
	}

    // Update is called once per frame
    void Update() {
        //v_diff = (target.position - transform.position); 
        //atan2 = Mathf.Atan2 ( v_diff.y, v_diff.x );
        //transform.rotation = Quaternion.Euler(0f, 0f, atan2 * Mathf.Rad2Deg - 90);
        if (found_Targ == true)
        {
            transform.LookAt(target);

            if ( pace == false)
            {
                StartCoroutine("cannon");
                //started = true;
                //Debug.Log ("1");
            }
        }
		if( found_Targ == false){
			StopCoroutine("cannon");
			pace = false;
			//Debug.Log ("2");

		}
	
	}

	IEnumerator cannon(){
            pace = false;
        //bullet.SetActive(true);
        GameObject bullet = bulletPool.GetComponent<objectPool>().GetBullet();
        if (bul1)
        {
            bullet.GetComponent<TrailRenderer>().Clear();
            bullet.GetComponent<Rigidbody>().velocity = Vector3.zero;
            bullet.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }

        bulletPool.GetComponent<objectPool>().startBullet(cannonhole.transform);
        //StartCoroutine(off(bullet));

        yield return new WaitForSeconds(firerate);
        pace = true;

	}
	
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            target = coll.gameObject.transform;
            found_Targ = true;
        }
    }
    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            target = null;
            found_Targ = false;
        }
    }
    void bForce(GameObject bullet, float vertical , float horizontal){
		bullet.GetComponent<Rigidbody>().AddForce(transform.forward * vertical);
		//bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * horizontal * Time.deltaTime);
	}
}
