using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Mudámos o nome para PizzaCollision para o Unity não chiar com duplicados!
public class PizzaCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Se bater na Farmer, não faz nada
        if (other.CompareTag("Player"))
        {
            return;
        }

        // Se a pizza tocar no cão, esconde os dois!
        gameObject.SetActive(false);
        other.gameObject.SetActive(false);
    }
}
