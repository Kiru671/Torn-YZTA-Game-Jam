using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager: MonoBehaviour {
    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseGame() {
        Time.timeScale =0;
    }

    public void UnpauseGame() {
        Time.timeScale =1;
    }
}