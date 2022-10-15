using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleAim : MonoBehaviour
{
    [SerializeField] Transform aimTransform;
    [SerializeField] Transform aimFootEndPointTransform;
    [SerializeField] Transform aimTargetTransform;

    // Update is called once per frame
    void Update()
    {
        HandleAiming();
    }

    private void HandleAiming()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0f, 0f, angle);
    }
}
