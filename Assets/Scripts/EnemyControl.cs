using UnityEngine;
using System.Collections;
public class EnemyControl : MonoBehaviour
{
    float speed;
    public GameObject ExplosionGO;
    public GameObject scoreUITextGO;
    void Start()
    {
        speed = 2f;
        // get skor teks UI start
        scoreUITextGO = GameObject.FindGameObjectWithTag("ScoreTextTag");
    }
    void Update()
    {
        // mendapatkan posisi enemy sekarang
        Vector2 position = transform.position;
        // menghitung posisi enemy sekarang
        position = new Vector2(position.x, position.y - speed * Time.deltaTime);
        // update posisi enemy
        transform.position = position;
        // poin kiri bawah layar
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        // jika enemy keluar layar di bawah, maka hancurkan enemy
        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        // mendeteksi tabrakan enemy ship dengan player ship atau player bullet
        if ((col.tag == "PlayerShipTag") || (col.tag == "PlayerBulletTag"))
        {
            PlayExplosion();
            // tambah 100 poin pada skor
            scoreUITextGO.GetComponent<GameScore>().Score += 100;
            Destroy(gameObject);
        }
    }
    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionGO);
        // set posisi ledakan
        explosion.transform.position = transform.position;
    }
}