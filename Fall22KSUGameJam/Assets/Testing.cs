using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    //[SerializeField] private 
    private float holdDownStartTime;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            holdDownStartTime = Time.time;
        }

        if (Input.GetMouseButtonUp(0))
        {
            float holdDownTime = Time.time - holdDownStartTime;
        }

        if (Input.GetMouseButton(0))
        {

        }
    }
}
