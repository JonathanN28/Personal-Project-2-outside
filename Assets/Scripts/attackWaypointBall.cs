using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackWaypointBall : MonoBehaviour
{
    public GameObject playerBall;
    public Vector3 offset;
    public float speedMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerBall.transform.position.z > 2)
        {
            //transform.position = Vector3.Lerp(transform.position, new Vector3(playerBall.transform.position.x + offset.x, transform.position.y, playerBall.transform.position.z + offset.z), Time.deltaTime * speedMultiplier);
            transform.position = new Vector3(playerBall.transform.position.x + offset.x, transform.position.y,
                playerBall.transform.position.z + offset.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 4);
            transform.position = Vector3.Lerp(transform.position, new Vector3(playerBall.transform.position.x, transform.position.y, transform.position.z), Time.deltaTime * speedMultiplier);
        }
    }
}
