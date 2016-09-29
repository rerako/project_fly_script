using UnityEngine;
using System.Collections;

public class playerRoll : MonoBehaviour {
    public GameObject ball;
    public Transform x_axis;
    public Transform y_axis;
    public Transform cam;
    public float x_Speed;
    public float y_Speed;
    public bool grounded = false;
    // Use this for initialization
    void Start () {
    }
    // void Update() {


    //  }
    // Update is called once per frame
    void FixedUpdate () {
        grounded = !ball.GetComponent<IntheAir>().AirJordan();
        cam.Rotate(Input.GetAxis("Mouse Y") * -1f, Input.GetAxis("Mouse X") * 1.5f, 0);
        cam.eulerAngles = new Vector3(cam.eulerAngles.x, cam.eulerAngles.y, 0);
        if (!grounded)
        {
            ball.GetComponent<Rigidbody>().drag = 0;

        }
        if (Input.GetAxis("Vertical") != 0 && grounded)
        {
            ball.GetComponent<Rigidbody>().drag = 0.5f;
            ball.GetComponent<Rigidbody>().AddForce(Vector3.Normalize( y_axis.position - ball.transform.position) * y_Speed  * Input.GetAxis("Vertical"));
        }
        if (Input.GetAxis("Horizontal") != 0 && grounded)
        {
            ball.GetComponent<Rigidbody>().drag = 0.5f;

            ball.GetComponent<Rigidbody>().AddForce(Vector3.Normalize(x_axis.position - ball.transform.position) * x_Speed  * Input.GetAxis("Horizontal") );
            //ball.transform.Rotate(0,x_Speed * Input.GetAxis("Horizontal"), 0, Space.World);
        }
	}
    void OnTriggerStay(Collider hit) {
        if(hit.transform.tag == "terrain")
        {
            grounded = true;
        }

    }

    void LateUpdate()
    {
        gameObject.transform.position = ball.transform.position;


    }
}
