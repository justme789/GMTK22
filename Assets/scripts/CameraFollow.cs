using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    float followSpeed = 7f;
    public Transform follow;
    float yOf = 2.7f;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(follow.position.x, follow.position.y+yOf, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed*Time.deltaTime);
    }
}
