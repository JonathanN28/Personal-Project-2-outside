using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIOverseer : MonoBehaviour
{
    public GameObject playerBall;
    private Overseer Overseer;
    public TextMeshProUGUI scoreText;
    public GameObject scoreTextBackground;
    // Start is called before the first frame update
    void Start()
    {
        Overseer.GetComponent<Overseer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndGame(bool win)
    {
        if (win)
        {
            scoreText.text = scoreText.text + "\n" + "You Win!";
            scoreTextBackground.transform.localScale = new Vector2(2, 2);
            Overseer.Off();
        }
        else
        {
            scoreText.text = scoreText.text + "\n" + "Game Over!";
            scoreTextBackground.transform.localScale = new Vector2(2, 2);
            Overseer.Off();
        }
    }
}
