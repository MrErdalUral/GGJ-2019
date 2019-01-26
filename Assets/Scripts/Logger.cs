using UnityEngine;
using UnityEngine.UI;

public class Logger : MonoBehaviour
{
    public Text DebugText;

    public static Logger Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

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
