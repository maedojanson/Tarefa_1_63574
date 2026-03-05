using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed = 20f;
    public float maxTilt = 30f;    
    public float tiltSpeed = 5f;    

    void Update()
    {
      
        float moveInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * speed * moveInput * Time.deltaTime, Space.Self);

        float mouseY = Input.mousePosition.y;
        float screenCenter = Screen.height / 2f;

        float mousePercent = (mouseY - screenCenter) / screenCenter;

        float targetAngle = -mousePercent * maxTilt;

        float currentX = transform.localEulerAngles.x;
        if (currentX > 180) currentX -= 360;

        float newX = Mathf.Lerp(currentX, targetAngle, tiltSpeed * Time.deltaTime);

        transform.localRotation = Quaternion.Euler(newX, 0f, 0f);
    }
}
