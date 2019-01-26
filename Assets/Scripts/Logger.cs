using UnityEngine;
using UnityEngine.UI;

public class Logger : MonoBehaviour
{
    public Text DebugText;

    public void Log(string message)
    {
        print(message);
        if (DebugText)
            DebugText.text = message;
    }

    [NaughtyAttributes.Button]
    public void ClearDebugText()
    {
        if (DebugText)
            DebugText.text = "";
    }
}
