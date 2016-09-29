using UnityEngine;
using System.Collections;
//using System;

public class HomingScipt : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float step;
    public Transform forward;
    private Octo_sort sortList;
    private catagorize Pool;
    int bounce = 3;

    // Use this for initialization
    void Start()
    {
        step = speed * Time.deltaTime;
        //getNewTarg();
    }

    // Update is called once per frame
    void Update()
    {
        sortList = gameObject.GetComponent<Octo_sort>();


        if (target != null && target.gameObject.activeSelf == true)
        {
            //transform.LookAt(target);
            Vector3 targetDir = target.position - transform.position;
            float turnstep = 0.5f * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, turnstep, 0.0F);
            //Debug.DrawRay(transform.position, newDir, Color.red);
            transform.rotation = Quaternion.LookRotation(newDir);
        }
        else if (target == null || !target.gameObject.activeSelf == true)
        {
            Pool = sortList.passZone();
            target = Pool.lockon(transform);


        }
      
        if (target == null) { target = forward; }
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

    }
    public void getNewTarg()
    {
        target = sortList.passZone().lockon(transform);
       // bounce--;
    }
    public void setTarget(Transform home_in)
    {
        target = home_in;
        if(home_in = null)
        {
            target = forward;
        }
    }
}
