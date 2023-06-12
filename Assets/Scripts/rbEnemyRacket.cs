using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rbEnemyRacket : MonoBehaviour
{
    public GameObject enemyRacket;
    public GameObject enemyTarget;
    public Rigidbody ballRb;
    public float speed = 100f;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(enemyRacket.transform.position);
        rb.rotation = Quaternion.Lerp(rb.rotation, enemyRacket.transform.rotation, Time.deltaTime * 10f);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Vector3 direction = (new Vector3(enemyTarget.transform.position.x, transform.position.y, enemyTarget.transform.position.z) - ballRb.position).normalized;
            ballRb.AddForce(direction * Time.deltaTime * speed, ForceMode.Impulse);
            ballRb.AddForce(Vector3.up * Time.deltaTime * speed, ForceMode.Impulse);
            GetComponent<Collider>().enabled = false;
            Invoke("TurnOnCollider", 2f);
        }
        
    }
    private void TurnOnCollider()
    {
        GetComponent<Collider>().enabled = true;
    }
}
