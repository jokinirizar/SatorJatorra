using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Points : MonoBehaviour
{
    public TextMeshProUGUI PointsText;
    private int pointAcumulator = 0;
    private int currentPoints;

    public void AddPoints(float pointsToAdd)
    {
        StartCoroutine(AddPointsProgressively(pointsToAdd));
        }

    IEnumerator AddPointsProgressively(float pointsToAdd)
    {
        currentPoints = Int32.Parse(PointsText.text);
        while (pointAcumulator<pointsToAdd)
        {

            pointAcumulator = pointAcumulator +10;         
            currentPoints = currentPoints + 10;
            PointsText.text = currentPoints.ToString();
            yield return null;
        }
        pointAcumulator = 0;
     



    }
}
