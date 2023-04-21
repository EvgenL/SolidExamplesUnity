using UnityEngine;

namespace DefaultNamespace
{
    public class KeyboardLightsInput : MonoBehaviour
    {
        private IHasLights _hasLightsController;

        private void Start()
        {
            _hasLightsController = GetComponent<IHasLights>();
        }

        private void Update()
        {
            _hasLightsController.SetLights(Input.GetKey(KeyCode.Space));
        }
    }
}