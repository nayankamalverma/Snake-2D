using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SnakeController controller = collision.GetComponent<SnakeController>();
        SoundManger.Instance.Play(Sounds.Death);
        controller.enabled = false;
        controller.GameOverScreen();
    }
}
