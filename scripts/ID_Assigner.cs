using UnityEngine;
using System.Collections;

public class ID_Assigner : MonoBehaviour
{
    public int enemy_x = -1;
    public int enemy_x2 = -1;

    public int ally_x = -1;
    public int bullet_x = -1;
    // Use this for initialization

    public int getID(Transform col)
    {
        if (col.CompareTag("enemy"))
        {
            enemy_x = enemy_x + 1;
            return enemy_x;

        }
        else if (col.CompareTag("enemy2"))
        {
            enemy_x2 = enemy_x2 + 1;
            return enemy_x2;

        }
        else if (col.CompareTag("bullet") || col.transform.CompareTag("bullet2"))
        {
            bullet_x = bullet_x + 1;
            return bullet_x;
        }

        else if (col.CompareTag("ally") || col.CompareTag("Player"))
        {
            ally_x = ally_x + 1;
            return ally_x;
        }
        else {
            //gameobjects that don't need an id
            Debug.Log(col.name);
            return -1;
        }
    }
}
