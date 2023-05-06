using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
    public bool isEndGame;
    private bool isStartGame;
    public TextMeshProUGUI txtPoint;
    public GameObject pnlEndGame;
    public TextMeshProUGUI txtEndGame;

    public UnityEngine.UI.Button btnRestart;
    public Sprite btnHover;
    public Sprite btnClick;
    public Sprite btnIdle;

    private int gamePoint;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.5f;
        isEndGame = false;
        isStartGame = true;
        gamePoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isEndGame)
        {
            if (Input.GetMouseButton(0) && isStartGame)
            {
                StartGame();
            }
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                Time.timeScale = 1;
            }
        }
    }
    public void EndGame()
    {
        Debug.Log("End Game");
        Time.timeScale = 0;
        isEndGame = true;
        pnlEndGame.SetActive(true);
        txtEndGame.text = "Your Point: " + gamePoint.ToString();
        isStartGame = false;
    }
    public void GetPoint()
    {
        gamePoint++;
        txtPoint.text = "Point: " + gamePoint.ToString();
    }
    void StartGame()
    {
        //load scene
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        StartGame();
    }
    public void RestartButtonClick()
    {
        btnRestart.GetComponent<UnityEngine.UI.Image>().sprite = btnClick;
    }
    public void RestartButtonHovoer()
    {
        btnRestart.GetComponent<UnityEngine.UI.Image>().sprite = btnHover;
    }
    public void RestartButtonIdle()
    {
        btnRestart.GetComponent<UnityEngine.UI.Image>().sprite = btnIdle;
    }
}
