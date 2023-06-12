using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TrackMousePosition : MonoBehaviour
{
    [Header("Get")]
    public TextMeshProUGUI mousePositionText;
    void Update()
    {
        Track();
    }
    private void Track()
    {
        if (Input.mousePosition.x > -1 && Input.mousePosition.x < Screen.width + 1)
        {
            if (Input.mousePosition.y > -1 && Input.mousePosition.y < Screen.height + 1)
            {
                transform.position = Input.mousePosition;
            }
        }
        mousePositionText.text = "X: " + transform.position.x + "\nY: " + transform.position.y;
    }
}
