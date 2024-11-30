using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void SwitchScene(string sceneName)
    {
        // Load the scene with the given name
        SceneManager.LoadScene(sceneName);
        if(sceneName == "Jen's Level")
        {
            PlayerStats.checkpoint = new Vector3(77.04f, -12.54f, 0);
        }
        else if(sceneName == "Riley's Level Part A")
        {
            PlayerStats.checkpoint = new Vector3(-9.3f, -5.6f, 0);
        }
    }
}
