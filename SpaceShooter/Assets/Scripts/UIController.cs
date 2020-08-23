using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private Button startButton;
    [SerializeField]
    private Button quitButton;
    [SerializeField]
    private Button optionsButton;

    [SerializeField]
    private GameObject optionMenu;

    [SerializeField]
    private Transform heli;
    [SerializeField]
    private float heliMoveSpeed = 1;
    [SerializeField]
    private float HeliAccel = 1.005f;

    [SerializeField] 
    private float timeBeforeGameStart = 1f;

    private WaitForSeconds waitTime;

    private bool startGame;

    private void Awake()
    {
        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);
        optionsButton.onClick.AddListener(ShowOnOptionMenu);
        
        waitTime = new WaitForSeconds(timeBeforeGameStart);
    }

    private void StartGame()
    {
        startGame = true;
        StartCoroutine(StartGameDelayed());
    }

    private void ShowOnOptionMenu()
    {
        optionMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    private static void QuitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (!startGame) return;
        Vector2 position = heli.position;
        position =
            Vector3.MoveTowards(position, position + Vector2.up, Time.deltaTime * heliMoveSpeed);
        heli.position = position;

        heliMoveSpeed *= HeliAccel;
    }

    private IEnumerator StartGameDelayed()
    {
        yield return waitTime;
        SceneManager.LoadScene("Main");
    }
}