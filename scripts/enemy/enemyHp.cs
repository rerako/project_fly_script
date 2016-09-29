using UnityEngine;
using System.Collections;

public class enemyHp : MonoBehaviour {
    public int hp;
    public bool alive;
    void Start()
    {
        if (transform.CompareTag("enemy")){ hp = 100; }
        else if (transform.CompareTag("enemy2")){ hp = 200; }
        alive = true;
    }
    public void minus(int dmg)
    {
        hp = hp - dmg;
        if(hp < 0)
        {
            hp = 0;
            alive = false;
        }
    }
    public bool survive()
    {
        return alive;
    }
}
