using UnityEngine;
using System.Collections;
public class GameManager : MonoBehaviour
{
    public GameObject playButton;
    public GameObject menuButton;
    public GameObject saveButton;
    public GameObject playerShip;
    public GameObject enemySpawner;
    public GameObject GameOverGO;
    public GameObject scoreUITextGO;
    public GameObject TimeCounterGO;
    public GameObject GameTitleGO;

    public enum GameManagerState
    {
        Opening,
        Gameplay,
        GameOver
    }
    GameManagerState GMState;
    void Start()
    {
        GMState = GameManagerState.Opening;
    }
    void UpdateGameManagerState()
    {
        switch (GMState)
        {
            case GameManagerState.Opening:
                // hide game over
                GameOverGO.SetActive(false);
                // display judul game
                GameTitleGO.SetActive(true);
                // visible play button
                playButton.SetActive(true);
                // visible menu button
                menuButton.SetActive(true);
                // hide save button
                saveButton.SetActive(false);
                break;
            case GameManagerState.Gameplay:
                // reset skor
                scoreUITextGO.GetComponent<GameScore>().Score = 0;
                // menyembunyikan play button pada state game play
                playButton.SetActive(false);
                // menyembunyikan menu button pada state game play
                menuButton.SetActive(false);
                // tampilkan save button
                saveButton.SetActive(true);
                // hide judul game
                GameTitleGO.SetActive(false);
                // mengubah player menjadi visible dan init nyawa player
                playerShip.GetComponent<PlayerControl>().Init();
                // start enemy spawner
                enemySpawner.GetComponent<EnemySpawner>().ScheduleEnemySpawner();
                // memulai timer
                TimeCounterGO.GetComponent<TimeCounter>().StartTimeCounter();
                break;
            case GameManagerState.GameOver:
                // stop timer
                TimeCounterGO.GetComponent<TimeCounter>().StopTimeCounter();
                // stop enemy spawner
                enemySpawner.GetComponent<EnemySpawner>().UnscheduleEnemySpawner();
                GameOverGO.SetActive(true);
                // hide save button
                saveButton.SetActive(false);
                // ubah state game manager ke state opening setelah 8 detik
                Invoke("ChangeToOpeningState", 8f);
                break;
        }
    }
    // fungsi utk set state game manager
    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();
    }
    public void StartGamePlay()
    {
        GMState = GameManagerState.Gameplay;
        UpdateGameManagerState();
    }
    // fungsi untuk mengubah state game manager ke state opening
    public void ChangeToOpeningState()
    {
        SetGameManagerState(GameManagerState.Opening);
    }
}