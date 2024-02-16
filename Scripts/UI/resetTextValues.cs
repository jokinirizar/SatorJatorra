using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class resetTextValues : MonoBehaviour
{
    public int currentValue;
    public int startValue=5;
    public TextMeshProUGUI chronoText;
    public Animator animator;

    public void Start()
    {
        currentValue = startValue;
        chronoText.text = currentValue.ToString();
    }

    public void ChangeToFinishText()
    {
        chronoText.enabled = true;
        chronoText.text = "FINISH!";
        animator.SetTrigger("LastLoop");
    }
    public void DisableAnimator()
    {
        animator.enabled = false;
    }
    public void changeCountdownValue()
    {
        currentValue--;
        if(currentValue > 0) {
            chronoText.text = currentValue.ToString();
            chronoText.gameObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            chronoText.color = Color.white;
        }

        if (currentValue==0)
        {
            chronoText.enabled = false;
        }
    }
}
