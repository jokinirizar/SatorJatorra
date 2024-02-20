using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDelay : MonoBehaviour
{
    public Behaviour comp;

    private void Start()
    {
        float milisecs = Random.Range(0.0f, 1000.0f);
        StartCoroutine(MoleIsShowing(milisecs));
    }
    IEnumerator MoleIsShowing(float milisecs)
    {
        float secs = milisecs / 1000;
        yield return new WaitForSeconds(secs);
        comp.enabled = true;
    }
}
