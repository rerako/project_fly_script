using UnityEngine;
using System.Collections;

public class setFollower : MonoBehaviour
{
    public GameObject[] pawn_List;//pawns
    public Transform[] face_List;//transform positions 
    public GameObject[] open_List;
    public bool full = false;
    public int follower_count;
    public Transform form;
    //Quaternion formation;

    //leader will control all units as parent;
    //child will mimic leader's rotation
    //face script is to be disabled
    // child mimics leader's actions;
    //leader can collect new followers

    // Use this for initialization
    void Start()
    {
        //formation = form.rotation;
        pawn_List = new GameObject[5];
        open_List = new GameObject[5];


    }

    // Update is called once per frame
    void Update()
    {
        if (follower_count > 0)
        {
            for (int i = 0; i < 5; i++)
            {
                if (pawn_List[i] != null)
                {
                    pawn_List[i].transform.rotation = transform.rotation;
                    pawn_List[i].transform.position = face_List[i].position;
                }
            }
        }
        //form.rotation = Quaternion.Euler(-transform.rotation.eulerAngles.x, 0, 0);
    }
    public bool stuffed()
    {
        return full;
    }
    public int checkEmpty()
    {
        for (int i = 0; i < 5; i++)
        {
            if(pawn_List[i] == null)
            {
                return i;
            }
        }
        return -1;
    }
    public void addFol(GameObject follower)
    {
        if (!full)
        {
            //follower.GetComponent<faceScript>().following();
            pawn_List[checkEmpty()] = follower;
            follower.GetComponent<faceScript>().enabled = false;
            follower_count++;
        }
        if(follower_count >= 5)
        {
            full = true;
        }
    }
    public void setFree()
    {
        for (int i = 0; i < 5; i++)
        {
            if (pawn_List[i] != null)
            {
                pawn_List[i].GetComponent<faceScript>().enabled = true;
                pawn_List[i].GetComponent<faceScript>().freed();
            }
        }
        follower_count = 0;
        full = false;
    }
    public void removeFol(GameObject follower)
    {
        for (int i = 0; i < 5 ;i++)
        {
            if(pawn_List[i] == follower)
            {
                pawn_List[i] = null;

            }
        }
        follower_count--;
        full = false;
    }
}
