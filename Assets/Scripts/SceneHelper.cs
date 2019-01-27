using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHelper : MonoBehaviour
{
    public void Load(Scene scene)
    {
        SceneManager.LoadScene(scene.name);
        SceneManager.SetActiveScene(scene);
    }

    public void Load(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public static void LoadStatic(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public void Restart()
    {
        SceneManager.SetActiveScene(SceneManager.GetActiveScene());
    }
}
