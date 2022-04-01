using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    // Start is called before the first frame update

    private Button diffButton; 
    private GameManager gameManager;

    public int difficulty; 
    public int lives; 

    void Start()
    {
        diffButton = GetComponent<Button>();
        diffButton.onClick.AddListener(SetDifficulty);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDifficulty(){
        Debug.Log(diffButton.gameObject.name + "was clicked");
        gameManager.StartGame(difficulty, lives);

    }
}
