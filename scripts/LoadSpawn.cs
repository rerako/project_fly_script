using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LoadSpawn : MonoBehaviour
{
    public List<GameObject> Items;
    public float Timer = 0;
    public bool block;
    public GameObject cam;
    int x = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
        }
        else
        {
            Items[x].SetActive(true);
            x++;
            Timer = 1f;
        }

        if (x == Items.Count) {
            cam.SetActive(false);
            gameObject.SetActive(false);
        }
    }
    
}
