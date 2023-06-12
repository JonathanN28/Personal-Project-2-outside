using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class PlayerRacket : MonoBehaviour
{
    [Header("Get")]
    public RectTransform mousePositionTracker;
    public Camera cam;
    public GameObject racket;
    private Rigidbody racketRb;
    
    [Header("Set")]
    public int flipDegrees = 0;
    
    [Header("Debug")]
    
    public float leftHalfMousePosX;
    public float rightHalfMousePosX;
    public float upperHalfMousePosY;
    public float bottomHalfMousePosY;
    public bool isLeftSide = false;
    public bool isRightSide = false;
    public bool isUpperSide = false;
    public bool isBottomSide = false;
    public bool racketBool;
    public float distance = 2.5f;
    private float halfScreen;
    void Start()
    {
        Debug.Log(Screen.width + " " + Screen.height);
        halfScreen = Screen.width * 0.5f;
        racketRb = racket.GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        RacketRotate();
    }

    private float RacketDotProduct(Vector3 v, Vector3 w)
    {
        float dot = v.x * w.x + v.y * v.y;
        float angle = Mathf.Acos(dot / (v.magnitude * w.magnitude));
        return angle;
    }
    private Vector3 RacketCrossProduct(Vector3 v, Vector3 w)
    {
        float x = (v.y * w.z) - (w.y * v.z);
        float y = (v.x * w.z) - (w.x * v.z);
        float z = (v.x * w.y) - (w.x * v.y);

        return new Vector3(x, y, z);
    }
    private void RacketRotate()
    {
        
        float mousePosX = (mousePositionTracker.position.x / Screen.width) * 100;
        float mousePosY = (mousePositionTracker.position.y / Screen.height) * 100;
        float distanceToRacket = Mathf.Abs((cam.transform.position - racket.transform.position).magnitude);
        
        if (mousePosX <= 50)
        {
            leftHalfMousePosX = (mousePosX / 50) + 1;
            isLeftSide = true;
            isRightSide = false;
        }
        else
        {
            rightHalfMousePosX = (-mousePosX / 50) + 3;
            isLeftSide = false;
            isRightSide = true;
        }

        if (mousePosY >= 50)
        {
            upperHalfMousePosY = (-mousePosY / 50) + 3;
            isUpperSide = true;
            isBottomSide = false;
        }
        else
        {
            bottomHalfMousePosY = (mousePosY / 50) + 1;
            isUpperSide = false;
            isBottomSide = true;
        }
        

        if (isLeftSide && isUpperSide && leftHalfMousePosX <= upperHalfMousePosY)
        {
            distance = distanceToRacket * leftHalfMousePosX;
        }
        else if (isLeftSide && isUpperSide && leftHalfMousePosX >= upperHalfMousePosY)
        {
            distance = distanceToRacket * upperHalfMousePosY;
        }
        
        if (isLeftSide && isBottomSide && leftHalfMousePosX <= bottomHalfMousePosY)
        {
            distance = distanceToRacket * leftHalfMousePosX;
        }
        else if (isLeftSide && isBottomSide && leftHalfMousePosX >= bottomHalfMousePosY)
        {
            distance = distanceToRacket * bottomHalfMousePosY;
        }
        
        if (isRightSide && isUpperSide && rightHalfMousePosX <= upperHalfMousePosY)
        {
            distance = distanceToRacket * rightHalfMousePosX;
        }
        else if (isRightSide && isUpperSide && rightHalfMousePosX >= upperHalfMousePosY)
        {
            distance = distanceToRacket * upperHalfMousePosY;
        }
        
        if (isRightSide && isBottomSide && rightHalfMousePosX <= bottomHalfMousePosY)
        {
            distance = distanceToRacket * rightHalfMousePosX;
        }
        else if (isRightSide && isBottomSide && rightHalfMousePosX >= bottomHalfMousePosY)
        {
            distance = distanceToRacket * bottomHalfMousePosY;
        }
        
        Vector3 mousePos = cam.ScreenToWorldPoint(new Vector3(mousePositionTracker.position.x, mousePositionTracker.position.y, distance));
        Vector3 direction = (racket.transform.position - mousePos);
        
        Quaternion racketRotating = Quaternion.FromToRotation(Vector3.forward, -direction) * Quaternion.Euler(0, 0, flipDegrees);
        racketRb.MoveRotation(racketRotating);
        
        // Debug.Log(leftHalfMousePosX + "    " + rightHalfMousePosX + "    " + upperHalfMousePosY + "    " + bottomHalfMousePosY);
    }

    public void flipRacket()
    {
        if (racketBool == false)
        {
            flipDegrees = 90;
            racketBool = true;
        }
        else
        {
            flipDegrees = 0;
            racketBool = false;
        }
    }
}
