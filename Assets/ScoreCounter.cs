using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public float score;
    public float scorePerSecond;
    public float scorePerClick;
    private float timer = 0f;
    private float timeToIncrement = 1f;
    [SerializeField]
    private float scoreNeededSPSUpgrade = 10;
    [SerializeField]
    private float scoreNeededSPCUpgrade = 10;
    [SerializeField]
    private float bigClickUpgrade = 1000f;
    public TextMeshProUGUI scoreDisplay;
    public TextMeshProUGUI clickUpgradeText;
    public TextMeshProUGUI secondUpgradeText;
    public TextMeshProUGUI bigClickUpgradeText;

    void Update()
    {
        timer += Time.deltaTime;
        if(timer > timeToIncrement)
        {
            score += scorePerSecond;
            timer = 0f;
        }
        scoreDisplay.text = "Score: " + score;
    }

    public void scorePerSecondUpgrade(float amountToUpgrade)
    {
        if (score > scoreNeededSPSUpgrade)
        {
            scorePerSecond += amountToUpgrade;
            score -= scoreNeededSPSUpgrade;
            scoreNeededSPSUpgrade += 10;
            secondUpgradeText.text = "INCREASE SCORE PER SECOND\nScore needed: " + scoreNeededSPSUpgrade;
        }
    }

    public void scorePerClickUpgrade(float amountToUpgrade)
    {
        if(score > scoreNeededSPCUpgrade)
        {
            scorePerClick += amountToUpgrade;
            score -= scoreNeededSPCUpgrade;
            scoreNeededSPCUpgrade += 10;
            clickUpgradeText.text = "INCREASE SCORE PER CLICK\nScore needed: " + scoreNeededSPCUpgrade;
        }
    }

    public void bigClickUpgradeButton(float amountToUpgrade)
    {
        if(score > bigClickUpgrade)
        {
            scorePerClick += amountToUpgrade;
            score -= bigClickUpgrade;
            bigClickUpgrade += scorePerClick * 15;
            bigClickUpgradeText.text = "BIG INCREASE\nTO SCORE PER CLICK\nScore needed: " + bigClickUpgrade;
        }
    }

    public void addToScore()
    {
        score += scorePerClick;
    }
}
