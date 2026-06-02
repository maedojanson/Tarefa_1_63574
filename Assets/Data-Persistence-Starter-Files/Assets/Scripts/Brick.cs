using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Brick : MonoBehaviour
{
    public UnityEvent<int> onDestroyed;
    public int PointValue = 1; 

    private Color colorCyanBlue = new Color(0.00f, 0.90f, 0.95f);  
    private Color colorLavender = new Color(0.78f, 0.63f, 0.90f);  
    private Color colorMintGreen = new Color(0.60f, 0.93f, 0.78f); 

    void Start()
    {
        var renderer = GetComponentInChildren<Renderer>();
        if (renderer == null) return;

        MaterialPropertyBlock block = new MaterialPropertyBlock();
        switch (PointValue)
        {
            case 1: block.SetColor("_BaseColor", colorCyanBlue); break;
            case 2: block.SetColor("_BaseColor", colorLavender); break;
            case 5: block.SetColor("_BaseColor", colorMintGreen); break;
            default: block.SetColor("_BaseColor", colorCyanBlue); break;
        }
        renderer.SetPropertyBlock(block);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (onDestroyed != null)
        {
            onDestroyed.Invoke(PointValue);
        }
        
        Destroy(gameObject); 
    }
}