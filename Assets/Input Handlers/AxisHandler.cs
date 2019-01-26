using System.Collections;
using UnityEngine;

namespace Assets.Input_Handlers
{
    public class AxisHandler : MonoBehaviour
    {
        public AxisInputUnityEvent FloatAction;
        public string AxisName;
        void Update()
        {
            FloatAction.Invoke(Input.GetAxis(AxisName));
        }
    }
}