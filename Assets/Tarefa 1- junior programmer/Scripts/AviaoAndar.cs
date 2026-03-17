using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AviaoAndar : MonoBehaviour
{
    public float speed = 20f;
    public float maxTilt = 30f;     // inclinação máxima
    public float tiltSpeed = 5f;    // suavidade da inclinação

    void Update()
    {
        // ======================
        // MOVIMENTO FRENTE/TRÁS
        // ======================
        float moveInput = Input.GetAxis("Vertical");

        // move na direção do avião (permite subir/descer)
        transform.Translate(Vector3.forward * speed * moveInput * Time.deltaTime, Space.Self);

        // ======================
        // CONTROLE PELO MOUSE
        // ======================
        float mouseY = Input.mousePosition.y;
        float screenCenter = Screen.height / 2f;

        // valor entre -1 e 1
        float mousePercent = (mouseY - screenCenter) / screenCenter;

        // ângulo desejado
        float targetAngle = -mousePercent * maxTilt;

        // rotação atual
        float currentX = transform.localEulerAngles.x;
        if (currentX > 180) currentX -= 360;

        // suavizar inclinação
        float newX = Mathf.Lerp(currentX, targetAngle, tiltSpeed * Time.deltaTime);

        // aplicar rotação (sem entortar)
        transform.localRotation = Quaternion.Euler(newX, 0f, 0f);
    }
}
    
