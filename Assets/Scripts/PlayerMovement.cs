using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask _environmentLayerMask;
    [SerializeField] private LayerMask _interactableLayerMask;
    private PlayerEffects _playerEffects;
    private void Awake()
    {
        _playerEffects = GetComponent<PlayerEffects>();
    }
    public void Move(Vector2Int direction)
    {
        if (GameManager.Instance.GetGameState() == GameState.Playing)
        {
            int count = MoveOnceRecursive(direction, 0);
            if (count > 0)
            {
                _playerEffects.HitWall(direction);
                GameManager.Instance.TurnTaken();
            }
        }
    }
    private int MoveOnceRecursive(Vector2Int direction, int moveCount)
    {
        //BAIL
        if (moveCount > 1000)
        {
            Debug.LogError("Too Many Moves!?");
            return moveCount;
        }
        
        //assumes grid size of '1'.
        Vector3 nextPosition = transform.position + new Vector3(direction.x, direction.y, 0);

        if (IsNoWallHere(nextPosition))
        {
            //spawn dust trail
            _playerEffects.DustTrail(transform.position);
            transform.position = nextPosition;
            CheckForInteractable(transform.position);
            return MoveOnceRecursive(direction,moveCount+1);//Recursive Function
        }
        else
        {
            return moveCount;
        }
    }
    private void CheckForInteractable(Vector3 worldPoint)
    {
        Collider2D overlap = Physics2D.OverlapPoint(worldPoint, _interactableLayerMask);
        if (overlap != null)
        {
            //Interact With The object?
            Interactable interactable = overlap.GetComponent<Interactable>();
            if (interactable != null)
            {
                interactable.Interact();
            }
            else
            {
                Debug.LogError("Forgot to put interactable component on an interactable layer item");
            }
        }
    }
    private bool IsNoWallHere(Vector3 worldPoint)
    {
        Collider2D wall = Physics2D.OverlapPoint(worldPoint, _environmentLayerMask);
        if (wall == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
