using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleLookAt : MonoBehaviour
{
    void Update()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay( Input.mousePosition );
        float midPoint = (transform.position - Camera.main.transform.position ).magnitude * 0.5f;
        Vector3 originalVector = mouseRay.origin + mouseRay.direction * midPoint;
        transform.LookAt(originalVector);
    }
}
