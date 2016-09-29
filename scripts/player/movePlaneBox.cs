using UnityEngine;
using System.Collections;

public class movePlaneBox : MonoBehaviour {
    public GameObject player;
    public Transform middle;
    public Transform downAngle;
    public Transform upAngle;
    public Transform leftAngle;
    public Transform rightAngle;
    public float xlimit;
    public float ylimit;
    public float speed;
    public float turnSpeed;
	// Use this for initialization
	void Start () {
        speed = speed * Time.deltaTime;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        //player.transform.rotation = Quaternion.Lerp(player.transform.rotation, middle.rotation, 0.f);
        if (Input.GetAxis("Vertical") == 0 || Input.GetAxis("Horizontal") == 0) {
            player.transform.rotation = Quaternion.Lerp(player.transform.rotation, middle.rotation, 0.1f);
        }



        
        if (Input.GetAxis("Horizontal") > 0) {
            
            player.transform.rotation = Quaternion.Lerp(player.transform.rotation, rightAngle.rotation, Input.GetAxis("Horizontal")/10);
            if ((player.transform.position.x - middle.position.x) <= xlimit)
            {
                player.transform.position = Vector3.MoveTowards(
            new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z),
            new Vector3(player.transform.position.x + Input.GetAxis("Horizontal"), player.transform.position.y, player.transform.position.z), speed);
            }
        }

        
            else if (Input.GetAxis("Horizontal") < 0)
            {
               
                player.transform.rotation = Quaternion.Lerp(player.transform.rotation, leftAngle.rotation, -Input.GetAxis("Horizontal")/10);
            if ((player.transform.position.x - middle.position.x) >= -xlimit)
            {
               player.transform.position = Vector3.MoveTowards(
               new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z),
               new Vector3(player.transform.position.x + Input.GetAxis("Horizontal"), player.transform.position.y, player.transform.position.z),
               speed);
            }
        }

        
            if (Input.GetAxis("Vertical") > 0)
            {
                
                player.transform.rotation = Quaternion.Lerp(player.transform.rotation, upAngle.rotation, Input.GetAxis("Vertical") / 10);
            if ((player.transform.position.y - middle.position.y) <= ylimit)
            {
                player.transform.position = Vector3.MoveTowards(
                   new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z),
                   new Vector3(player.transform.position.x, player.transform.position.y + Input.GetAxis("Vertical"), player.transform.position.z),
                   speed);
            }
        }
         
            if (Input.GetAxis("Vertical") < 0)
            {
               
                player.transform.rotation = Quaternion.Lerp(player.transform.rotation, downAngle.rotation, -Input.GetAxis("Vertical") / 10);
            if ((player.transform.position.y - middle.position.y) >= -ylimit)
            {
                player.transform.position = Vector3.MoveTowards(
               new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z),
               new Vector3(player.transform.position.x, player.transform.position.y + Input.GetAxis("Vertical"), player.transform.position.z),
               speed);
            }
        }


    }
}
