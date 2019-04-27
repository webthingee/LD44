using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftMover : MonoBehaviour
{
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, 2f * Time.deltaTime);
    }
}
