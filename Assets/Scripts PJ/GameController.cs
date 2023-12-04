using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool isStart = false;
    public bool isGameover = false;
    public GameObject startGroup,panelGroup,gameOverGroup,SpawnPoint;
    public TextMeshPro ScoreLabel, LifeLabel;
    public int score = 0;
    public int hp = 3;
    
    void Start()
    {
        startGroup.SetActive(true);
        panelGroup.SetActive(false);
        gameOverGroup.SetActive(false);
        SpawnPoint.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart)
        {
            startGroup.SetActive(false);
            panelGroup.SetActive(true);
            gameOverGroup.SetActive(false);
            SpawnPoint.SetActive(true);
        }
        else
        {
            startGroup.SetActive(true);
            panelGroup.SetActive(false);
            gameOverGroup.SetActive(false);
            SpawnPoint.SetActive(false);
        }

        ScoreLabel.text = "Score:" + score;
        LifeLabel.text = "Life:" + hp;

        if (hp <= 0)
        {
            hp = 0;
            isGameover = true;
        }

        if (isGameover)
        {
            SpawnPoint.SetActive(false);
            startGroup.SetActive(false);
            panelGroup.SetActive(true);
            gameOverGroup.SetActive(true);
            StartCoroutine(reSetLevel());
        }
    }

    IEnumerator reSetLevel()
    {
        yield return new WaitForSeconds(0.1f);
        isStart = false;
        isGameover = false;
    }

    public void getTriggerstart()
    {
        isStart = true;
    }

    public void getScore()
    {
        score = score + 1;
    }
    public void getDamage()
    {
        hp = hp - 1;
    }
}
