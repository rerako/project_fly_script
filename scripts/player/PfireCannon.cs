using UnityEngine;
using System.Collections;

public class PfireCannon : MonoBehaviour
{
    public float bSpeed;
    public Transform foward;
    public GameObject bulletPool;
    public objectPool bulletList;
    public GameObject ammo;
    public int bulletID2 = 0;
    public GameObject bulletPool2;
    public objectPool bulletList2;
    public GameObject ammo2;
    public Transform target;
    public float chargeTimer = 0;
    public int bulletID = 0;
    public WaitForSeconds bTime;
    public WaitForSeconds bTime2;

    public WaitForSeconds firerate;
    public WaitForSeconds firerate2;

    bool pace = true;
    bool pace2 = true;

    public bool bul1;
    public GameObject scope;
    public catagorize aimZone;
    // Use this for initialization
    void Start()
    {
        bTime = new WaitForSeconds(1.5f);
        bTime2 = new WaitForSeconds(3f);

        firerate = new WaitForSeconds(0.05f);
        firerate2 = new WaitForSeconds(0.05f);

        bulletList = bulletPool.GetComponent<objectPool>();
        bulletList2 = bulletPool2.GetComponent<objectPool>();

    }

    // Update is called once per frame
    void Update()
    {
        aimZone = scope.GetComponent<Octo_sort>().passZone();
        //target = aimZone.lockon(scope.transform);
        if ((Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Comma)) && pace2 == true)
        {
            StartCoroutine(fire2());
        }
        else if ((Input.GetKeyUp(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Comma)) && chargeTimer > 2f && pace2 == true)
        {
            // create a script that fires missles with octo_sort at the given transform
            if (target != null)
            {
                StartCoroutine(fire2());
            }
            else {
                target = foward;
                StartCoroutine(fire2());
            }
            target = null;
            chargeTimer = 0;
        }
        else if ((Input.GetKey(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Comma)) && chargeTimer < 2f)
        {
            chargeTimer += Time.deltaTime;
            //Debug.Log("squak");
        }
        if (bulletList.ListSum() <= bulletID)
        {
            bulletID = 0;
        }


    }

    IEnumerator fire()
    {
        pace = false;
        //target = aimZone.lockon(scope.transform);

        //bullet.SetActive(true);
        ammo = bulletList.GetBullet();
        /*
        if (bul1) {
            bullet.GetComponent<TrailRenderer>().Clear();
            bullet.GetComponent<Rigidtransform>().velocity = Vector3.zero;
            bullet.GetComponent<Rigidtransform>().angularVelocity = Vector3.zero;
            
        }
        */
        bulletList.startBullet(foward.transform);
        StartCoroutine(off(ammo, bTime));

        yield return firerate;
        pace = true;
        ammo = null;


    }

    IEnumerator fire2()
    {
        pace2 = false;
        target = aimZone.lockon(scope.transform);
        //bullet.SetActive(true);
        ammo2 = bulletList2.GetBullet();
        /*
        if (bul1) {
            bullet.GetComponent<TrailRenderer>().Clear();
            bullet.GetComponent<Rigidtransform>().velocity = Vector3.zero;
            bullet.GetComponent<Rigidtransform>().angularVelocity = Vector3.zero;
            
        }
        */
        bulletList2.startBullet(foward.transform);
        ammo2.GetComponent<HomingScipt>().setTarget(target);
        StartCoroutine(off(ammo2, bTime2));

        yield return firerate2;
        pace2 = true;
        ammo = null;


    }
    IEnumerator off(GameObject bullet, WaitForSeconds hold)
    {
        yield return hold;
        //bullet.GetComponent<sorter>().remove_Object();
        bullet.GetComponent<Octo_sort>().remove_Object();
        bullet.SetActive(false);

        //bullet.SetActive(false);


    }
}
