using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public static int zAxisPos = 0; 
    void Start()
    {
       Cursor.visible = false; 
    }
    void Update()
    {
        Vector2 mouseCursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        transform.position = mouseCursorPos;
    }
}
