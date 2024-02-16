using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class RayCastScript : MonoBehaviour {

    public GameController controller;
    Camera cam;
    public LayerMask mask;
    private void Start()
    {
        cam = Camera.main;
    }

void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 100f;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        Debug.DrawRay(transform.position, mousePos - transform.position, Color.blue);
        if (Input.GetMouseButtonDown(0)&&controller.isCursorEnabled)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, mask))
            {
                if (hit.collider.gameObject.tag == "Mole")
                {
                    hit.transform.GetComponent<MoleScript>().onMoleHit();
                }
              
            }

        }

    }


        }