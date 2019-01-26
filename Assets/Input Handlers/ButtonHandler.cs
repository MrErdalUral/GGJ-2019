using UnityEngine;

namespace Assets.Input_Handlers
{
    public class ButtonHandler : MonoBehaviour
    {

        public ButtonUnityEvent BoolAction;
        public string InputName;


        // Update is called once per frame
        void Update()
        {
            BoolAction.Invoke(Input.GetButton(InputName));
        }
    }
}