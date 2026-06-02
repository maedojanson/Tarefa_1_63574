using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody m_Rigidbody;
    private bool m_Started = false;

    [Header("Física Clássica")]
    public float Speed = 3.5f; // Velocidade lenta, gostosa e perfeitamente controlável!

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        
        if (m_Rigidbody != null)
        {
            m_Rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
            m_Rigidbody.useGravity = false; 
            
            m_Rigidbody.constraints = RigidbodyConstraints.FreezePositionZ | 
                                      RigidbodyConstraints.FreezeRotationX | 
                                      RigidbodyConstraints.FreezeRotationY | 
                                      RigidbodyConstraints.FreezeRotationZ;
        }
    }

    void Update()
    {
        if (!m_Started && Input.GetKeyDown(KeyCode.Space))
        {
            m_Started = true;
            transform.SetParent(null); 
            
            if (m_Rigidbody != null)
            {
                float randomDirection = UnityEngine.Random.Range(-0.3f, 0.3f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0).normalized;
                m_Rigidbody.linearVelocity = forceDir * Speed;
            }
        }
    }

    void FixedUpdate()
    {
        if (m_Started && m_Rigidbody != null)
        {
            // Trava a bola na velocidade lenta constante para não acelerar nem desacelerar
            m_Rigidbody.linearVelocity = m_Rigidbody.linearVelocity.normalized * Speed;
        }
    }
    
    private void OnCollisionExit(Collision other)
    {
        if (m_Rigidbody == null) return;

        Vector3 currentVelocity = m_Rigidbody.linearVelocity;

        // Sistema anti-ângulo morto horizontal
        if (Mathf.Abs(currentVelocity.y) < 0.5f)
        {
            currentVelocity.y = currentVelocity.y >= 0 ? 1.0f : -1.0f;
        }

        m_Rigidbody.linearVelocity = currentVelocity.normalized * Speed;
    }
}
