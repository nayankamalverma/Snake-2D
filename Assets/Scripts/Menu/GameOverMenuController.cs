using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenuController : MonoBehaviour
{
    [SerializeField]
    private Button Restart;
    [SerializeField]
    private Button Exit;

    private void Awake()
    {
        Restart.onClick.AddListener(Reload);
        Exit.onClick.AddListener(GoLobby);
    }

    private void Reload()
    {
        SoundManger.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void GoLobby()
    {
        SoundManger.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(0);
    }
}
