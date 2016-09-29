using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class octree_sample : MonoBehaviour
{
    public GameObject box;
    public int worldsize;
    public int dimension;
    public int limit = 4;
    public GameObject[,,] ListBush;
    public GameObject otherBox;
    public GameObject bloomPool;
    // Use this for initialization
    void Awake()
    {
        dimension = worldsize / limit;
        ListBush = new GameObject[limit, limit, limit];
        int numb = 1;

        for (int i = 0; i < limit; i++)
        {
            for (int j = 0; j < limit; j++)
            {
                for (int k = 0; k < limit; k++)
                {
                    GameObject point = Instantiate(box, new Vector3(i * dimension, j * dimension, k * dimension), transform.rotation) as GameObject;
                    point.name = numb.ToString();
                    point.GetComponent<inside>().setPool(bloomPool);
                    point.transform.SetParent(gameObject.transform);
                    numb++;
                    ListBush[i, j, k] = point;
                }
            }
        }
    }


    public GameObject get_object(int x, int y, int z)
    {
        if (x >= limit || y >= limit || z >= limit)
        {
            //outside the detection zone
            return otherBox;
        }
        else if (x < 0 || y < 0 || z < 0)
        {
            return otherBox;
        }
        else
        {
            return ListBush[x, y, z];
        }

    }

}
