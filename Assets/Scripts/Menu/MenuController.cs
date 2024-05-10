using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Button play;
    [SerializeField] private Button coOp;
    [SerializeField] private Button helpMenu;
    [SerializeField] private Button exit;
    [SerializeField] private Button cancel;
    [SerializeField] private GameObject helpMenuUI;
    private void Awake()
    {
        play.onClick.AddListener(LoadGame);
        coOp.onClick.AddListener(LoadCoOpGame);
        helpMenu.onClick.AddListener(ActivateHelpMenu);
        cancel.onClick.AddListener(DeactiveHelpMenu);
        exit.onClick.AddListener(ExitGame);
    }

    private void DeactiveHelpMenu()
    {
        helpMenuUI.SetActive(false);
    }

    private void ActivateHelpMenu()
    {
        helpMenuUI.SetActive(true);
    }


    private void LoadGame()
     {
        SoundManger.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(1);
     }
    private void LoadCoOpGame()
    {
        SoundManger.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(2);
    }
    private void ExitGame()
    {
        SoundManger.Instance.Play(Sounds.ButtonClick);
        Application.Quit();
    }

    private void OnDestroy()
    {
        play.onClick.RemoveListener(LoadGame);
        coOp.onClick.RemoveListener(LoadCoOpGame);
        exit.onClick.RemoveListener(ExitGame);
    }
}
