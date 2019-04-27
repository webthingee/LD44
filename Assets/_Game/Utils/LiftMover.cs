using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftMover : MonoBehaviour
{
    public Transform target;
    public bool moveLift;

    // Update is called once per frame
    void Update()
    {
        if (moveLift)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, 2f * Time.deltaTime);
        }
    }
}
