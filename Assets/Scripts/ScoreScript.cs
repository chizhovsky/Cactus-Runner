using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    private int _score;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _highscoreText;

    private float _timer;
    float _maxTime;
    
    void Start()
    {
        _highscoreText.text = "HI " + PlayerPrefs.GetInt("highscore", 0).ToString("00000");
        _score = 0;
        _maxTime = 0.3f;
    }

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _maxTime)
        {
            _score++;
            _scoreText.text = _score.ToString("00000");
            _timer = 0;
            if (_score % 100 == 0)
            {
                GetComponent<AudioSource>().Play();
                Time.timeScale += 0.1f;
            }
        }

        if(Time.timeScale == 0)
        {
            if (_score > PlayerPrefs.GetInt("highscore", 0))
            {
                PlayerPrefs.SetInt("highscore", _score);
                _highscoreText.text = "HI " + PlayerPrefs.GetInt("highscore", 0).ToString("00000");
            }
        }
    }
}