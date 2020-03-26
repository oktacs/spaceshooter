using UnityEngine;
using System.Collections;

public class EnemyGun : MonoBehaviour
{
    public GameObject EnemyBulletGO;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("FireEnemyBullet", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FireEnemyBullet()
    {
        // mencari ship player
        GameObject playerShip = GameObject.Find("PlayerGO");
        // jika player belum mati
        if (playerShip != null)
        {
            // instansiasi enemy bullet
            GameObject bullet = (GameObject)Instantiate(EnemyBulletGO);
            // set posisi awal bullet
            bullet.transform.position = transform.position;
            // hitung arah bullet ke ship player
            Vector2 direction = playerShip.transform.position - bullet.transform.position;
            // set arah bullet
            bullet.GetComponent<EnemyBullet>().SetDirection(direction);
        }
    }
}
