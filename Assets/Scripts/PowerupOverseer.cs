using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PowerupOverseer : MonoBehaviour
{
    public GameObject playerBall;
    public GameObject playerTarget;
    public List<TextMeshProUGUI> powerups = new List<TextMeshProUGUI>();
    public List<string> powerupsOrigin = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SetPowerupsOrigin", 0f, 15f);
    }

    void Update()
    {
        
    }

    private void SetPowerupsOrigin()
    {
        powerupsOrigin.Clear();
        powerupsOrigin.Add("aimbot");
        powerupsOrigin.Add("racket");
        powerupsOrigin.Add("speed");
        powerupsOrigin.Add("magnet");
        powerupsOrigin.Add("destroy");
        powerupsOrigin.Add("curve");
        for(int i = 0; i < powerups.Count; i++)
        {
            int left = Random.Range(0, powerupsOrigin.Count);
            string chosen = powerupsOrigin[left];
            powerups[i].text = chosen;
            powerups[i].GetComponentInParent<UnityEngine.UI.Button>().interactable = true;
            powerupsOrigin.RemoveAt(left);
        }
    }

    public void ActivatePowerup(TextMeshProUGUI powerup)
    {
        if (powerup.text == "aimbot")
        {
            playerBall.GetComponent<aimbot>().active = true;
            powerup.GetComponentInParent<UnityEngine.UI.Button>().interactable = false;
        }
        else if (powerup.text == "racket")
        {
            playerBall.GetComponent<racket>().active = true;
            powerup.GetComponentInParent<UnityEngine.UI.Button>().interactable = false;
        }
        else if (powerup.text == "speed")
        {
            playerBall.GetComponent<speed>().active = true;
            powerup.GetComponentInParent<UnityEngine.UI.Button>().interactable = false;
        }
        else if (powerup.text == "magnet")
        {

        }
        else if (powerup.text == "destroy")
        {
            playerBall.GetComponent<destroy>().active = true;
            powerup.GetComponentInParent<UnityEngine.UI.Button>().interactable = false;
        }
        else if (powerup.text == "curve")
        {
            
        }
    }
    private IEnumerator DeactivatePowerup(string powerup)
    {
        yield return new WaitForSeconds(10f);
    
    }
}
