using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject instructionsMenu;
    [SerializeField] GameObject failMenu;
    [SerializeField] GameObject winMenu;

    private void Awake() {
        mainMenu.SetActive(true);
        instructionsMenu.SetActive(false);
        failMenu.SetActive(false);
        winMenu.SetActive(false);
    }

    public void Play() {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void HowToPlay() {
        instructionsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void Quit() {
        failMenu.SetActive(false);
        Time.timeScale = 1;
        Application.Quit();
        Debug.Log("Quitting...");
    }

    public void Back() {
        mainMenu.SetActive(true);
        instructionsMenu.SetActive(false);
    }

    public void BackToMenu() {
        failMenu.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void ShowFail() {
        Time.timeScale = 0;
        failMenu.SetActive(true);
    }

    public void ShowWin() {
        Time.timeScale = 0;
        winMenu.SetActive(true);
    }
}
