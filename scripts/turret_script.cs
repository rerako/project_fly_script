using UnityEngine;
using System.Collections;

public class turret_script : MonoBehaviour
{
    public Transform target;
    public bool shooting;
    public bool chasing;
    public objectPool ebulletList;
    public bool y;
    float angle;
    WaitForSeconds firerate;
    WaitForSeconds bTime;
    public Transform cannonhole;
    public GameObject EbulletPool;

    // Use this for initialization
    void Start()
    {
        firerate = new WaitForSeconds(0.5f);
        bTime = new WaitForSeconds(0.5f);
        angle = 20;

    }

    // Update is called once per frame
    void Update()
    {
        if (y)
        {
            if (chasing && Vector3.Distance(target.position, transform.position) < 40 && target.position.y > transform.position.y)
            {

                Vector3 targetDir = target.position - transform.position;
                float step = 2f * Time.deltaTime;
                Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
                //Debug.DrawRay(transform.position, newDir, Color.red);
                transform.rotation = Quaternion.LookRotation(newDir);
                turret_fire();
            }
            else
            {
                chasing = false;
            }
        }
        if (!y)
        {
            if (chasing && Vector3.Distance(target.position, transform.position) < 40 && target.position.y < transform.position.y)
            {

                Vector3 targetDir = target.position - transform.position;
                float step = 1f * Time.deltaTime;
                Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
                //Debug.DrawRay(transform.position, newDir, Color.red);
                transform.rotation = Quaternion.LookRotation(newDir);
                turret_fire();
            }
            else
            {
                //chasing = false;
            }
        }


    }
    public void setTarget(Transform bogey)
    {
        target = bogey;
        chasing = true;
    }
    IEnumerator cannon()
    {
        yield return firerate;
        shooting = false;
    }

    public void setAmmo(GameObject ammo_box)
    {
        EbulletPool = ammo_box;
    }
    IEnumerator off(GameObject bullet)
    {

        yield return bTime;
        bullet.SetActive(false);

        //bullet.SetActive(false);


    }
    private void turret_fire()
    {

        if (!shooting && Vector3.Angle(target.position - transform.position, transform.forward) < angle)
        {

            shooting = true;
            GameObject bullet = ebulletList.GetBullet();
            bullet.GetComponent<TrailRenderer>().Clear();
            ebulletList.startBullet(cannonhole);
            StartCoroutine(off(bullet));
            StartCoroutine("cannon");
        }


    }
}
