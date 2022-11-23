using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCube : MonoBehaviour
{
    RaycastHit hit;

    void Update()
    {
        Ray cubeRay = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(cubeRay, out hit, 5f))
        {
            if (hit.collider.CompareTag("Cube"))
            {
                hit.collider.gameObject.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
            }
        }

        Debug.DrawRay(transform.position, transform.forward * 5f, Color.green);
    }
}
