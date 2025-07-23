using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMgmt : MonoBehaviour
{
    [SerializeField] Button[] nextLevelButtons;

    private void LateUpdate()
    {
        // Check if all buttons are pressed
        bool allPressed = true;
        foreach (var button in nextLevelButtons)
        {
            if (!button.isPressed)
            {
                allPressed = false;
                break;
            }
        }
        // If all buttons are pressed, load the next scene
        if (allPressed)
        {
            LoadNextScene();
        }
    }

    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public static void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public static void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void LoadNextScene() 
    {
        if (SceneManager.sceneCountInBuildSettings > SceneManager.GetActiveScene().buildIndex + 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            Debug.Log("no more additional scenes - going back to the start");
            SceneManager.LoadScene(0); // Load the first scene if there are no more scenes
        }
    }
}
