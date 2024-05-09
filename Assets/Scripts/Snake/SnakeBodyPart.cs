using UnityEngine;

namespace Assets.Scripts.Snake
{
    public class SnakeBodyPart : MonoBehaviour
    {
        private SnakeMovePosition snakeBodyPostion;
        private Transform transform;

        public SnakeBodyPart(int bodyIndex)
        {
            GameObject snakeBody = Instantiate(GameAssets.Instance.SnakeBodyPrefab);
            snakeBody.GetComponent<SpriteRenderer>().sortingOrder = -bodyIndex;
            transform = snakeBody.transform;
        }

        public SnakeBodyPart(int bodyIndex,string objectTag)
        {
            GameObject snakeBody;
            if(objectTag == "BlueSnake")
            {
                snakeBody = Instantiate(GameAssets.Instance.BlueSnakeBodyPerfab);
            }else
            {
                snakeBody = Instantiate(GameAssets.Instance.RedSnakeBodyPerfab);
            }
            snakeBody.GetComponent<SpriteRenderer>().sortingOrder = -bodyIndex;
            transform = snakeBody.transform;
        }

        public void SetSnakeMovePosition(SnakeMovePosition snakeMovePosition)
        {
            snakeBodyPostion = snakeMovePosition;

            float angle;
            switch (snakeMovePosition.GetDirection())
            {
                default:
                case MoveDirection.UP: //from up
                    switch (snakeMovePosition.GetPrevMoveDirection())
                    {
                        default:
                            angle = 0; break;
                        case MoveDirection.LEFT: //to left
                            angle = 0 + 45; break;
                        case MoveDirection.RIGHT: //to right
                            angle = 0 - 45; break;
                    }
                    break;
                case MoveDirection.DOWN: //from down
                    switch (snakeMovePosition.GetPrevMoveDirection())
                    {
                        default:
                            angle = 180; break;
                        case MoveDirection.LEFT: //to left
                            angle = 180 - 45; break;
                        case MoveDirection.RIGHT: //to right
                            angle = 180 + 45; break;
                    }
                    break;
                case MoveDirection.LEFT: // Left
                    switch (snakeMovePosition.GetPrevMoveDirection())
                    {
                        default:
                            angle = -90; break;
                        case MoveDirection.DOWN: //from down
                            angle = -45; break;
                        case MoveDirection.UP: //from up
                            angle = 45; break;
                    }
                    break;
                case MoveDirection.RIGHT: // Right
                    switch (snakeMovePosition.GetPrevMoveDirection())
                    {
                        default:
                            angle = 90; break;
                        case MoveDirection.DOWN: //from down
                            angle = 45; break;
                        case MoveDirection.UP: //from up
                            angle = -45; break;
                    }
                    break;
            }

            transform.position = new Vector3(snakeMovePosition.GetGridPosition().x, snakeMovePosition.GetGridPosition().y);
            transform.eulerAngles = new Vector3(0, 0, angle);
        }
    }
}