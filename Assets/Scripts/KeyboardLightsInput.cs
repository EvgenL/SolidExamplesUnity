using UnityEngine;

namespace DefaultNamespace
{
    public class KeyboardLightsInput : MonoBehaviour
    {
        private IHasLights _hasLightsController;

        private void Update()
        {
            _hasLightsController?.SetLights(Input.GetKey(KeyCode.Space));
        }

        public void SetControlledObject(IHasLights hasLights)
        {
            _hasLightsController = hasLights;
        }
    }
}