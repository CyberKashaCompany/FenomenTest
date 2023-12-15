using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{

    public AudioSource clickSound;
    public AnimationCurve curve;

    private Vector3 startScale;
    // Start is called before the first frame update
    void Start()
    {
        startScale = gameObject.GetComponent<RectTransform>().localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Bounce()
    {
        StopAllCoroutines();
        gameObject.GetComponent<RectTransform>().localScale= startScale;
        StartCoroutine("bounceEffect");
    }

    IEnumerator bounceEffect()
    {
        
        float time = 0f;
        while (time<curve.keys[curve.length-1].time)
        {
            yield return null;
            time += Time.deltaTime;
            gameObject.GetComponent<RectTransform>().localScale = startScale * curve.Evaluate(time);
        }
      
    }
    public void PlaySound()
    {
        clickSound.Play(0);
    }

}
