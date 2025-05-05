using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler
{
    void Start()
    {
        var levelEndTriggers = Object.FindObjectsByType<LevelEndTrigger>(
            FindObjectsSortMode.None);
        
        foreach (var trigger in levelEndTriggers)
        {
            trigger.OnLevelCompleted += LoadNextScene;
        }
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    
    private void LoadNextScene()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        var nextSceneIndex = currentSceneIndex + 1;
        
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("No more levels to load.");
        }
    }
}
