using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketFollowPlayer : MonoBehaviour
{
    [Header("Get")]
    public Transform playerHead;
    private Vector3 zeroVector = Vector3.zero;
    private Rigidbody rb;
    private Vector3 offsetOrigin;
    
    [Header("Set")]
    public Vector3 offset;
    private float timeSpeed = 0.1f;
    public float extendDistance = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        offsetOrigin = offset;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FollowPlayer();
    }
    private void FollowPlayer()
    {
        // Slerp not applicable to this case because lag. Also ref zeroVector because Unity documentation told to do this
       
        rb.MovePosition(Vector3.SmoothDamp(transform.position,
            playerHead.transform.position + offset, ref zeroVector, timeSpeed));
        
    }

    public void ExtendRacket()
    {
        timeSpeed = 0.25f;
        offset = new Vector3(offset.x, offset.y, extendDistance);
        
    }

    public void RetractRacket()
    {
        timeSpeed = 0.1f;
        offset = offsetOrigin;
        
    }
    
}
