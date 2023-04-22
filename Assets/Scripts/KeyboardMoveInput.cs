using System;
using UnityEngine;

public class KeyboardMoveInput : MonoBehaviour
{
    private IMoveController _playerController;

    private void Update()
    {
        var inputs = ProcessInputs();
        
        _playerController.Move(inputs);
    }

    private Vector2 ProcessInputs()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        return new Vector2(moveVertical, moveHorizontal);
    }

    public void SetControlledObject(IMoveController moveController)
    {
        _playerController = moveController;
    }
}