using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void SwitchScene(string sceneName)
    {
        // Load the scene with the given name
        SceneManager.LoadScene(sceneName);
    }
}
