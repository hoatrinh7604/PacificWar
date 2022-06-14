using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    [SerializeField] GameObject gameOver;
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI timeGP;
    [SerializeField] TextMeshProUGUI hightimeGP;
    [SerializeField] TextMeshProUGUI timeGO;

    float score = 0;
    float highscore = 0;
    float sliderValue = 0;

    private float time;

    [SerializeField] float timeOfGame;

    private void Start()
    {
        Reset();
    }

    private void Update()
    {
        time += Time.deltaTime;
        UpdateScore(time);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOver.SetActive(true);
    }

    public void UpdateScore(float value)
    {
        score = value;
        if(score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetFloat("time", highscore);
            hightimeGP.text = FloatToMin(highscore);
        }
        timeGP.text = FloatToMin(score);
        timeGO.text = FloatToMin(score);
    }

    public void UpdateSlider(int value)
    {
        sliderValue += value;
        slider.value = sliderValue;

        CheckGameState();
    }

    public void Restart()
    {
        GetComponent<SceneController>().StartGame();
    }

    public void CheckGameState()
    {
        if(sliderValue <= 0)
        {
            GameOver();
        }
    }

    public void Reset()
    {
        Time.timeScale = 1;
        gameOver.SetActive(false);
        sliderValue = timeOfGame;
        score = 0;
        slider.value = sliderValue;
        highscore = PlayerPrefs.GetFloat("time");
        hightimeGP.text = FloatToMin(highscore);
        timeGP.text = FloatToMin(score);
        timeGO.text = FloatToMin(score);
    }

    public string FloatToMin(float value)
    {
        int min = (int)value / 60;
        return min + "m" + ((int)value - min * 60) + "s";
    }
}
