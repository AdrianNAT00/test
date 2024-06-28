using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PuntuacionAlta : MonoBehaviour
{
    [System.Serializable]
    public class HighScoreData
    {
        public int highScore;
    }

    public int highScore;
    private Puntuacion puntuacionScript;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        puntuacionScript = FindObjectOfType<Puntuacion>();
    }

    void Awake()
    {
        LoadHighScore();
    }

    void Update()
    {
        // If the current score is greater than the high score, the high score is updated
        if (puntuacionScript.score > highScore)
        {
            highScore = puntuacionScript.score;
            SaveHighScore();
        }
        // Display score and high score with the canvas
        scoreText.text = "Score: " + puntuacionScript.score;
        highScoreText.text = "High Score: " + highScore;

        // Close the game and save the high score
        if (Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }

    // Save the high score
    public void SaveHighScore()
    {
        HighScoreData data = new HighScoreData();
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

        Debug.Log("High score saved: " + highScore);
    }

    // Load the high score
    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            HighScoreData data = JsonUtility.FromJson<HighScoreData>(json);
            highScore = data.highScore;

            Debug.Log("High score loaded: " + highScore);
        }
        else
        {
            Debug.LogWarning("Save file not found");
        }
    }
}
