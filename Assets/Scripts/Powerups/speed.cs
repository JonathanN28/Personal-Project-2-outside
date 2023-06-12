using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speed : MonoBehaviour
{
    public bool active = false;
    private PlayerBall playerBall;
    private float maxSpeedOrigin;
    // Start is called before the first frame update
    void Start()
    {
        playerBall = GetComponent<PlayerBall>();
        maxSpeedOrigin = playerBall.maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (active && !IsInvoking("DeactivatePowerup"))
        {
            playerBall.maxSpeed = 20f;
            Invoke("DeactivatePowerup", 5f);
        }
    }
    private void DeactivatePowerup()
    {
        playerBall.maxSpeed = maxSpeedOrigin;
        active = false;
    }
}
