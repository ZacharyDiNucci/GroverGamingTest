using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    /*  This is a basic script to run the starting of the game.
        This is assosiated with the start menu panel which gives the game a place to allow for easy resetting so at the end it can reset values easily.
        This page also gives a basic place for rules or just a basic how to of the game so that people know what to do.
    */
    [SerializeField]
    private Button startBtn = null;
    [SerializeField]
    private GameObject startPanel = null;
    [SerializeField]
    private GameObject gamePanel = null;
    [SerializeField]
    private Text balanceText = null;

    void Start()
    {
        startPanel.SetActive(true);
        gamePanel.SetActive(false);
        startBtn.onClick.AddListener(startGame);
    }

    private void startGame(){
        startPanel.SetActive(false);
        gamePanel.SetActive(true);
        balanceText.text = "Bal: $10.00";
    }
    public void endGame(){
        startPanel.SetActive(true);
        gamePanel.SetActive(false);
    }
}
