using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    public bool active = false;
    public PlayerBall PlayerBall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision other)
    {
        if (active && other.gameObject.CompareTag("enemyRacket"))
        {
            PlayerBall.playerScore += 1f;
            PlayerBall.scoreText.text = PlayerBall.playerScore + " - " + PlayerBall.enemyScore;
            active = false;
        }
    }

}
