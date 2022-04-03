using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{

    public GameObject SnowBall;
    public float Speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var deltaX = math.lerp(transform.position.x, SnowBall.transform.position.x, Speed);
        var deltaY = math.lerp(transform.position.y, SnowBall.transform.position.y, Speed);
        var newPos = new Vector3(deltaX, deltaY, transform.position.z);
        transform.position = newPos;
    }
}
