using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private float holdDownTime;
    [SerializeField] Image fillImage;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Press start.");
        }

        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Time: " + holdDownTime);
            Debug.Log("Fill Amount: " + fillImage.fillAmount);
        }

        if (Input.GetMouseButton(0))
        {
            holdDownTime += 0.2f * Time.deltaTime;
            fillImage.fillAmount = holdDownTime;

            if (fillImage.fillAmount >= 0.2f)
            {
                Debug.Log("Fired 2 second event");
            }
        }


        if (Input.GetKey(KeyCode.E))
        {
            holdDownTime -= 0.01f * Time.deltaTime;
            fillImage.fillAmount = holdDownTime;

            /*fillImage.fillAmount = holdDownTime - value;
            holdDownTime -= Time.deltaTime;
            fillImage.fillAmount = holdDownTime;*/
        }
    }
}
