using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ResetGame()
    {
        gameObject.SetActive(false);
        EditorSceneManager.LoadScene("SampleScene");
    }
}
