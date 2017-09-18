using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Text scoreText;
    public GameObject victoryText;

    GameObject[] pauseObjects;
    private bool isPaused;

    // Use this for initialization
    void Start () {
        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("isPaused");
        hidePauseButtons();
        isPaused = false;
        GameManager.instance.score = 0;
        GameManager.instance.finishedLevel = false;
        victoryText.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (!isPaused)
            {
                isPaused = true;
                Time.timeScale = 0;
                showPauseButtons();
            }
          else if (isPaused && !GameManager.instance.finishedLevel)
            {
                isPaused = false;
                Time.timeScale = 1;
                hidePauseButtons();
            }
        }

        if(GameManager.instance.finishedLevel)
        {
            Time.timeScale = 0;
            showPauseButtons();
            showWinningText();
        }
        scoreText.text = "Score: " + GameManager.instance.score;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        hidePauseButtons();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void showPauseButtons()
    {
        foreach (GameObject g in pauseObjects)
            g.SetActive(true);
    }

    public void hidePauseButtons()
    {
        foreach (GameObject g in pauseObjects)
            g.SetActive(false);
    }

    public void showWinningText()
    {
        victoryText.SetActive(true);
    }
}
