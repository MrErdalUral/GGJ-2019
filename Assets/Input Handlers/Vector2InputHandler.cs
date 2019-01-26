using UnityEngine;

namespace Assets.Input_Handlers
{
    public class Vector2InputHandler : MonoBehaviour
    {
        public Vector2UnityEvent VectorAction;
        public string HorizontalInput;
        public string VerticalInput;

        void Update()
        {
            VectorAction.Invoke(new Vector2(Input.GetAxis(HorizontalInput), Input.GetAxis(VerticalInput)));
        }
    }
}