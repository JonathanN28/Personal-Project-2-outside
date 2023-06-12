using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [Header("Get")]
    public GameObject racket;
    private RacketFollowPlayer racketFollowPlayer;
    private PlayerRacket playerRacket;
    private CharacterController cController;
    
    public GraphicRaycaster m_Raycaster;
    public PointerEventData m_PointerEventData;
    public EventSystem m_EventSystem;
    
    [Header("Set")]
    public float speed = 5f;

    
    
    void Start()
    {
        cController = GetComponent<CharacterController>();
        playerRacket = GetComponent<PlayerRacket>();
        racketFollowPlayer = racket.GetComponent<RacketFollowPlayer>();
        
    }

    void Update()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        // Unity answer solution for consistent speed in diagonal form
        moveDirection = Vector3.ClampMagnitude(moveDirection, 1f);
        cController.Move(moveDirection * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRacket.flipRacket();
        }
        
        else if (Input.GetMouseButton(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                if (clickedPowerupButton() == false){
                    racketFollowPlayer.ExtendRacket();
                }
            }
            else
            {
                racketFollowPlayer.ExtendRacket();
            }
        }
        else if (Input.GetMouseButton(1))
        {
            racketFollowPlayer.RetractRacket();
        }
    }

    private bool clickedPowerupButton()
    {
        // Check to see if the UI game object is named Powerup1, Powerup2, Powerup3, or Powerup4
        m_PointerEventData = new PointerEventData(m_EventSystem);
        m_PointerEventData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();

        m_Raycaster.Raycast(m_PointerEventData, results);
        
        foreach (RaycastResult result in results)
        {
            //Debug.Log("Hit " + result.gameObject.name);
            String uiElementName = result.gameObject.name;
            if (uiElementName.Equals("Powerup1") || uiElementName.Equals("Powerup2") ||
                uiElementName.Equals("Powerup3") || uiElementName.Equals("Powerup4"))
            {
                Debug.Log("Hit a powerup button");
                return true;
            }
        }
        return false;
    }

}
