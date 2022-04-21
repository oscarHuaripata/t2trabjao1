using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text scoreBronce;
    public Text scorePlata;
    public Text scoreOro;
    
    public Text scoreText;
    
    private int Bronce = 0;
    private int Plata = 0;
    private int Oro = 0;
    
    private int _score = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreBronce.text = "Moneda Bronce:" + Bronce;
        scorePlata.text = "Moneda Plata: " + Plata;
        scoreOro.text = "Moneda Oro: " + Oro;
        
        scoreText.text = "Puntaje: " + _score;
       
    }
    
    public int GetScore()
    {
        return _score;
    }

    // Update is called once per frame
    public int GetBronce()
    {
        return Bronce;
    }


    public int GetPlata()
    {
        return Plata;
    }
    
    
    public int GetOro()
    {
        return Oro;
    }
    
    public void PlusScore(int score)
    {
        _score += score;
        scoreText.text = "Puntaje: " + _score;
    }
    
    public void PlusBronce(int score)
    {
        Bronce += score;
        scoreBronce.text = "Moneda Bronce:" + Bronce;
    }
 
    
    public void PlusPlata(int score)
    {
        Plata += score;
        scorePlata.text = "Moneda Plata: " + Plata;
    }
    
    public void PlusOro(int score)
    {
        Oro += score;
        scoreOro.text = "Moneda Oro: " + Oro;
    }
    
   
}
