using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameDirector : MonoBehaviour
{
    GameObject timerText;
    GameObject pointText;
    ItemGenerator generator;

    [Header("結算按鈕設定")]
    public GameObject nextLevelButton; // 分數夠時顯示的下一關按鈕
    public GameObject retryButton;     // 分數不夠時顯示的重玩一次按鈕

    [Header("關卡時間與升關分數門檻")]
    public float time = 20.0f;
    public int nextLevelScore = 500;// 達標分數門檻
    public string nextSceneName; // 下一關 Scene 名稱

    int point = 0;
    int levelNumber = 1;
    int currentPhase = 0;
    bool isGameOver = false;

    void Start()
    {
        this.timerText = GameObject.Find("Time");
        this.pointText = GameObject.Find("Point");
        this.generator = FindObjectOfType<ItemGenerator>();

        // 先隱藏兩個按鈕
        if (nextLevelButton != null) nextLevelButton.SetActive(false);
        if (retryButton != null) retryButton.SetActive(false);

        string sceneName = SceneManager.GetActiveScene().name.ToLower();
        if (sceneName.Contains("level3") || sceneName.Contains("3"))
        {
            levelNumber = 3;
        }
        else if (sceneName.Contains("level2") || sceneName.Contains("2"))
        {
            levelNumber = 2;
        }
        else
        {
            levelNumber = 1;
        }

        ApplyDifficultyByTime();
        UpdateUI();
    }

    void ApplyDifficultyByTime()
    {
        int phase;
        float span;
        float speed;
        int ratio;

        if (this.time > 10.0f)
        {
            phase = 1;
            if (levelNumber == 1)
            {
                span = 0.85f; speed = -0.065f; ratio = 3;
            }
            else if (levelNumber == 2)
            {
                span = 0.60f; speed = -0.090f; ratio = 5;
            }
            else
            {
                span = 0.38f; speed = -0.120f; ratio = 6;
            }
        }
        else
        {
            phase = 2;
            if (levelNumber == 1)
            {
                span = 0.45f; speed = -0.090f; ratio = 5;
            }
            else if (levelNumber == 2)
            {
                span = 0.32f; speed = -0.120f; ratio = 6;
            }
            else
            {
                span = 0.22f; speed = -0.155f; ratio = 8;
            }
        }

        if (this.currentPhase != phase && generator != null)
        {
            this.currentPhase = phase;
            generator.SetParameter(span, speed, ratio);
        }
    }

    public void GetApple()
    {
        if (isGameOver) return;

        if (this.time <= 10.0f)
        {
            if (levelNumber == 1)
            {
                this.point += 200;
            }
            else if (levelNumber == 2)
            {
                this.point += 300;
            }
            else
            {
                this.point += 500;
            }
        }
        else
        {
            this.point += 100;
        }
        UpdateUI();
    }

    public void GetBomb()
    {
        if (isGameOver) return;

        if (this.time <= 10.0f)
        {
            this.point = 0;
        }
        else
        {
            this.point /= 2;
        }
        UpdateUI();
    }

    public void GoToNextLevel()
    {
        Time.timeScale = 1f;
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            int nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if (nextIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextIndex);
            }
        }
    }

    public void RetryLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void ShowEndResult()
    {
        bool isPassed = this.point >= this.nextLevelScore;

        if (nextLevelButton != null)
        {
            nextLevelButton.SetActive(isPassed);
        }

        if (retryButton != null)
        {
            retryButton.SetActive(!isPassed);
        }
    }

    void Update()
    {
        if (isGameOver) return;

        this.time -= Time.deltaTime;

        if (this.time <= 0f)
        {
            this.time = 0f;
            this.isGameOver = true;

            if (generator != null)
            {
                generator.StopGenerator();
            }

            UpdateUI();
            ShowEndResult();
            return;
        }

        ApplyDifficultyByTime();
        UpdateUI();
    }

    void UpdateUI()
    {
        if (this.timerText != null)
        {
            this.timerText.GetComponent<TextMeshProUGUI>().text =
                $"LV.{levelNumber} | {this.time.ToString("F1")} s";
        }
        if (this.pointText != null)
        {
            this.pointText.GetComponent<TextMeshProUGUI>().text =
                $"{this.point} point";
        }
    }
}