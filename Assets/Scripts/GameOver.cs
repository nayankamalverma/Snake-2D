using UnityEngine;

public class GameOver : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SoundManger.Instance.Play(Sounds.Death);
        GameManager.Instance.GameOver();
    }
}
