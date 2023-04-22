using System;
using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(KeyboardMoveInput))]
    [RequireComponent(typeof(KeyboardLightsInput))]
    public class DrivingController : MonoBehaviour
    {
        private KeyboardMoveInput _keyboardMoveInput;
        private KeyboardLightsInput _keyboardLightInput;
        private PlayerController _player;
        
        private CarController _selectedCar;
        private bool _isDriving = false;

        private void Start()
        {
            _keyboardMoveInput = GetComponent<KeyboardMoveInput>();
            _keyboardLightInput = GetComponent<KeyboardLightsInput>();
            _player = FindObjectOfType<PlayerController>();
            
            _keyboardMoveInput.SetControlledObject(_player);
        }

        public void OnCarApproached(CarController carController)
        {
            _selectedCar = carController;
        }

        public void OnCarLeft()
        {
            _selectedCar = null;
        }

        public void ToggleEnterCar()
        {
            if (_isDriving)
            {
                ExitCar();
            }
            else
            {
                if (_selectedCar == null)
                {
                    return;
                }
                EnterCar();
            }
        }

        private void EnterCar()
        {
            _keyboardMoveInput.SetControlledObject(_selectedCar);
            _keyboardLightInput.SetControlledObject(_selectedCar);
            
            _player.gameObject.SetActive(false);
            _isDriving = true;
        }

        private void ExitCar()
        {
            _keyboardMoveInput.SetControlledObject(_player);
            _keyboardLightInput.SetControlledObject(null);
            
            _player.gameObject.SetActive(true);
            _player.transform.position = _selectedCar.transform.position + _selectedCar.transform.right * 2f;
            _isDriving = false;

        }
    }
}