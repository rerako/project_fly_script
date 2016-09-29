using UnityEngine;
using System.Collections;

public class fly_noRG : MonoBehaviour
{
    public Transform forward;
    public Transform backward;
    public Transform resetQuat;
    public float speed;
    public float turnSpeed;
    public float resetSpeed;
    public float brake;
    private Quaternion targetRotation;
    public float second = 5f;
    public Transform zipPointR;
    public Transform zipPointL;
    public Transform zipPointUp;
    private TrailRenderer leftAegis;
    private TrailRenderer rightAegis;

    public GameObject WingPointL;
    public GameObject WingPointR;
    public GameObject body;
    public bool drafting;
    public float zipSpeed;
    public bool pause = false;
    public bool mode1;
    public bool mode2;
    // Use this for initialization
    void Start()
    {
        //Application.targetFrameRate = 60;
        leftAegis = WingPointL.GetComponent<TrailRenderer>();
        rightAegis = WingPointR.GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mode1 == true)
        {
            float step = speed * brake * Time.deltaTime;


            if (Input.GetKey(KeyCode.Tab))
            {
                drafting = true;
            }
            else { drafting = false; }
            if (drafting)
            {
                targetRotation = Quaternion.LookRotation(-resetQuat.forward, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1f * Time.deltaTime);
                transform.position = Vector3.MoveTowards(transform.position, backward.position, step);

            }
            if (!drafting)
            {


                resetQuat.position = transform.position;
                resetQuat.eulerAngles = Vector3.Lerp(resetQuat.eulerAngles, new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0f), 1f);
                transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, resetQuat.rotation, resetSpeed * Time.deltaTime);
                //euler = Vector3.Lerp(euler, new Vector3(euler.x, euler.y, 0f), resetSpeed * Time.deltaTime);
                transform.position = Vector3.MoveTowards(transform.position, forward.position, step);
            }
            if (Input.GetAxis("Horizontal") != 0)
            {
                transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, Space.Self);
                transform.Rotate(Vector3.forward * Input.GetAxis("Horizontal") * -turnSpeed * Time.deltaTime, Space.Self);
                //  transform.Rotate(Vector3.forward * Input.GetAxis("Horizontal") * speed * 0.5f, Space.Self);

            }
            if (Input.GetAxis("Vertical") != 0)
            {
                transform.Rotate(Vector3.right * Input.GetAxis("Vertical") * turnSpeed * Time.deltaTime, Space.Self);
            }



            if (Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.Q))
            {
                transform.position = Vector3.MoveTowards(transform.position, zipPointUp.position, zipSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.E))
            {
                transform.position = Vector3.MoveTowards(transform.position, zipPointR.position, zipSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.Q))
            {
                transform.position = Vector3.MoveTowards(transform.position, zipPointL.position, zipSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                rightAegis.time = 0.1f;
                rightAegis.enabled = false;
                leftAegis.time = 0.1f;
                leftAegis.enabled = false;

                brake = 0.3f;
            }
            else if (Input.GetKey(KeyCode.LeftShift))
            {
                rightAegis.time = 1f;
                leftAegis.time = 1f;

                rightAegis.enabled = true;
                leftAegis.enabled = true;

                gameObject.transform.rotation = transform.rotation;

                brake = 2.3f;
            }
            else {
                rightAegis.time = 0.1f;
                leftAegis.time = 0.1f;

                //rightAegis.Clear();
                //rightAegis.enabled = false;
                //leftAegis.Clear();
                //leftAegis.enabled = false;
                brake = 1;
            }

        }
        else if (mode2 == true)
        {
            resetQuat.position = transform.position;
            resetQuat.eulerAngles = Vector3.Lerp(resetQuat.eulerAngles, new Vector3(0, 0, 0f), 1f);
            transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, resetQuat.rotation, resetSpeed * Time.deltaTime);
        }
        else {

        }
        if (Input.GetKey(KeyCode.I))
        {

            Application.LoadLevel("FlyBuild_0.4");
        }
        if (!pause && Input.GetKey(KeyCode.Escape))
        {
            pause = true;
            Time.timeScale = 0;
        }
        else if(pause && Input.GetKey(KeyCode.Escape))
        {
            pause = false;
            Time.timeScale = 1;
        }
        if (Input.GetKey(KeyCode.Mouse1) || Input.GetKey(KeyCode.Period))
        {

            body.transform.Rotate(0, 0, 600 * Time.deltaTime /* Input.GetAxis("Horizontal")*/);
        }
        else {
            body.transform.rotation = gameObject.transform.rotation;
        }
    }
    /*
    void FixedUpdate() {
        Vector3 direction = Vector3.Normalize(forward.transform.position - transform.position);
        gameObject.GetComponent<Rigidbody>().AddForce(direction * speed * Time.deltaTime);
    }*/

}
