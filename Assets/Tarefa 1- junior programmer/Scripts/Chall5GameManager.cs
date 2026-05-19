using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Chall5GameManager : MonoBehaviour
{
    public List<GameObject> targetPrefabs;
    
    [Header("Configurações Físicas")]
    [Range(-30f, -1f)]
    public float gravidadeManual = -20f; 

    public int dificuldadeAtual = 1; 
    private float spawnRate = 2.0f; 
    private int score;
    private float timeLeft = 60.0f;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;
    public bool isGameActive;

    void Update()
    {
        Physics.gravity = new Vector3(0, gravidadeManual, 0);

        if (isGameActive)
        {
            timeLeft -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.Round(timeLeft);
            if (timeLeft <= 0) GameOver();
        }
    }

    public void StartGame(int difficulty)
    {
        // 1. Limpa qualquer spawn que já esteja a correr para não duplicar ✅
        StopAllCoroutines(); 

        isGameActive = true;
        score = 0;
        timeLeft = 60.0f;
        dificuldadeAtual = difficulty; 
        
        spawnRate = 2.0f; // Fixado em 2 segundos como pediste ✅

        UpdateScore(0);
        StartCoroutine(SpawnTarget());
        titleScreen.SetActive(false);
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            // O segredo está aqui: Espera 2 segundos ANTES de criar ✅
            yield return new WaitForSeconds(spawnRate);
            
            if (isGameActive)
            {
                int index = Random.Range(0, targetPrefabs.Count);
                Instantiate(targetPrefabs[index]);
            }
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        isGameActive = false;
        StopAllCoroutines(); // Para o spawn imediatamente no Game Over ✅
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
