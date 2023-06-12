using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimbot : MonoBehaviour
{
    public GameObject playerTarget;
    public Rigidbody ballRb;
    public float speed = 200f;
    public bool active = false;
    // Start is called before the first frame update
    void Start()
    {
        ballRb = GetComponent<Rigidbody>();
        playerTarget.transform.position = new Vector3(Random.Range(-1.5f, 1.5f), playerTarget.transform.position.y, Random.Range(0f, 2f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Net") && active)
        {
            Vector3 direction = gameObject.transform.position - playerTarget.transform.position;
            float directionY = direction.y;
            direction = new Vector3(direction.x , directionY, direction.z).normalized;
            ballRb.AddForce(-direction * Time.deltaTime * speed, ForceMode.Impulse);
            active = false;
        }
    }
}
