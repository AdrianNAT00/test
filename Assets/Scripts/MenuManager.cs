using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Button startButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //When the Start button is clicked, the game will start
        startButton.onClick.AddListener(StartGame);
    }

    public void StartGame()
    {
        //Load the game scene
        SceneManager.LoadScene(1);
    }
}
