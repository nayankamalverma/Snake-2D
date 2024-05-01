using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject snake;
    [SerializeField]
    private Button Resume;
    [SerializeField]
    private Button Exit;
    private SnakeController snakeController;
    private void Awake()
    {
        snakeController = snake.GetComponent<SnakeController>();
        
        Resume.onClick.AddListener(ResumeGame);
        Exit.onClick.AddListener(LoadLobby);
    }

    void ResumeGame()
    {
        SoundManger.Instance.Play(Sounds.ButtonClick);
        snakeController.enabled=true;
        gameObject.SetActive(false);
    }

    void LoadLobby()
    {
        SoundManger.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(0);
    }
}
