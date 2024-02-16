using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComboPoints : MonoBehaviour
{
    public TextMeshProUGUI comboPointsText;
    public TextMeshProUGUI comboMultiplicatorText;
    public Points points;
    private float currentComboPoints = 0;
    private float comboTime = 1f;
    private bool isComboTime = false;
    public void changeComboPoints()
    {
        if (comboPointsText.text.Length > 0)
        {
            currentComboPoints = Int32.Parse(comboPointsText.text);
        }
        else
        {
            currentComboPoints = 0;
        }
        currentComboPoints = currentComboPoints + 1000;
        comboPointsText.text = currentComboPoints.ToString();
        comboMultiplicatorText.text = ((((currentComboPoints / 1000) - 1) * 0.2f) + 1).ToString();
        isComboTime = true;

    }
    public void resetComboTimer()
    {
        comboTime = 1f;   
    }

    private void Update()
    {
        if (isComboTime)
        {
            comboTime = comboTime - Time.deltaTime;
            if (comboTime < 0)
            {
                currentComboPoints = currentComboPoints * ((((currentComboPoints / 1000) - 1)*0.2f)+1);
                points.AddPoints(currentComboPoints);
                currentComboPoints = 0;
                comboPointsText.text = "0000";
                comboMultiplicatorText.text = "1";
                isComboTime= false;
                comboTime = 1f;
            }

        }
 
    }
}
