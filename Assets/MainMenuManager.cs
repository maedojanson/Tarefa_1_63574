using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    [Header("CAIXINHAS DO MENU (Aceita qualquer tipo de texto!)")]
    public GameObject BestScoreTextMenu;  // Arrasta aqui o teu objeto "Recorde Atual"
    public TMP_InputField NameInput;      // Arrasta aqui a tua caixa "DigitarNome"

    private void Start()
    {
        if (DataPersistenceManager.Instance != null && BestScoreTextMenu != null)
        {
            string message = $"Best Score : {DataPersistenceManager.Instance.BestPlayerName} : {DataPersistenceManager.Instance.BestHighScore}";
            
            // Atualiza de forma flexível de acordo com o tipo de componente do objeto
            TMP_Text tmp = BestScoreTextMenu.GetComponent<TMP_Text>();
            if (tmp != null) tmp.text = message;

            UnityEngine.UI.Text legacyText = BestScoreTextMenu.GetComponent<UnityEngine.UI.Text>();
            if (legacyText != null) legacyText.text = message;
        }
    }

    public void StartGame()
    {
        if (DataPersistenceManager.Instance != null)
        {
            if (NameInput != null && !string.IsNullOrEmpty(NameInput.text))
            {
                DataPersistenceManager.Instance.CurrentPlayerName = NameInput.text;
            }
            else
            {
                DataPersistenceManager.Instance.CurrentPlayerName = "Jogador";
            }
        }

        SceneManager.LoadScene("DataPersistence");
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}