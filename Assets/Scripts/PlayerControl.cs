using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class PlayerControl : MonoBehaviour
{
    public GameObject PlayerBulletGO;
    public GameObject GameManagerGO;
    public GameObject bulletPosition01;
    public GameObject bulletPosition02;
    public GameObject ExplosionGO;
    public float speed;
    public Text LivesUIText;
    const int MaxLives = 3;
    int lives;
    public void Init()
    {
        lives = MaxLives;
        LivesUIText.text = lives.ToString();
        // reset posisi player ke tengah layar
        transform.position = new Vector2(0, 0);
        gameObject.SetActive(true);
    }
    void Start()
    {

    }
    void Update()
    {
        // menembakkan bullet jika tombol space ditekan
        if (Input.GetKeyDown("space"))
        {
            // mainkan sound effect laser
            GetComponent<AudioSource>().Play();
            GameObject bullet01 = (GameObject)Instantiate(PlayerBulletGO);
            bullet01.transform.position = bulletPosition01.transform.position;

            GameObject bullet02 = (GameObject)Instantiate(PlayerBulletGO);
            bullet02.transform.position = bulletPosition02.transform.position;
        }
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        // normalisasi vektor
        Vector2 direction = new Vector2(x, y).normalized;
        // panggil fungsi untuk menghitung posisi player
        Move(direction);
    }
    void Move(Vector2 direction)
    {
        // mencari batas layar dari pergerakan player
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        max.x = max.x - 0.225f;
        min.x = min.x + 0.225f;
        max.y = max.y - 0.285f;
        min.y = min.y + 0.285f;

        // mendapatkan posisi player sekarang
        Vector2 pos = transform.position;

        // menghitung posisi baru
        pos += direction * speed * Time.deltaTime;

        // posisi tidak boleh di luar layar
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        // update posisi player
        transform.position = pos;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        // mendeteksi tabrakan player ship dengan enemy ship atau enemy bullet
        if ((col.tag == "EnemyShipTag") || (col.tag == "EnemyBulletTag"))
        {
            PlayExplosion();
            lives--; // mengurangi nyawa
            LivesUIText.text = lives.ToString(); // update nyawa di UI Text
            if (lives == 0) // jika player belum mati
            {
                // ganti state game manager ke game over state
                GameManagerGO.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameOver);
                // sembunyikan player ship
                gameObject.SetActive(false);
            }
        }
    }
    void PlayExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionGO);
        // set posisi ledakan
        explosion.transform.position = transform.position;
    }

}