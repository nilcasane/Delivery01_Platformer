using UnityEngine;

public class ExitGameManager : MonoBehaviour
{
    void OnExit()
    {
        // Exit the game (works only in builds, not in the editor)
        Application.Quit();

        // If running in the editor, stop play mode (optional for testing)
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
