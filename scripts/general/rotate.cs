using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour
{
    public float x;
    public float y;
    public float z;
    public bool randomX;
    public bool randomY;
    public bool randomZ;
    public float turnspeed;
    public float timer;

    // Use this for initialization
    void Start()
    {
        if (randomX)
        {
            x = Random.Range(-turnspeed, turnspeed);
        }
        if (randomY)
        {
            y = Random.Range(-turnspeed, turnspeed);
        }
        if (randomZ)
        {
            z = Random.Range(-turnspeed, turnspeed);
        }
        timer = 10;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(x * Time.deltaTime, y * Time.deltaTime, z * Time.deltaTime);
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            reset();
            timer = 10f;
        }
    }

    void reset()
    {
        if (randomX)
        {
            x = Random.Range(-turnspeed, turnspeed);
        }
        if (randomY)
        {
            y = Random.Range(-turnspeed, turnspeed);
        }
        if (randomZ)
        {
            z = Random.Range(-turnspeed, turnspeed);
        }

    }
}
