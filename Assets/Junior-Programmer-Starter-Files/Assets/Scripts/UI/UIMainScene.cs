using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Controla a troca de ecrãs!
using UnityEngine.UI;

public class UIMainScene : MonoBehaviour
{
    public interface IUIInfoContent
    {
        string GetName();
        string GetData();
        void GetContent(ref List<Building.InventoryEntry> content);
    }

    public static UIMainScene Instance { get; private set; }

    public GameObject InfoPopup;
    public MainManager ResourceDB; 

    private IUIInfoContent m_CurrentContent;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (m_CurrentContent != null)
        {
            RefreshContent();
        }
    }

    public void SetNewContent(IUIInfoContent content)
    {
        m_CurrentContent = content;
        
        if (m_CurrentContent == null)
        {
            if (InfoPopup != null) InfoPopup.SetActive(false);
        }
        else
        {
            if (InfoPopup != null) InfoPopup.SetActive(true);
            RefreshContent();
        }
    }

    private void RefreshContent()
    {
        // Mantém a estrutura original da Unity intacta
    }

    // 🚪 FUNÇÃO DO BOTÃO: Salva a cor e força o carregamento seguro da cena "Menu"
    public void BackToMenu()
    {
        if (MainManager.Instance != null)
        {
            MainManager.Instance.SaveColor();
        }

        // Usar o nome direto da cena garante que o Unity não carrega um cenário vazio!
        SceneManager.LoadScene("Menu"); 
    }
}