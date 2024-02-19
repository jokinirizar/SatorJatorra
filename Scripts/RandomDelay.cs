using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDelay : MonoBehaviour
{
    public Behaviour comp;

    private void Start()
    {
        Random.Range(0.0f, 1000.0f);
    }
    IEnumerator MoleIsShowing(int milisecs)
    {
        float secs = milisecs / 1000;
        yield return new WaitForSeconds(secs);
        comp.enabled = true;
    }
}
