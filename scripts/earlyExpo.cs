using UnityEngine;
using System.Collections;

public class earlyExpo : MonoBehaviour {
    ParticleSystem boom;
    LensFlare flare;
    WaitForSeconds tick;
    private float time = 1f;
    // Use this for initialization
    void Start()
    {
        tick = new WaitForSeconds(time);
        boom = gameObject.GetComponent<ParticleSystem>();
        flare = gameObject.GetComponent<LensFlare>();
        flare.enabled = false;
        StartCoroutine("end");
      
    }
    IEnumerator end()
    {
        flare.enabled = true;

        boom.Simulate(1f, false, true);
        boom.Play(false);
        yield return tick;
        boom.Clear();
        boom.Stop();
        gameObject.SetActive(false);
    }

}
