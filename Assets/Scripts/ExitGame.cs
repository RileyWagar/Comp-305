using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void QuitGame()
    {
        // Quit the game
        Application.Quit();

        // If running in the Unity Editor, stop the play mode (optional)
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
