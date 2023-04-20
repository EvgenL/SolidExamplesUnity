using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    
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
}