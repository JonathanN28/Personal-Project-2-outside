using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class racket : MonoBehaviour
{
    public bool active = false;
    public GameObject playerRacket;
    private Vector3 colliderOrigin;
    private Vector3 scaleOrigin;
    // Start is called before the first frame update
    void Start()
    {
        colliderOrigin = playerRacket.GetComponent<BoxCollider>().size;
        scaleOrigin = playerRacket.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (active && !IsInvoking("DeactivatePowerup"))
        {
            change();
            Invoke("DeactivatePowerup", 5f);
        }
    }
    private void change()
    {
        playerRacket.GetComponent<BoxCollider>().size = new Vector3(0.4f, playerRacket.GetComponent<BoxCollider>().size.y, 0.4f);
        playerRacket.transform.localScale = new Vector3(4f, playerRacket.transform.localScale.y, 4f);
    }
    private void DeactivatePowerup()
    {
        active = false;
        playerRacket.GetComponent<BoxCollider>().size = colliderOrigin;
        playerRacket.transform.localScale = scaleOrigin;
    }
}
