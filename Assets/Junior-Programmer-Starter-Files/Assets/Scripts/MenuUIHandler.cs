using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public ColorPicker ColorPicker;

    public void NewColorSelected(Color color)
    {
        if (MainManager.Instance != null)
        {
            MainManager.Instance.TeamColor = color;
        }
    }

    private void Start()
    {
        ColorPicker.Init();
        ColorPicker.onColorChanged += NewColorSelected;

        if (MainManager.Instance != null)
        {
            ColorPicker.SelectColor(MainManager.Instance.TeamColor);
        }
    }

    public void StartNew()
    {
        // Carrega o armazém diretamente pelo nome da cena
        SceneManager.LoadScene("Main"); 
    }

    public void SaveColorClicked()
    {
        if (MainManager.Instance != null)
        {
            MainManager.Instance.SaveColor();
        }
    }

    public void LoadColorClicked()
    {
        if (MainManager.Instance != null)
        {
            MainManager.Instance.LoadColor();
            ColorPicker.SelectColor(MainManager.Instance.TeamColor);
        }
    }

    public void Exit()
    {
        if (MainManager.Instance != null)
        {
            MainManager.Instance.SaveColor();
        }

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
