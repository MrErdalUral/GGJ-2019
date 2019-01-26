using UnityEngine;

namespace Assets.Input_Handlers
{
    public class Vector2RawInputHandler : MonoBehaviour
    {
        public Vector2UnityEvent VectorAction;

        public string HorizontalInput;
        public string VerticalInput;
        void Update()
        {
            VectorAction.Invoke(new Vector2(Input.GetAxisRaw(HorizontalInput), Input.GetAxisRaw(VerticalInput)).normalized);
        }
    }
}