using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenuController : MonoBehaviour
{
    [SerializeField]
    private Button restart;
    [SerializeField]
    private Button exit;

    private void Awake()
    {
        restart.onClick.AddListener(Reload);
        exit.onClick.AddListener(GoLobby);
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


    private void OnDestroy()
    {
        restart.onClick.RemoveListener(Reload);
        exit.onClick.RemoveListener(GoLobby);
    }
}
