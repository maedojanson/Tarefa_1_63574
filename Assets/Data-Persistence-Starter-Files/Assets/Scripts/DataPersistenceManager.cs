using System;
using System.Collections;
using System.Collections.Generic;
using System.IO; 
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DataPersistenceManager : MonoBehaviour
{
    public static DataPersistenceManager Instance { get; private set; }

    [Header("Configurações do Muro")]
    public Brick BrickPrefab; 
    public int LineCount = 6;

    [Header("CAIXINHAS DO JOGO (Arrasta os textos da cena aqui!)")]
    public GameObject ScoreText;       
    public GameObject BestScoreText;   
    public GameObject GameoverText;    

    [Header("Dados Globais Guardados")]
    public string CurrentPlayerName = "Jogador";
    public string BestPlayerName = "Ninguém";
    public int BestHighScore = 0;

    private int m_Points = 0;
    private bool m_GameOver = false;

    private void Awake()
    {
        // Garante que este objeto é o único chefe e não morre entre as cenas
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        // 💾 CARREGA IMEDIATAMENTE O RECORDE DO DISCO DO JOGO
        LoadHighScoreData();
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "DataPersistence")
        {
            InitLevel();
        }
    }

    private void InitLevel()
    {
        m_GameOver = false;
        m_Points = 0;
        
        // 💾 Garante que os dados guardados estão bem lidos antes de montar o ecrã
        LoadHighScoreData();
        
        // Reconecta as caixinhas de texto de forma segura
        RebindUIElements();
        
        SetupAutomaticBorders();
        GenerateBrickWall();
        
        // 🎯 FORÇA O TEXTO DO TOPO A MOSTRAR O NOME E O VALOR GUARDADOS!
        UpdateBestScoreDisplay();
    }

    private void Update()
    {
        // Se deu Game Over e premires ESPAÇO, reinicia o jogo mantendo o recorde na tela
        if (m_GameOver && Input.GetKeyDown(KeyCode.Space))
        {
            RestartGameRound();
        }
    }

    private void OnEnable() { SceneManager.sceneLoaded += OnSceneLoaded; }
    private void OnDisable() { SceneManager.sceneLoaded -= OnSceneLoaded; }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "DataPersistence")
        {
            InitLevel();
        }
    }

    private void RebindUIElements()
    {
        if (ScoreText == null) ScoreText = GameObject.Find("ScoreText");
        if (BestScoreText == null) BestScoreText = GameObject.Find("BestScoreText");
        
        if (GameoverText == null)
        {
            GameoverText = GameObject.Find("GameOverText");
            if (GameoverText == null) GameoverText = GameObject.Find("GameoverText");
        }

        if (GameoverText != null) 
        {
            GameoverText.SetActive(false); // Esconde o Game Over ao iniciar
        }
    }

    public void GenerateBrickWall()
    {
        if (BrickPrefab == null)
        {
            BrickPrefab = Resources.Load<Brick>("BrickPrefab");
        }

        if (BrickPrefab != null)
        {
            float step = 0.6f;
            int perLine = Mathf.FloorToInt(4.0f / step);
            int[] points = {1, 1, 2, 2, 5, 5};

            for (int i = 0; i < LineCount; ++i)
            {
                for (int x = 0; x < perLine; ++x)
                {
                    Vector3 pos = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                    var brick = Instantiate(BrickPrefab, pos, Quaternion.identity);
                    brick.PointValue = points[i];
                    brick.onDestroyed.AddListener(AddPoint);
                }
            }
        }
    }

    private void SetupAutomaticBorders()
    {
        if (GameObject.Find("L") != null) return;
        CreateWall("L", new Vector3(-2.6f, 2f, 0f), new Vector3(0.5f, 8f, 2f));
        CreateWall("R", new Vector3(2.6f, 2f, 0f), new Vector3(0.5f, 8f, 2f));
        CreateWall("T", new Vector3(0f, 4.9f, 0f), new Vector3(6f, 0.5f, 2f));
    }

    private void CreateWall(string n, Vector3 p, Vector3 s)
    {
        GameObject w = GameObject.CreatePrimitive(PrimitiveType.Cube);
        w.name = n; w.transform.position = p; w.transform.localScale = s;
        Destroy(w.GetComponent<MeshRenderer>());
    }

    public void RestartGameRound()
    {
        m_GameOver = false;
        m_Points = 0;
        SceneManager.LoadScene("DataPersistence");
    }

    public void AddPoint(int p)
    {
        if (m_GameOver) return;
        
        m_Points += 1; 
        SetTextOnObject(ScoreText, $"Score : {m_Points}");
        
        // Se ultrapassares o recorde atual, o topo atualiza em tempo real!
        if (m_Points > BestHighScore)
        {
            BestHighScore = m_Points;
            BestPlayerName = CurrentPlayerName;
            UpdateBestScoreDisplay();
        }
    }

    public void TriggerGameOver()
    {
        m_GameOver = true;
        
        // 🎯 FAZ O GAME OVER APARECER SEM FALHAS!
        if (GameoverText != null) 
        {
            GameoverText.SetActive(true);
        }

        // Se a pontuação for o novo recorde, guarda permanentemente
        if (m_Points >= BestHighScore)
        {
            BestHighScore = m_Points;
            BestPlayerName = CurrentPlayerName;
            SaveHighScoreData();
            UpdateBestScoreDisplay();
        }
    }

    // 🎯 SISTEMA COMPATÍVEL: Escreve "Best Score : Nome : Valor" perfeitamente na tela
    public void UpdateBestScoreDisplay()
    {
        if (string.IsNullOrEmpty(BestPlayerName))
        {
            BestPlayerName = "Ninguém";
        }
        
        SetTextOnObject(BestScoreText, $"Best Score : {BestPlayerName} : {BestHighScore}");
    }

    private void SetTextOnObject(GameObject targetObj, string message)
    {
        if (targetObj == null) return;

        TMP_Text tmp = targetObj.GetComponent<TMP_Text>();
        if (tmp != null) { tmp.text = message; return; }

        UnityEngine.UI.Text legacyText = targetObj.GetComponent<UnityEngine.UI.Text>();
        if (legacyText != null) { legacyText.text = message; return; }
    }

    [System.Serializable] 
    class SaveData { public string n; public int s; }

    public void SaveHighScoreData()
    {
        SaveData d = new SaveData { n = BestPlayerName, s = BestHighScore };
        File.WriteAllText(Application.persistentDataPath + "/save.json", JsonUtility.ToJson(d));
    }

    public void LoadHighScoreData()
    {
        string p = Application.persistentDataPath + "/save.json";
        if (File.Exists(p))
        {
            SaveData d = JsonUtility.FromJson<SaveData>(File.ReadAllText(p));
            BestPlayerName = d.n; 
            BestHighScore = d.s;
        }
    }
}