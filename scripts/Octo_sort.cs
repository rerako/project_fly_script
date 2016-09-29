using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Octo_sort : MonoBehaviour
{
    //amount of segments + 1 for leaf
    public int segments;
    //current branch, last game object is leaf
    public GameObject[] branch;
    //entire tree;
    public GameObject tree;
    public int[] idcode;
    int total_box;
    public GameObject leafNode;
    public octree_07 tree_bark;
    public catagorize List;
    public int id_numb;
    public GameObject Id_Assign;
    public float bounds;
    public int x = -1;
    public int y = -1;
    public int z = -1;
    public int headingTo = 0;
    public int currentZone = 0;
    // Use this for initialization
    void Start()
    {
        if (gameObject.CompareTag("Moot"))
        {
        }
        else {
            id_numb = Id_Assign.GetComponent<ID_Assigner>().getID(transform);
        }
        tree_bark = tree.GetComponent<octree_07>();
        bounds = tree_bark.giveDim();

        segments = tree_bark.giveLim();
        total_box = (int)Mathf.Pow(2, (segments + 1));

        branch = new GameObject[segments + 1];
        idcode = new int[segments + 1];

        setbound(transform.position);
        headingTo = (x * (total_box * total_box)) + (y * total_box) + z;
        currentZone = (x * (total_box * total_box)) + (y * total_box) + z; ;
        List = tree_bark.get_object(x, y, z);
        List.Add_Test(gameObject);

    }

    // Update is called once per frame

    void Update()
    {
        setbound(transform.position);
        /*
        leafNode = tree_bark.GrabZone(gameObject);
        
        if (!leafNode.GetComponent<catagorize>().CheckID(idcode))
        {
            if (List != null)
            {
                List.Remove_Test(gameObject);
            }
            List = leafNode.GetComponent<catagorize>();
            List.Add_Test(gameObject);
            idcode = List.getID();
        }*/

        headingTo = (x * (total_box * total_box))  + (y * total_box) + z;
        if (headingTo != currentZone)
        {

            currentZone = headingTo;
            if (!gameObject.CompareTag("Moot"))
            {
                remove_Object();
            }
            if(List != tree_bark.get_object(x, y, z))
            {
                List = tree_bark.get_object(x, y, z);
                if (!gameObject.CompareTag("Moot"))
                {
                    List.Add_Test(gameObject);
                }
            }



        }


    }
    //empties object collide moot 

    // no longer needed object collides

    //public bool check

    public void setIDpool(GameObject idgiver)
    {
        Id_Assign = idgiver;
    }
    public void set_List(GameObject ZoneSorter)
    {
        tree = ZoneSorter;

    }
    public void remove_Object()
    {
        List.Remove_Test(gameObject);

    }

    public catagorize passZone()
    {
        return List;
    }
    public void setbound(Vector3 transformposition)
    {
        //below 0
        if (x != -1 && transformposition.x < 0)
        {
            x = -1;
        }
        //above zero
        else if (x != -1 && transformposition.x / bounds >= total_box)
        {
            x = -1;
        }
        //inbetween
        else
        {
            if (x != (int)(transformposition.x / bounds))
            {
                x = (int)(transformposition.x / bounds);

            }
        }
        if (y != -1 && transformposition.y < 0)
        {
            y = -1;
        }
        else if (y != -1 && transformposition.y / bounds >= total_box)
        {
            y = -1;
        }
        else
        {
            if (y != (int)(transformposition.y / bounds))
            {
                y = (int)(transformposition.y / bounds);
            }
        }
        if (z != -1 && transformposition.z < 0)
        {
            z = -1;
        }
        else if (z != -1 && transformposition.z / bounds >= total_box)
        {
            z = -1;
        }
        else
        {
            if (z != (int)(transformposition.z / bounds))
            {
                z = (int)(transformposition.z / bounds);
            }
        }
    }

}
