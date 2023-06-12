using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerBall : MonoBehaviour
{
    [Header("Get")]
    public GameObject uiOverseer;
    private UIOverseer UIOverseer;
    public TextMeshProUGUI scoreText;
    private Rigidbody ballRb;
    public Transform servePosition;
    public Vector3 originPosition;

    [Header("Set")]
    public float speed = 15f;
    public float maxSpeed = 5f;
    public float playerScore = 0f;
    public float enemyScore = 0f;
    public Vector3 serveOffset;
    public float fastBallDrag = 0.4f;
    public float slowBallDrag = 0.1f;

    public float serveRepeatDelay = 1f;
    public bool active = true;

    public string lastTouched;
    void Start()
    {
        ballRb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, Physics.gravity.y * 0.5f, 0);
        UIOverseer = uiOverseer.GetComponent<UIOverseer>();
        originPosition = transform.position;
    }
    void Update()
    {
        // Debug.Log(ballRb.velocity.magnitude);
        if (ballRb.velocity.magnitude > 4)
        {
            ballRb.drag = fastBallDrag;
        }
        else
        {
            ballRb.drag = slowBallDrag;
        }
        ballRb.velocity = Vector3.ClampMagnitude(ballRb.velocity, maxSpeed);
        if (Input.GetKeyDown(KeyCode.R))
        {
            serveBall();
        }
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("1") || other.gameObject.CompareTag("2") || other.gameObject.CompareTag("enemyRacket") || other.gameObject.CompareTag("3"))
        {
            lastTouched = other.gameObject.tag;
        }
        else if (other.gameObject.CompareTag("Ground"))
        {
            enemyWin();
            playerWin();
            if (playerScore >= 11f)
            {
                UIOverseer.EndGame(true);
            }
            else if (enemyScore >= 11f)
            {
                UIOverseer.EndGame(false);
            }
        }
    }

    private void serveBall()
    {
        transform.position = servePosition.position;
        ballRb.velocity = Vector3.zero;
        ballRb.AddForce((serveOffset * speed) * Time.deltaTime, ForceMode.Impulse);
    }

    public void playerWin()
    {
        if (lastTouched == "2" || lastTouched == "enemyRacket")
        {
            playerScore += 1f;
            scoreText.text = playerScore + " - " + enemyScore;
            transform.position = originPosition;
            ballRb.velocity = Vector3.zero;
        }
    }

    public void enemyWin()
    {
        if (lastTouched == "1" || lastTouched == "3")
        {
            enemyScore += 1f;
            scoreText.text = playerScore + " - " + enemyScore;
            transform.position = originPosition;
            ballRb.velocity = Vector3.zero;
        }
    }
}
