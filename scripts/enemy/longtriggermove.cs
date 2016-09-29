using UnityEngine;
using System.Collections;

public class longtriggermove : MonoBehaviour {
    public GameObject HLeft;
    public GameObject HRight;
    public GameObject VUp;
    public GameObject VDown;
    public Transform rbody;
    public float VSpeed;
    public float HSpeed;

    public bool left;
    public bool right;
    public bool up;
    public bool down;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
            left = HLeft.GetComponent<triggermoveH>().cho1;
            right = HRight.GetComponent<triggermoveH>().cho2;
            up = VUp.GetComponent<triggermoveV>().cho1;
            down = VDown.GetComponent<triggermoveV>().cho2;


        //turn away
        if (left && right && !up && !down) {
            rbody.Rotate(rbody.up * -VSpeed * 1.5f * Time.deltaTime, Space.Self);

        }
        // turn down
        else if (left && right && up && !down) {
            rbody.Rotate(rbody.right * VSpeed * Time.deltaTime, Space.Self);

        }
        //turn up
        else if (left && right && !up && down) {
            rbody.Rotate(rbody.right * -VSpeed * Time.deltaTime, Space.Self);

        }
        //turn right
        else if (left && !right && up && down) {
            rbody.Rotate(rbody.up * -HSpeed * Time.deltaTime, Space.Self);

        }
        //turn left
        else if (!left && right && up && down) {
            rbody.Rotate(rbody.up * HSpeed * Time.deltaTime, Space.Self);

        }
        //turn away
        else if (!left && !right && up && down) {
            rbody.Rotate(rbody.up * -HSpeed * Time.deltaTime, Space.Self);

        }
        // turn aaay
        else if (left && right && up && down) {
            rbody.Rotate(rbody.right * -VSpeed * 1.5f * Time.deltaTime, Space.Self);

        }


    }
}
