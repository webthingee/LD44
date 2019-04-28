using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlight : MonoBehaviour
{
    public Transform target;
    public Vector3 moveToPoint;

    private void Start()
    {
        moveToPoint = transform.position;
    }

    private void OnEnable()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<PlayerMovement>().enabled = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            moveToPoint = target.position;
        }
        
        if (transform.position != target.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, moveToPoint, 2f * Time.deltaTime);
        }

        if (transform.position.y >= 0f)
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 0, -10f);
        }
        //@todo needs fallback
        
        if (transform.position.x <= 19f)
        {
            Camera.main.transform.position = new Vector3(10f, 0, -10f);
        }
        //@todo needs fallback

    }
}