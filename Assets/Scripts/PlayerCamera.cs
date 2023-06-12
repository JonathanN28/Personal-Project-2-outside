using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [Header("Get")]
    public Transform playerHead;
    public GameObject mainCamera;
    
    [Header("Set")]
    public Vector3 cameraOffset;
    void Start()
    {
        cameraOffset = new Vector3(0, 0, 0);
    }
    void LateUpdate()
    {
        mainCamera.transform.position = playerHead.position + cameraOffset;
    }
}
