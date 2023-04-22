using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class CarEntryTrigger : MonoBehaviour
    {
        [SerializeField] private DrivingController _drivingController;
        [SerializeField] private string _playerTag = "Player";
        private CarController _car;

        private void Start()
        {
            _car = GetComponent<CarController>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(_playerTag))
            {
                Debug.Log("Car was approached!");
                _drivingController.OnCarApproached(_car);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(_playerTag))
            {
                Debug.Log("Car was left!");
                _drivingController.OnCarLeft();
            }
        }
    }
}