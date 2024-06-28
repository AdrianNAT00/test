using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Button startButton;
    public static MenuManager instance { get; private set; }
    public Button[] colorButtons; 
    public Color[] colors;
    public Color colorToApply;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < colorButtons.Length; i++)
        {
            int index = i; // Local copy of the index for the lambda
            colorButtons[i].onClick.AddListener(() => ChangeColor(colors[index]));
        }
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Ensure this object persists across scenes
        }
        else
        {
            Destroy(gameObject);
        }
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
    public void SetColor(Color newColor)
    {
        colorToApply = newColor;
    }
    void ChangeColor(Color newColor)
    {
        instance.SetColor(newColor);
    }
}
