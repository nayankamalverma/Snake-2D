using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private Button resume;
    [SerializeField] private Button exit; 

    private void Awake()
    {        
        resume.onClick.AddListener(ResumeGame);
        exit.onClick.AddListener(LoadLobby);
    }

    void ResumeGame()
    {
        SoundManger.Instance.Play(Sounds.ButtonClick);
        GameManager.Instance.ResumeGame();
        gameObject.SetActive(false);
    }

    void LoadLobby()
    {
        SoundManger.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(0);
    }

    private void OnDestroy()
    {
        resume.onClick.RemoveListener(ResumeGame);
        exit.onClick.RemoveListener(LoadLobby);
    }
}
