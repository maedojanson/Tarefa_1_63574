using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject);

        // Comunica diretamente o Game Over ao DataPersistenceManager ativo
        if (DataPersistenceManager.Instance != null)
        {
            DataPersistenceManager.Instance.TriggerGameOver();
        }
    }
}