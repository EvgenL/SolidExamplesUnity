using UnityEngine;

namespace DefaultNamespace
{
    public class TouchInput : MonoBehaviour
    {
        [SerializeField] private PlayerController _playerController;
    
        private void Update()
        {
            var inputs = ProcessInputs();
        
            _playerController.Move(inputs);
        }

        private Vector2 ProcessInputs()
        {
            if (Input.GetMouseButton(0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hit))
                {
                    var direction = hit.point - _playerController.transform.position;
                    direction.Normalize();
                    return new Vector2(direction.z, direction.x);
                }
            }
            return Vector2.zero;
        }
    }
}