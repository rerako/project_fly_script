using UnityEngine;
using System.Collections;

public class faceScript : MonoBehaviour
{
    public Transform moveTo;
    public Transform forward;
    public Transform target;
    public bool chasing;
    public bool legion = false;
    public bool facing;
    public Vector3 rando;
    public float angle = 5;
    public objectPool ebulletList;
    public float bSpeed;
    public float range;
    public float flyspeed = 15;
    // public Transform transform;
    public float r_Speed;
    public float timer;
    //private WaitForSeconds targ_timer;
    private WaitForSeconds firerate;
    private WaitForSeconds bTime;
    public int idNumber;
    public bool numel;
    public int targ_cha_dist;
    public float distance;
    public bool shooting = false;
    public bool leader;
    float turn;
    public GameObject EbulletPool;
    public Transform cannonhole;


    // Use this for initialization
    void Start()
    {
        if (leader)
        {
            turn = r_Speed * Time.deltaTime;
        }
        else {
            turn = 60 * Time.deltaTime;
        }
        //turn = 60; a very weird reaction turn speed to zero

        firerate = new WaitForSeconds(0.1f);
        //targ_timer = new WaitForSeconds(1.5f);
        bTime = new WaitForSeconds(3f);
        chasing = false;

        StartCoroutine("cannon");
        ebulletList = EbulletPool.GetComponent<objectPool>();
        rando = new Vector3(Random.Range(0, range), Random.Range(0, range), Random.Range(0, range));

    }

    // Update is called once per frame
    void Update()
    {

        if (!legion)
        {

            iftests();

            if (numel)
            {
                LookTarg();
            }
            setMoveTarg();
            move();
        }

        //if  facing an opponent && still not facing target:
        //      it must slowly turn towards target location

    }
    public void gathered()
    {
        legion = !legion;
    }

    private void iftests()
    {
        if (chasing)
        {

            if (shooting == false && Vector3.Dot( target.position, transform.position) > 0 && Vector3.Angle(target.position - transform.position, transform.forward) < angle)
            {

                shooting = true;
                GameObject bullet = ebulletList.GetBullet();
                /*
                if (bul1)
                {
                    bullet.GetComponent<Rigidtransform>().velocity = Vector3.zero;
                    bullet.GetComponent<Rigidtransform>().angularVelocity = Vector3.zero;

                }
                */
                bullet.GetComponent<TrailRenderer>().Clear();

                ebulletList.startBullet(cannonhole);
                StartCoroutine(off(bullet));
                StartCoroutine("cannon");
            }

        }
    }
    private void LookTarg()
    {
        forward.LookAt(moveTo.position);
    }
    private void setMoveTarg()
    {
        if (numel && moveTo != null)
        {


            //reaches within distance range to select a new target to move towards
            //distance = Vector3.Distance(transform.position, target.position);
            distance = squaredDist_Mag(transform, target);
            setnewRand();
            if (!moveTo.gameObject.CompareTag("Player") && distance < targ_cha_dist * targ_cha_dist)
            {
                target.position = rando;
                gazeAt(target);
                chasing = false;

            }
            // chasing player: gives up
            else if ((moveTo.gameObject.CompareTag("Player") || moveTo.gameObject.CompareTag("ally")) && distance > (targ_cha_dist * targ_cha_dist * 2))
            {
                target.position = rando;
                gazeAt(target);
                chasing = false;
            }


        }
        else
        {
            target.position = rando;
            gazeAt(target);
            chasing = false;
        }
        setnewRand();

    }


    private void move()
    {

        if (chasing || (Vector3.Angle(target.position - transform.position, transform.forward) > angle && timer >= 0))
        {
            timer -= Time.deltaTime;
            //turn towards target location
            transform.rotation = Quaternion.RotateTowards(transform.rotation, forward.rotation, turn);

            /*
            Vector3 targetDir = moveTo.position - transform.position;
            float step = 1f * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
            //Debug.DrawRay(transform.position, newDir, Color.red);
            transform.rotation = Quaternion.LookRotation(newDir);
            */
            numel = true;
        }
        else
        {
            if (!leader)
            {
                numel = false;
                timer = Random.Range(2f, 3f);
            }
            else
            {
                timer = Random.Range(5f, 7f);
            }

        }




        if (chasing)
        {
            transform.position = transform.position + transform.forward * Time.deltaTime * (flyspeed + 5);
        }
        else
        {
            transform.position = transform.position + transform.forward * Time.deltaTime * flyspeed;

        }

    }
    public bool league()
    {
        return legion;
    }
    public void following()
    {
        legion = true;
    }
    public void freed()
    {
        legion = false;
    }
    public Transform targeting()
    {
        return target;

    }


    public void gazeAt(Transform move)
    {
        moveTo = move;
        if (move.gameObject.CompareTag("ally") || move.gameObject.CompareTag("Player"))
        {
            chasing = true;
        }

    }
    private void setnewRand()
    {
        rando = new Vector3(Random.Range(0, range), Random.Range(0, range), Random.Range(0, range));


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
    public float squaredDist_Mag(Transform player, Transform enemy)
    {
        Vector3 offset = enemy.position - player.position;
        float sqrLen = offset.sqrMagnitude;
        return sqrLen;
    }
}