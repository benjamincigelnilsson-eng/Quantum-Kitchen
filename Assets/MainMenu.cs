using UnityEngine;
using UnityEngine.SceneManagement; // Required for SceneManager

public class SceneButton : MonoBehaviour
{
    // Name of the scene to load — set this in the Inspector
    public string sceneToLoad;

    // This function will be called by the Button’s OnClick() event
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
