using UnityEngine;

namespace Assets.Scripts.Snake
{
    public class SnakeMovePosition 
    {
        private Vector2Int gridPosition;
        private MoveDirection direction;
        private SnakeMovePosition prevGridPosition;

        public SnakeMovePosition(Vector2Int position, MoveDirection direction, SnakeMovePosition prevGridPosition)
        {
            this.gridPosition = position;
            this.direction = direction;
            this.prevGridPosition = prevGridPosition;
        }

        public Vector2Int GetGridPosition()
        {
            return gridPosition;
        }

        public MoveDirection GetDirection()
        {
            return direction;
        }

        public MoveDirection GetPrevMoveDirection()
        {
            if (prevGridPosition == null)
            {
                return MoveDirection.RIGHT;
            }
            return prevGridPosition.direction;
        }
    }
}