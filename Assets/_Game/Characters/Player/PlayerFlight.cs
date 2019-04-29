using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using MyEvents;
using UnityEngine;

public class PlayerFlight : MonoBehaviour
{
    public Transform target;
    public Vector3 moveToPoint;
    public bool inFlight = true;

    private void Start()
    {
        moveToPoint = transform.position;
        StartCoroutine(RocketPowerUse());
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

        if (transform.position.y >= -3f)
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, 0, -10f);
        }
        //@todo needs fallback
        
        if (transform.position.x <= 20f)
        {
            Camera.main.transform.position = new Vector3(10f, 0, -10f);
        }
        //@todo needs fallback
    }

    IEnumerator RocketPowerUse()
    {
        while (inFlight)
        {
            FindObjectOfType<PlayerPower>().PlayerPowerLevel -= 1;

            if (FindObjectOfType<PlayerPower>().PlayerPowerLevel <= 0)
            {
                
                CutSceneInfo OnStartCutScene = new CutSceneInfo
                {
                    description = "This a cut scene for Death", 
                    obj = gameObject,
                    cutSceneName = "Death"
                };
                OnStartCutScene.FireEvent();
                
                Debug.Log("End Of Game");
                this.enabled = false;
                inFlight = false;
                yield break;
            }
            
            yield return new WaitForSeconds(3f);
        }
        
        yield return new WaitForSeconds(0.1f);
    }
}