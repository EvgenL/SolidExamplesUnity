using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class KeyboardCarEnterInput : MonoBehaviour
    {
        [SerializeField] private DrivingController _drivingController;
        
        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.F))
            {
                _drivingController.ToggleEnterCar();
            }
            
        }
    }
}