using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEditor;

[System.Serializable]
public class PuntuacionAlta : MonoBehaviour
{
    public int highScore;
    private Puntuacion puntuacionScript;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        LoadHighScore();
        puntuacionScript = FindObjectOfType<Puntuacion>();
    }
    void Awake()
    {
        LoadHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        // If the current score is greater than the high score, the high score is updated
        if (puntuacionScript.score > highScore)
        {
            highScore = puntuacionScript.score;
            SaveHighScore();
        }
        //Display score and high score with the canvas
        scoreText.text = "Score: " + puntuacionScript.score;
        highScoreText.text = "High Score: " + highScore;
        //Close the game and save the high score
        if (Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
    }
    //Save the high score
    public void SaveHighScore()
    {
        string json = JsonUtility.ToJson(highScore);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    //Load the high score
    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            highScore = JsonUtility.FromJson<int>(json);
        }
    }
}
