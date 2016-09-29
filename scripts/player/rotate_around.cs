using UnityEngine;
using System.Collections;
using System;
public class rotate_around : MonoBehaviour
{
    public float speed;
    public float flyspeed;
    public float bSpeed;
    public Transform foward;
    public GameObject bullet;
    bool faith = true;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.Space))
        {
           // transform.rotation = Quaternion.Lerp(transform.rotation, foward.rotation, 0.2f * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.Space) && faith == true)
        {
            StartCoroutine(fire());
        }
    }
    void FixedUpdate() {
        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * flyspeed * Time.deltaTime);
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * speed * Time.deltaTime, Space.Self);
            //  transform.Rotate(Vector3.forward * Input.GetAxis("Horizontal") * speed * 0.5f, Space.Self);

        }
        if (Input.GetAxis("Vertical") != 0)
        {
            transform.Rotate(Vector3.right * Input.GetAxis("Vertical") * speed * Time.deltaTime, Space.Self);

        }


    }
    void LateUpdate()
    {

    }
        IEnumerator fire()
    {
            faith = false;
            GameObject fire = Instantiate(bullet, foward.position, foward.rotation) as GameObject;
            //fire.transform.SetParent(gameObject.transform);
            fire.GetComponent<Rigidbody>().AddForce(transform.forward * bSpeed);
            Destroy(fire, 0.3f);
            yield return new WaitForSeconds(1f);
            faith = true;
        
    }
}