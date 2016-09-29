using UnityEngine;
using System.Collections;

public class objectPool : MonoBehaviour
{
    public GameObject[] List;
    public GameObject[] Child;

    public GameObject Orb;
    public GameObject Orb2;

    public int Sum;
    public int Sum2;

    public int usage = 0;
    public bool spawn = false;
    public bool enemy;
    public GameObject Zonelist;
    public GameObject idgiver;
    public Transform point;
    public GameObject bullets;
    public sorter note;
    public Octo_sort note2;
    GameObject Pin;
    float turn;

    //public bool turnoff;
    // Use this for initialization
    void Start()
    {


        if (spawn)
        {
            List = new GameObject[Sum];
            Child = new GameObject[Sum2];

            for (int i = 0; i < Sum; i++)
            {

                GameObject bullet = Instantiate(Orb, transform.position, transform.rotation) as GameObject;
                bullet.transform.SetParent(gameObject.transform);
                bullet.SetActive(false);
                List[i] = bullet;
                if (Orb2 != null)
                {
                    GameObject bullet2 = Instantiate(Orb2, transform.position, transform.rotation) as GameObject;
                    bullet2.transform.SetParent(transform);
                    bullet2.SetActive(false);
                    Child[i] = bullet2;
                }
                if (List[i].GetComponent<sorter>() != null)
                {
                    note = List[i].GetComponent<sorter>();
                   note.set_List(Zonelist);
                    note.setIDpool(idgiver);
                }
                if (List[i].GetComponent<Octo_sort>() != null)
                {
                    note2 = List[i].GetComponent<Octo_sort>();
                    note2.setIDpool(idgiver);
                    note2.set_List(Zonelist);

                }

            }
        }

    }


    // Update is called once per frame
    public void startBullet(Transform GunPoint)
    {
        if(List[usage].activeSelf == true)
        {
            List[usage].SetActive(false);

        }
        List[usage].transform.SetParent(gameObject.transform);
        List[usage].transform.position = GunPoint.position;
        List[usage].transform.rotation = GunPoint.rotation;
        List[usage].SetActive(true);
        usage++;
        if (usage >= List.Length)
        {
            usage = 0;
        }

    }
    public void startEnemy(Transform GunPoint)
    {
        List[usage].SetActive(true);
        //Child[usage].transform.SetParent(List[usage].transform);
        Child[usage].transform.position = GunPoint.position;
        Child[usage].transform.rotation = GunPoint.rotation;
        

        Child[usage].SetActive(true);
        if (Child[usage].GetComponent<sorter>() != null)
        {
            Child[usage].GetComponent<sorter>().set_List(Zonelist);
            Child[usage].GetComponent<sorter>().Id_Assign = idgiver;
        }
        if (Child[usage].GetComponent<Octo_sort>() != null)
        {
            Child[usage].GetComponent<Octo_sort>().set_List(Zonelist);
            Child[usage].GetComponent<Octo_sort>().Id_Assign = idgiver;
        }
        Child[usage].GetComponent<faceScript>().setAmmo(bullets);
        Child[usage].GetComponent<faceScript>().target = List[usage].GetComponent<giveChild>().targ();

        usage++;
        if (usage >= List.Length)
        {
            usage = 0;
        }
    }
    public GameObject GetBullet()
    {

        return List[usage];

    }
    public bool checkInactive()
    {
        for (int i = 0; i < List.Length; i++)
        {

            if (!List[i].activeSelf)
            {
                return true;
            }
        }
        return false;
    }
    //gives back a inactive gameobject ID, gives -1 if contains no inactive unit.
    public int getInactiveID()
    {
        for (int i = 0; i < List.Length; i++)
        {

            if (!List[i].activeSelf)
            {
                return i;
            }
        }
        return -1;
    }
    public int getNullID()
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
    public int ListSum()
    {
        return List.Length;
    }
}
