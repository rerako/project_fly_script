using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class catagorize : MonoBehaviour
{
    public List<int> enemyList;
    public List<int> enemy2List;
    public List<int> bulletList;
    public List<int> bullet2List;

    public List<int> allyList;
    public int listID = -1;
    public int bul_amount = 0;
    public int bul2_amount = 0;
    public int random_choice = 0;
    public int enemy_amount = 0;
    public int enemy2_amount = 0;
    public int ally_amount = 0;
    public bool player;
    public GameObject bloom;
    public objectPool bloomPool;
    public octree_07 Stump;
    Transform target = null;

    //int full_list = 0;
    public int death = 0;
    //convert all object references to octosort...
    public GameObject[] enemy_Test;
    //public faceScript[] enemy_FaceScpt;
    public GameObject[] enemy2_Test;

    public GameObject[] ally_Test;
    public GameObject[] bullet_Test;
    public GameObject[] bullet2_Test;

    public int[] code;
    int y;
    int x;
    int dmg;
    int dmg2;
    // Use this for initialization
    void Start()
    {
        dmg = 50;
        dmg2 = 50;
        enemy_Test = new GameObject[3000];
        enemy2_Test = new GameObject[500];

        ally_Test = new GameObject[1000];
        bullet_Test = new GameObject[500];
        bullet2_Test = new GameObject[500];

        bloomPool = bloom.GetComponent<objectPool>();


    }

    // Update is called once per frame
    void Update()
    {
        if (enemy_amount > 0)
        {
            //Profiler.BeginSample("gather");
            gather();

        }
        if (ally_amount > 0)
        {
            facetarget();
        }

        if (bul_amount > 0)
        {
            collisiondetect();
        }


        /*
       if (enemy_amount < 0) { enemy_amount = 0; }
       if (bul_amount < 0) { bul_amount = 0; }
       if (ally_amount < 0) { ally_amount = 0; }


       */

    }
    public void setStump(GameObject seed)
    {
        Stump = seed.GetComponent<octree_07>();

    }
    public bool CheckID(int[] bar)
    {
        if (bar == code)
        {
            return true;
        }
        else { return false; }
    }
    public Transform lockon(Transform homing)
    {
        target = null;
        //Debug.Log("working");

        if (enemy_amount > 0)
        {
            if (random_choice >= enemy_amount || random_choice < 0)
            {
                random_choice = 0;
            }

            else if (enemy_Test[enemyList[random_choice]] != null && enemy_Test[enemyList[random_choice]].activeSelf == true)
            {

                target = enemy_Test[enemyList[random_choice]].transform;

                random_choice = random_choice + 1;
                if (random_choice > enemy_amount)
                {
                    random_choice = 0;
                }
            }
        }
        else { target = null; }
        return target;
    }

    public int[] getID()
    {
        return code;
    }

    public void setID(int size)
    {
        code = new int[size];
        //barcode = code;
    }
    public void updateBar(int[] bar, int limit)
    {

        for (int x = 0; x < limit; x++)
        {
            code[x] = bar[x];
        }
    }
    public void setBar(int moto, int noto, int ascii)
    {
        code[moto - noto] = ascii;
        //Debug.Log("" + ascii);


    }
    public void gather()
    {
        //if both enemy and enemy cap exist
        if (enemy2_amount > 0 && enemy_amount > 0)
        {
            //for each leader 

            for (int y = 0; y < enemy2_amount; y++)
            {

                if (!enemy2_Test[enemy2List[y]].GetComponent<setFollower>().stuffed())
                {
                    for (int i = 0; i < enemy_amount; i++)
                    {
                        //for each enemy that has no leader
                        if (enemy_Test[enemyList[i]].GetComponent<faceScript>().league() == false)
                        {
                            //for each leader that has not enough minions
                            if (!enemy2_Test[enemy2List[y]].GetComponent<setFollower>().stuffed())
                            {
                                enemy_Test[enemyList[i]].GetComponent<faceScript>().following();

                                enemy2_Test[enemy2List[y]].GetComponent<setFollower>().addFol(enemy_Test[enemyList[i]]);
                            }
                            else { break; }
                        }
                    }
                }
            }
        }

    }
    public void facetarget()
    {

        if (ally_amount > 0 && enemy_amount > 0)
        {
            for (int i = 0; i < enemy_amount; i++)
            {
                for (int j = 0; j < ally_amount; j++)
                {


                    if (enemy_Test[enemyList[i]].GetComponent<faceScript>().chasing == false)
                    {
                        if (squaredDist_Mag(ally_Test[allyList[j]].transform, enemy_Test[enemyList[i]].transform, 30))
                        {
                            enemy_Test[enemyList[i]].GetComponent<faceScript>().gazeAt(ally_Test[allyList[j]].transform);
                            break;
                        }
                    }
                }
            }
        }
    }

    // function collision  position center based
    void collision_Hit(GameObject bullet, GameObject Destroyed_Object)
    {
        //need to add checking for enemyhealth////////////////

        enemyHp hp = Destroyed_Object.GetComponent<enemyHp>();
        if (bullet.transform.CompareTag("bullet"))
        {
            hp.minus(dmg);
        }
        else if (bullet.transform.CompareTag("bullet2"))
        {
            hp.minus(dmg2);
        }
        if (!hp.survive())
        {
            bloomPool.startBullet(Destroyed_Object.transform);
            if (Destroyed_Object.transform.CompareTag("enemy2"))
            {
                Destroyed_Object.GetComponent<setFollower>().setFree();
            }
            Remove_Test(Destroyed_Object);

            Destroyed_Object.SetActive(false);
            death += 1;
            playerHealth.score += 1;

        }
        if (!bullet.transform.CompareTag("bullet2"))
        {
            Remove_Test(bullet);

            bullet.SetActive(false);
        }

        /*
        ///////////////////////////////////////
        bloomPool.startBullet(Destroyed_Object.transform);

        Remove_Test(Destroyed_Object);
        if (!bullet.transform.CompareTag("bullet2"))
        {
            Remove_Test(bullet);

            bullet.SetActive(false);
        }
        Destroyed_Object.SetActive(false);
        death += 1;*/
    }
    public void setPool(GameObject pool)
    {
        bloom = pool;

    }
    public void collisiondetect()
    {

        if (bul_amount > 0 && enemy_amount > 0)
        {
            for (int i = 0; i < enemy_amount; i++)
            {
                for (int j = 0; j < bul_amount; j++)
                {
                    if (Vector3.Dot(enemy_Test[enemyList[i]].transform.position, bullet_Test[bulletList[j]].transform.position) > 0)
                    {
                        if (squaredDist_Mag(bullet_Test[bulletList[j]].transform, enemy_Test[enemyList[i]].transform, 4))
                        {
                            collision_Hit(bullet_Test[bulletList[j]], enemy_Test[enemyList[i]]);
                            break;
                        }
                    }

                }

            }
        }
        if (bul_amount > 0 && enemy2_amount > 0)
        {
            for (int i = 0; i < enemy2_amount; i++)
            {
                for (int j = 0; j < bul_amount; j++)
                {
                    if (Vector3.Dot(enemy2_Test[enemy2List[i]].transform.position, bullet_Test[bulletList[j]].transform.position) > 0)
                    {
                        if (squaredDist_Mag(bullet_Test[bulletList[j]].transform, enemy2_Test[enemy2List[i]].transform, 2))
                        {

                            random_choice -= 1;

                            collision_Hit(bullet_Test[bulletList[j]], enemy2_Test[enemy2List[i]]);
                            if (random_choice > enemy_amount)
                            {
                                random_choice = 0;
                            }
                            break;
                        }
                    }
                }

            }
        }
        if (bul2_amount > 0 && enemy_amount > 0)
        {
            for (int i = 0; i < enemy_amount; i++)
            {
                for (int j = 0; j < bul2_amount; j++)
                {
                    if (Vector3.Dot(enemy_Test[enemyList[i]].transform.position, bullet2_Test[bullet2List[j]].transform.position) > 0)
                    {
                        if (squaredDist_Mag(bullet2_Test[bullet2List[j]].transform, enemy_Test[enemyList[i]].transform, 6))
                        {

                            collision_Hit(bullet_Test[bullet2List[j]], enemy_Test[enemyList[i]]);
                            break;
                        }
                        /*
                      if (Vector3.Distance(enemy_Test[enemyList[i]].transform.position, bullet2_Test[bullet2List[j]].transform.position) < 6)
                      {

                          collision_Hit(bullet_Test[bullet2List[j]], enemy_Test[enemyList[i]]);
                          break;
                      }
                      */
                    }
                }

            }
        }
        if (bul2_amount > 0 && enemy2_amount > 0)
        {
            for (int i = 0; i < enemy2_amount; i++)
            {
                for (int j = 0; j < bul2_amount; j++)
                {
                    if (Vector3.Dot(enemy2_Test[enemy2List[i]].transform.position, bullet2_Test[bullet2List[j]].transform.position) > 0)
                    {
                        if (squaredDist_Mag(bullet2_Test[bullet2List[j]].transform, enemy2_Test[enemy2List[i]].transform, 6))
                        {

                            collision_Hit(bullet_Test[bullet2List[j]], enemy2_Test[enemy2List[i]]);
                            break;
                        }

                    }
                }

            }
        }
    }

    public bool squaredDist_Mag(Transform bul, Transform enemy, float hitZone)
    {
        Vector3 offset = enemy.position - bul.position;
        float sqrLen = offset.sqrMagnitude;
        if (sqrLen < hitZone * hitZone)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public int getInactiveID(GameObject[] List)
    {
        for (int i = 0; i < List.Length; i++)
        {

            if (List[i] == null)
            {
                return i;
            }
        }
        return -1;
    }
    //functions to add / remove from list
    public int List_amount(GameObject[] List)
    {
        if (List == bullet_Test)
        {
            return bul_amount;
        }
        else if (List == bullet2_Test)
        {
            return bul2_amount;
        }
        else if (List == ally_Test)
        {
            return ally_amount;
        }
        else
        {
            return enemy_amount;
        }
    }
    public void Add_Test(GameObject col)
    {

        x = col.GetComponent<Octo_sort>().id_numb;



        if (col.transform.CompareTag("enemy"))
        {
            if (x >= 0 && enemy_Test[x] == null)
            {

                enemy_Test[x] = col;
                enemyList.Add(x);
                enemy_amount += 1;
            }
        }
        else if (col.transform.CompareTag("enemy2"))
        {
            if (x >= 0 && enemy2_Test[x] == null)
            {

                enemy2_Test[x] = col;
                enemy2List.Add(x);
                enemy2_amount += 1;
            }
        }
        else if (col.transform.CompareTag("bullet") || col.transform.CompareTag("bullet2"))
        {
            if (x >= 0 && bullet_Test[x] == null)
            {
                bullet_Test[x] = col;
                bulletList.Add(x);
                bul_amount += 1;

            }
        }
        else if (col.transform.CompareTag("ally") || col.transform.CompareTag("Player"))
        {
            if (x >= 0 && ally_Test[x] == null)
            {
                ally_Test[x] = col;
                allyList.Add(x);
                ally_amount += 1;
            }
        }
    }
    public void Remove_Test(GameObject col)
    {
        y = col.GetComponent<Octo_sort>().id_numb;

        if (col.transform.CompareTag("enemy"))
        {
            if (enemy_Test[y] != null)
            {

                enemy_Test[y] = null;
                enemyList.Remove(y);
                enemy_amount -= 1;

            }
        }
        else if (col.transform.CompareTag("enemy2"))
        {
            if (enemy2_Test[y] != null)
            {
                enemy2_Test[y] = null;
                enemy2List.Remove(y);
                enemy2_amount -= 1;
            }
        }
        else if (col.transform.CompareTag("bullet") || col.transform.CompareTag("bullet2"))
        {
            if (bullet_Test[y] != null)
            {
                bullet_Test[y] = null;
                bulletList.Remove(y);
                bul_amount -= 1;
            }
        }
        else if (col.transform.CompareTag("ally") || col.transform.CompareTag("Player"))
        {
            if (ally_Test[y])
            {
                ally_Test[y] = null;
                allyList.Remove(y);
                ally_amount -= 1;
            }
        }

    }

}
