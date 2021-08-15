using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffAim : MonoBehaviour
{
    private Transform aimTransform;
    [SerializeField] private Transform aimRotator;

   void Update() {

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 aimDirection = (mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);

        aimRotator.eulerAngles = new Vector3(0, 0, angle);
   }
}
