using UnityEngine;
using System.Collections;

public class E_F_Cannon : MonoBehaviour {
    public bool found_Targ = false;
    public GameObject EbulletPool;
    public Transform cannonhole;
    public float power;
    public float bTime = 3f;
    public float firerate;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if(found_Targ == true)
        {
        }
        if (found_Targ == false) {
        }

    }
    void OnTriggerEnter(Collider coll)
    {
        if (EbulletPool != null)
        {
            if (!found_Targ && coll.gameObject.CompareTag("Player"))
            {
                StartCoroutine("cannon");
                found_Targ = true;
            }
        }
    }
    void OnTriggerExit(Collider coll)
    {
        if (found_Targ && coll.gameObject.CompareTag("Player"))
        {
            found_Targ = false;
            StopCoroutine("cannon");
        }
    }
    IEnumerator cannon()
    {
        while (true)
        {

            //bullet.SetActive(true);

                GameObject bullet = EbulletPool.GetComponent<objectPool>().GetBullet();
                /*
                if (bul1)
                {
                    bullet.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    bullet.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

                }
                */
                bullet.GetComponent<TrailRenderer>().Clear();

                EbulletPool.GetComponent<objectPool>().startBullet(cannonhole.transform);
                StartCoroutine(off(bullet));



                yield return new WaitForSeconds(firerate);
                bullet.SetActive(false);
            
        }
    }
    void bForce(GameObject bullet, float vertical, float horizontal)
    {
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * vertical);
        //bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * horizontal * Time.deltaTime);
    }
    IEnumerator off(GameObject bullet)
    {

        yield return new WaitForSeconds(bTime);
        bullet.SetActive(false);

        //bullet.SetActive(false);


    }
}
