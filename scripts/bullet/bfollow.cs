using UnityEngine;
using System.Collections;

public class bfollow : MonoBehaviour {
    public Transform target;
    public bool found_Targ = false;
    public Vector3 direction;
    public float flySpeed;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (found_Targ == true)
        {
            if (target != null)
            {
                direction = Vector3.Normalize(target.transform.position - transform.position);
                gameObject.GetComponent<Rigidbody>().AddForce(direction * flySpeed);
                gameObject.GetComponent<Rigidbody>().drag = 5;
            }
            else {
                gameObject.GetComponent<Rigidbody>().drag = 0;
                found_Targ = false;
            }

            
  
        }
        else { direction = new Vector3(0 , 0, 0); }
	}
    /*
        IEnumerator move()
        {

        }*/
    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "terrain")
        {
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
        else if (coll.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
        else if (coll.gameObject.tag == "enemy")
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);

        }
    }

    void OnTriggerStay(Collider coll) {
        if (coll.gameObject.tag == "enemy" && found_Targ == false) {
            target = coll.gameObject.transform;
            found_Targ = true;
        }
    }
    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "enemy" && found_Targ == true)
        {
            target = null;
            found_Targ = false;
        }
    }
}
