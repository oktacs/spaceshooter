using UnityEngine;
using UnityEngine.SceneManagement;
public class ToContinue : MonoBehaviour
{
    private int sceneToContinue;
    public void ContinueGame()
    {
        sceneToContinue = PlayerPrefs.GetInt("SavedScene");
        if (sceneToContinue != 0)
        {
            SceneManager.LoadScene(sceneToContinue);
        }
        else
        {
            return;
        }
    }
}