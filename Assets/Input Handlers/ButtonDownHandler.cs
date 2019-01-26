using UnityEngine;

namespace Assets.Input_Handlers
{
    public class ButtonDownHandler : MonoBehaviour
    {

        public ButtonUnityEvent ButtonAction;
        public string InputName;

        // Update is called once per frame
        void Update()
        {
            ButtonAction.Invoke(Input.GetButtonDown(InputName));
        }
    }
}