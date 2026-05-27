using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Importante para o Texto!

public class Counter : MonoBehaviour
{
    public Text CounterText; // Onde arrastas o texto da UI
    private int Count = 0;   // O número que vai subir

    private void Start()
    {
        Count = 0;
        CounterText.text = "Count : " + Count;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Sempre que algo entra no "balde", ele soma 1!
        Count += 1;
        CounterText.text = "Count : " + Count;
    }
}
