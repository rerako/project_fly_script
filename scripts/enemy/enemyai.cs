using UnityEngine;
using System.Collections;

public class enemyai : MonoBehaviour
{
    public float bSpeed;
    public Transform forward;
    public float turnSpeed;
    public BoxCollider front;
    public BoxCollider body;

    public bool choice = false;
    public bool choice2 = false;
    public bool choice3 = false;
    public bool choice4 = false;
    public bool choice5 = false;

    public Transform turnup;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, forward.position, bSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, turnup.rotation, 0.7f);

        if (choice)
        {
            transform.Rotate(transform.up * turnSpeed * Time.deltaTime, Space.Self);

        }
        else if (choice2)
        {
            transform.Rotate(transform.up * -turnSpeed * Time.deltaTime, Space.Self);

        }
        
        if (choice3)
        {
            transform.Rotate(transform.up * turnSpeed * 2 * Time.deltaTime, Space.Self);
            choice4 = false;

        }
        /*
        if (choice4)
        {
            transform.Rotate(transform.right * -turnSpeed * Time.deltaTime, Space.Self);
        }
        else if (choice5)
        {

            transform.Rotate(transform.right * turnSpeed * Time.deltaTime, Space.Self);
            if (choice3) { choice5 = false; }
        }
        */
    }

    void OnTriggerStay(Collider coll)
    {
        if (coll.gameObject.CompareTag("obstacle")|| coll.gameObject.CompareTag("enemy"))
        {
            Vector3 relativePoint = transform.InverseTransformDirection(coll.gameObject.transform.position);
            if (relativePoint.x <= 0.0 && choice3 == false)
            {
                choice = true;
                //   transform.Rotate(transform.up * -turnSpeed , Space.Self);
            }
            else if (relativePoint.x > 0.0 && choice3 == false)
            {
                choice2 = true;
                //   transform.Rotate(transform.up * -turnSpeed , Space.Self);
            }
            if (choice == true && choice2 == true)
            {
                choice3 = true;
                choice = false;
                choice2 = false;
                choice5 = false;
            }
            /*
            if (relativePoint.y <= 0.0 && choice3 == false)
            {
                choice4 = true;
            }
            else if (relativePoint.y > 0.0 && choice3 == false)
            {
                choice5 = true;
            }
            */


        }


    }
    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.CompareTag("obstacle"))
        {
            if (choice)
                choice = false;
            else if (choice2)
                choice2 = false;
            if (!choice && !choice2)
                choice3 = false;
            if (choice4)
            {
                choice4 = false;
            }
            if (choice5)
            {
                choice5 = false;
            }
        }

    }
}