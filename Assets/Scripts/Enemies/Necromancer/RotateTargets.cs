using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTargets : MonoBehaviour
{
    public float spinSpeed;
    public bool spinClockWise;
    public float spinInvertTime;
    private bool isCoroutineExecuting;
    void FixedUpdate()
    {
        if(!spinClockWise){
            this.transform.Rotate(new Vector3(0, 0, spinSpeed));
        }
        else if(spinClockWise){
            this.transform.Rotate(new Vector3(0, 0, -spinSpeed));
        }
    }

    void Update(){
        StartCoroutine(ExecuteAfterTime(spinInvertTime));
    }

 IEnumerator ExecuteAfterTime(float time)
 {
    if (isCoroutineExecuting)
        yield break;

    isCoroutineExecuting = true;

    yield return new WaitForSeconds(time);
  
    spinClockWise = !spinClockWise;
 
    isCoroutineExecuting = false;
 }


}
