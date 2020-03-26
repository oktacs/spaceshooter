using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ToSave : MonoBehaviour
{
    private int currentSceneIndex;
    public void LoadMainMenu()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SavedScene", currentSceneIndex);
        SceneManager.LoadScene(6);
    }
}