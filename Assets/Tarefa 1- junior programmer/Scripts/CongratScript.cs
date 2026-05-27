using System.Collections;
using System.Collections.Generic; // CORRIGIDO: Necessário para usar List<>!
using UnityEngine;

public class CongratScript : MonoBehaviour
{
    public TextMesh Text;
    public ParticleSystem SparksParticles;
    
    private List<string> TextToDisplay = new List<string>(); // CORRIGIDO: Inicializada a lista de raiz!
    
    private float RotatingSpeed;
    private float TimeToNextText;

    private int CurrentText;
    
    // Start is called before the first frame update
    void Start()
    {
        TimeToNextText = 0.0f;
        CurrentText = 0; // CORRIGIDO: Faltava o ponto e vírgula ';'
        
        RotatingSpeed = 1.0f; // CORRIGIDO: Adicionado o 'f' para indicar que é float

        TextToDisplay.Add("Congratulation");
        TextToDisplay.Add("All Errors Fixed");

        if (Text != null)
        {
            Text.text = TextToDisplay[0];
        }
        
        if (SparksParticles != null)
        {
            SparksParticles.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        TimeToNextText += Time.deltaTime;

        if (TimeToNextText > 1.5f)
        {
            TimeToNextText = 0.0f;
            
            CurrentText++;
            
            if (CurrentText >= TextToDisplay.Count)
            {
                CurrentText = 0;
            } // CORRIGIDO: Faltava fechar esta chaveta do IF!

            if (Text != null)
            {
                Text.text = TextToDisplay[CurrentText];
            }
        }
    }
}