using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject instructionsMenu;

    private void Awake() {
        mainMenu.SetActive(true);
        instructionsMenu.SetActive(false);
    }

    public void Play() {
        SceneManager.LoadScene(0);
    }

    public void HowToPlay() {
        instructionsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void Quit() {
        Application.Quit();
        Debug.Log("Quitting...");
    }

    public void Back() {
        mainMenu.SetActive(true);
        instructionsMenu.SetActive(false);
    }
}
