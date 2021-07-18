using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StartMenuScript : MonoBehaviour
{
    [SerializeField] private Text _highscoreText;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ButtonPressed);
        _highscoreText.text = "Your record: " + PlayerPrefs.GetInt("highscore", 0).ToString("00000");
    }

    private void ButtonPressed()
    {
        SceneManager.LoadScene("2.Game");
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
