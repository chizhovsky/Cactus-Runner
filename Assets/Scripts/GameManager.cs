using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
	public static GameManager Instance
	{
		get { return _instance; }
	}

    public GameObject gameOverPanel;
    [SerializeField] private Button _retryButton;
    [SerializeField] private Button _menuButton;

    public bool gameIsOver;

    private void Awake() 
    {
        _instance = this;
    }

    void Start()
    {
        gameIsOver = false;
        Time.timeScale = 1;
        _retryButton.onClick.AddListener(RetryButtonPressed);
        _menuButton.onClick.AddListener(MenuButtonPressed);
    }

    public void GameOver()
    {
        gameIsOver = true;
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        GetComponent<AudioSource>().Play();
    }

    private void RetryButtonPressed()
    {
        SceneManager.LoadScene("2.Game");
    }
    private void MenuButtonPressed()
    {
        SceneManager.LoadScene("1.Menu");
    }
}