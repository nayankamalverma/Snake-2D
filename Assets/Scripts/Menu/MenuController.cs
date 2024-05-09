using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Button play;
    [SerializeField] private Button coOp;
    [SerializeField] private Button exit;
    private void Awake()
    {
        play.onClick.AddListener(LoadGame);
        coOp.onClick.AddListener(LoadCoOpGame);
        exit.onClick.AddListener(ExitGame);
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

    private void OnDestroy()
    {
        play.onClick.RemoveListener(LoadGame);
        coOp.onClick.RemoveListener(LoadCoOpGame);
        exit.onClick.RemoveListener(ExitGame);
    }
}
