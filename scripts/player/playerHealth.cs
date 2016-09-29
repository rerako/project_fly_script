using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public int hp = 1000;
    private bool dmg = true;
    public Slider UI_HP;
    public Text ScoreBoard;
    float size;
    WaitForSeconds timer;

    int JuiceScore;
    public GameObject cam;
    public static int score = 0;
    // Use this for initialization
    void Start()
    {
        timer = new WaitForSeconds(0.25f);
        ScoreBoard.text = "Enemies Destroyed: " + score;

    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            gameObject.SetActive(false);
        }
        if (JuiceScore < score)
        {
            size = 1.3f;
            ScoreBoard.text = "Enemies Destroyed: " + score;
            ScoreBoard.rectTransform.localScale = new Vector3(size,size,1);
            JuiceScore = score;
        }
        if (ScoreBoard.rectTransform.localScale.x > 1)
        {
            size -= Time.deltaTime;
            ScoreBoard.rectTransform.localScale = new Vector3(size, size, 1);
        }
        UI_HP.value = ((float)hp) / 1000f;


    }
    IEnumerator stagger(int damage)
    {
        if (dmg)
        {
            dmg = false;
            yield return timer;
            hp -= damage;
            cam.GetComponent<Camerafollow>().shakeDuration = 0.3f;
            dmg = true;
        }
    }

    //IEnumerator staggerdmg(){}
    void OnCollisionEnter(Collision hit)
    {
        //Debug.Log(hit.transform.tag);
        if (hit.gameObject.CompareTag("enemy"))
        {
            StartCoroutine(stagger(100));
        }
        else if (hit.gameObject.CompareTag("ebullet"))
        {
            StartCoroutine(stagger(50));
        }
    }

}
