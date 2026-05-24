using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Configurações de Condução")]
    public float speed = 15.0f;       // Velocidade real do carro
    public float turnSpeed = 60.0f;   // Velocidade da curva
    
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        // Tranca as rotações para ele nunca capotar nem ficar em duas rodas
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }

    void FixedUpdate()
    {
        // 1. Ler as teclas do teclado
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // 2. VELOCIDADE DIRETA POR FÍSICA (Anda sempre, não falha!)
        // Define a velocidade do corpo rígido diretamente na direção do carro
        rb.linearVelocity = transform.forward * forwardInput * speed;

        // 3. Rotação do carro nas curvas
        float turn = horizontalInput * turnSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}