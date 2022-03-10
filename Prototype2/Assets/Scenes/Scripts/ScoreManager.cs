using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager Instance = new ScoreManager();
    private int ScorePoints;
    public TMP_Text ScoreText;
    private ScoreManager()
    {


    }


    public static ScoreManager GetInstance()
    {
            
        return Instance;
    }

    public void AddPoints(int points)
    {

       // ScoreText.text ="OK";
        GetInstance().ScorePoints = GetInstance().ScorePoints + points;
        Debug.Log(ScorePoints);

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
}
