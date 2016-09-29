using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class inside : MonoBehaviour
{
    public List<int> enemyList;
    public List<int> enemy2List;

    public List<int> bulletList;
    public List<int> allyList;
    public int bul_amount = 0;
    public int enemy_amount = 0;
    public int enemy2_amount = 0;

    public int ally_amount = 0;
    public bool player;
    public GameObject bloom;
    public objectPool bloomPool;

    int y;
    int x;
    //int full_list = 0;
    public int death = 0;
    public GameObject[] enemy_Test;
    public GameObject[] enemy2_Test;

    public GameObject[] ally_Test;
    public GameObject[] bullet_Test;
    public float distColl;

    int dmg;
    int dmg2;
    // Use this for initialization
    void Start()
    {
        dmg = 50;
        dmg2 = 100;
        if (bloom != null)
        {
            bloomPool = bloom.GetComponent<objectPool>();
        }
        enemy_Test = new GameObject[3000];
        enemy2_Test = new GameObject[500];

        ally_Test = new GameObject[1000];
        bullet_Test = new GameObject[500];

    }

    // Update is called once per frame
    void Update()
    {
        if (ally_amount > 0)
        {
            facetarget();
        }
        gather();
        collisiondetect();

        /*
       if (enemy_amount < 0) { enemy_amount = 0; }
       if (bul_amount < 0) { bul_amount = 0; }
       if (ally_amount < 0) { ally_amount = 0; }


       */

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
                        if (Vector3.Distance(enemy_Test[enemyList[i]].transform.position, ally_Test[allyList[j]].transform.position) < 20)
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
        bloomPool.startBullet(Destroyed_Object.transform);

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
                    if (Vector3.Distance(enemy_Test[enemyList[i]].transform.position, bullet_Test[bulletList[j]].transform.position) < 6)
                    {

                        collision_Hit(bullet_Test[bulletList[j]], enemy_Test[enemyList[i]]);
                        break;
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
                    if (Vector3.Distance(enemy2_Test[enemy2List[i]].transform.position, bullet_Test[bulletList[j]].transform.position) < 3)
                    {

                        collision_Hit(bullet_Test[bulletList[j]], enemy2_Test[enemy2List[i]]);
                        break;
                    }
                }

            }
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

        x = col.GetComponent<sorter>().id_numb;



        if (col.transform.CompareTag("enemy"))
        {
            if (x >= 0 && enemy_Test[x] == null)
            {

                enemy_Test[x] = col;
                enemyList.Add(x);
                enemy_amount += 1;
            }
        }
        if (col.transform.CompareTag("enemy2"))
        {
            if (x >= 0 && enemy2_Test[x] == null)
            {

                enemy2_Test[x] = col;
                enemy2List.Add(x);
                enemy2_amount += 1;
            }
        }
        if (col.transform.CompareTag("bullet") || col.transform.CompareTag("bullet2"))
        {
            if (x >= 0 && bullet_Test[x] == null)
            {
                bullet_Test[x] = col;
                bulletList.Add(x);
                bul_amount += 1;

            }
        }
        if (col.transform.CompareTag("ally") || col.transform.CompareTag("Player"))
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
        y = col.GetComponent<sorter>().id_numb;

        if (col.transform.CompareTag("enemy"))
        {
            if (enemy_Test[y] != null)
            {
                enemy_Test[y] = null;
                enemyList.Remove(y);
                enemy_amount -= 1;
            }
        }
        if (col.transform.CompareTag("enemy2"))
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
