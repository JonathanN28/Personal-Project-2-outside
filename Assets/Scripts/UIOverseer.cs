using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIOverseer : MonoBehaviour
{
    public GameObject playerBall;
    public TextMeshProUGUI scoreText;
    public GameObject scoreTextBackground;
    public GameObject restartButton;

    public GameObject mouseTracker;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndGame(bool win)
    {
        if (win)
        {
            restartButton.SetActive(false);
            scoreText.text = scoreText.text + "\n" + "You Win!";
            scoreTextBackground.transform.localScale = new Vector2(2, 2);
        }
        else
        {
            restartButton.SetActive(false);
            scoreText.text = scoreText.text + "\n" + "Game Over!";
            scoreTextBackground.transform.localScale = new Vector2(2, 2);
            Cursor.visible = true;
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
