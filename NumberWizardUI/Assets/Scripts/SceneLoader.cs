using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        // get active scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // load nex scene
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        // quit game when it's built
        Application.Quit();
    }
}
