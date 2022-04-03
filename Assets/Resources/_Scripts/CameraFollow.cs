using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
     
     public float dampTime = 0.5f;
     private Vector3 velocity = Vector3.zero;
     Transform target;

    // Update is called once per frame
    void Update () 
     {
         if (target)
         {
             Vector3 point = Camera.main.WorldToViewportPoint(target.position);
             Vector3 delta = target.position - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
             Vector3 destination = transform.position + delta;
             transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
         }
        else
        {
            try
            {
                target = GameObject.Find("Player").transform;
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }
     }
 }