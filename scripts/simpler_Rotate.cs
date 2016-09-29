using UnityEngine;
using System.Collections;

public class simpler_Rotate : MonoBehaviour
{

    public Transform target;
    public Vector3 feuler;
    public Vector3 euler;

    // Use this for initialization
    void Start()
    {
    
    }

// Update is called once per frame
void Update()
    {
        Vector3 targetDir = target.position - transform.position;
        float step = 5f * Time.deltaTime;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
        Debug.DrawRay(transform.position, newDir, Color.red);
        transform.rotation = Quaternion.LookRotation(newDir);

        /*
        feuler = pointer.eulerAngles;
        euler = transform.eulerAngles;
        turnTO( 0.5f, 5);
        */
    }
    public void turnTO( float speed, float limit)
    {
        float x = 0;
        float y = 0;
        float z = 0;
        bool rx;
        bool ry = false;
        bool rz = false;
        if (euler.x > 360) { euler.x -= 360; }
        if (euler.x < -360) { euler.x += 360; }
        if (euler.y > 360) { euler.y -= 360; }
        if (euler.y < -360) { euler.y += 360; }
        if (euler.z > 360) { euler.z -= 360; }
        if (euler.z < -360) { euler.z += 360; }
        if ((feuler.x - euler.x) > limit || (feuler.x - euler.x) < -limit)
        {
            Debug.Log("" + (feuler.x - euler.x));
            x = ((feuler.x - euler.x) / speed);
            rx = true;
        }
        else { rx = false; }
      
        if ((feuler.y - euler.y) > limit || (feuler.y - euler.y) < -limit)
        {
            y = ((feuler.y - euler.y) / speed);
            ry = true;
        }
        else { ry = false; }
    
        if ((feuler.z - euler.z) > limit || (feuler.z - euler.z) < -limit)
        {
            z = ((feuler.z - euler.z) / speed);
            rz = true;
        }
        else { rz = false; }
       

        if(rx || ry || rz)
        {
            transform.rotation = Quaternion.Euler(euler.x + x * Time.deltaTime, euler.y + y * Time.deltaTime, euler.z + z * Time.deltaTime);

        }

    }
}
