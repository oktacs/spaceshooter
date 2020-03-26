using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoad : MonoBehaviour
{
    public GameObject playerShip;
    public GameObject enemySpawner;
    public Text scoreUITextGO;
    public Text TimeCounterGO;
    public Text LivesCounterGO;
    public GameObject pinkPlanetGO;
    public GameObject greenPlanetGO;
    public GameObject bluePlanetGO;
    public void saveData()
    {
        PlayerPrefs.SetFloat("playerX", playerShip.transform.position.x);
        PlayerPrefs.SetFloat("playerY", playerShip.transform.position.y);
        PlayerPrefs.SetFloat("enemyX", enemySpawner.transform.position.x);
        PlayerPrefs.SetFloat("enemyY", enemySpawner.transform.position.y);
        PlayerPrefs.SetFloat("pinkX", pinkPlanetGO.transform.position.x);
        PlayerPrefs.SetFloat("pinkY", pinkPlanetGO.transform.position.y);
        PlayerPrefs.SetFloat("greenX", greenPlanetGO.transform.position.x);
        PlayerPrefs.SetFloat("greenY", greenPlanetGO.transform.position.y);
        PlayerPrefs.SetFloat("blueX", bluePlanetGO.transform.position.x);
        PlayerPrefs.SetFloat("blueY", bluePlanetGO.transform.position.y);
        PlayerPrefs.SetString("scoreText", scoreUITextGO.text);
        PlayerPrefs.SetString("timeText", TimeCounterGO.text);
        PlayerPrefs.SetString("livesText", LivesCounterGO.text);
    }
    public void loadData()
    {
        //playerShip.transform.position = new Vector2(PlayerPrefs.GetFloat("playerX"), ("playerY"));
        //enemySpawner.transform.position = new Vector2(PlayerPrefs.GetFloat("enemySpawnerX"), ("enemySpawnerY"));
        //pinkPlanetGO.transform.position = new Vector2(PlayerPrefs.GetFloat("pinkPlanetX"), ("pinkPlanetY"));
        //greenPlanetGO.transform.position = new Vector2(PlayerPrefs.GetFloat("greenPlanetX"), ("greenPlanetY"));
        //bluePlanetGO.transform.position = new Vector2(PlayerPrefs.GetFloat("bluePlanetX"), ("bluePlanetY"));
        scoreUITextGO.text = PlayerPrefs.GetString("scoreText");
        TimeCounterGO.text = PlayerPrefs.GetString("timeText");
        LivesCounterGO.text = PlayerPrefs.GetString("livesText");
    }
}
