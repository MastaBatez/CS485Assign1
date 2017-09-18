using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	public void StartRollABall()
    {
        SceneManager.LoadScene(1);
    }

    public void StartGame2()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
