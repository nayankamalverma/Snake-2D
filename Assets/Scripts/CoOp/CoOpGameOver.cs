using System.Collections;
using UnityEngine;

namespace Assets.Scripts.CoOp
{
    public class CoOpGameOver : MonoBehaviour
    {

        private void OnTriggerEnter2D(Collider2D collision)
        {
            string objectTag = collision.gameObject.tag;
            if(objectTag == "BlueSnake" ||  objectTag == "RedSnake")
            {
                SoundManger.Instance.Play(Sounds.Death);
                CoOpGameManager.Instance.GameOver(objectTag);
            }
        }
    }
}