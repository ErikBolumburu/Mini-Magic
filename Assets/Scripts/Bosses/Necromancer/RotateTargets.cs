using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTargets : MonoBehaviour
{
    public float spinSpeed;
    void FixedUpdate()
    {
       this.transform.Rotate(new Vector3(0, 0, spinSpeed));
    }
}
