using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private Button Play;
    [SerializeField]
    private Button Co_Op;
    [SerializeField]
    private Button Exit;
    private void Awake()
    {
        Play.onClick.AddListener(LoadGame);
        Co_Op.onClick.AddListener(LoadCoOpGame);
        Exit.onClick.AddListener(ExitGame);
    }

    private void LoadGame()
     {
        SoundManger.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(1);
     }
    private void LoadCoOpGame()
    {
        SoundManger.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(1);
    }
    private void ExitGame()
    {
        SoundManger.Instance.Play(Sounds.ButtonClick);
        Application.Quit();
    }

    
    

    

    
}
