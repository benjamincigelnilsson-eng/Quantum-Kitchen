using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    
    public string sceneToLoad;

 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            LoadScene();
        }
    }

    
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
