using UnityEngine;
using System.Collections;
/*
    get rid of collide hill next round...



*/

public class sorter : MonoBehaviour
{
    public int x = -1;
    public int y = -1;
    public int z = -1;
    public int boundary;
    public int limit;
    public int currentZone = 0;
    public int headingTo = 0;
    public GameObject ZoneList;
    public octree_sample linkedlist;
    public GameObject Collidehill;
    public inside listing;
    private Vector3 transformposition;
    public bool notimer;
    public GameObject Id_Assign;
    public int id_numb;
    WaitForSeconds shortWait;
    // Use this for initialization
    void Start()
    {
        id_numb = Id_Assign.GetComponent<ID_Assigner>().getID(transform);
        linkedlist = ZoneList.GetComponent<octree_sample>();
        boundary = linkedlist.dimension;
        limit = linkedlist.limit;
        setbound();
        currentZone = x * 16 + y * 4 + z;
        if (Collidehill == null)
        {
            Collidehill = linkedlist.get_object(x, y, z);
        }
        listing = Collidehill.GetComponent<inside>();

        listing.Add_Test(gameObject);

    }
    // Update is called once per frame
    void Update()
    {
        transformposition = transform.position;


        setbound();


        headingTo = x * 16 + y * 4 + z;
        if (headingTo != currentZone)
        {
            currentZone = headingTo;
            remove_Object();
            Collidehill = linkedlist.get_object(x, y, z);
            listing = Collidehill.GetComponent<inside>();
            listing.Add_Test(gameObject);


        }





    }
    public void setIDpool(GameObject idgiver)
    {
        Id_Assign = idgiver;
    }
    public void remove_Object()
    {
        listing.Remove_Test(gameObject);

    }
    public void set_List(GameObject ZoneSorter)
    {
        ZoneList = ZoneSorter;

    }
    public void setbound()
    {
        //below 0
        if (x != -1 && transformposition.x < 0)
        {
            x = -1;
        }
        //above zero
        else if (x != -1 && transformposition.x / boundary >= limit)
        {
            x = -1;
        }
        //inbetween
        else
        {
            if (x != (int)(transformposition.x / boundary))
            {
                x = (int)(transformposition.x / boundary);

            }
        }
        if (y != -1 && transformposition.y < 0)
        {
            y = -1;
        }
        else if (y != -1 && transformposition.y / boundary >= limit)
        {
            y = -1;
        }
        else
        {
            if (y != (int)(transformposition.y / boundary))
            {
                y = (int)(transformposition.y / boundary);
            }
        }
        if (z != -1 && transformposition.z < 0)
        {
            z = -1;
        }
        else if (z != -1 && transformposition.z / boundary >= limit)
        {
            z = -1;
        }
        else
        {
            if (z != (int)(transformposition.z / boundary))
            {
                z =(int)(transformposition.z / boundary);
            }
        }
    }
}
