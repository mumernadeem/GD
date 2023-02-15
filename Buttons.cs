using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;
public class Buttons : MonoBehaviour
{
    public Button startGame;
    public Text scores;
    public bool startGameCheck = false;
    public int score=0;
    // Start is called before the first frame update
    void Start()
    {
        scores.text = "Total Coins Collected: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddScore(int s)
    {
        score = score + s;
        scores.text = "Total Coins Collected: " + score;
    }
    public void startTheGame()
    {
        startGameCheck = true;
        startGame.gameObject.SetActive(false);
    }

    public void restartTheGame()
    {
        EditorSceneManager.LoadScene("SampleScene");
    }
}
