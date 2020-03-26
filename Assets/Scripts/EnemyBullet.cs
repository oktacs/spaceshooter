using UnityEngine;
using System.Collections;
public class EnemyBullet : MonoBehaviour
{
    float speed;
    Vector2 _direction;
    bool isReady;
    void Awake()
    {
        speed = 5f;
        isReady = false;
    }
    void Start()
    {
    }
    public void SetDirection(Vector2 direction)
    {
        // set direction normalized, untuk mendapatkan vektor unit
        _direction = direction.normalized;
        // set flag true
        isReady = true;
    }
    void Update()
    {
        if (isReady)
        {
            // mendapatkan posisi bullet sekarang
            Vector2 position = transform.position;
            // menghitung posisi baru bullet
            position += _direction * speed * Time.deltaTime;
            // update posisi bullet
            transform.position = position;
            // jika bullet keluar layar
            // poin kiri bawah layar
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            // poin kanan atas layar
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
            // jika bullet keluar layar, hancurkan bullet
            if ((transform.position.x < min.x) || (transform.position.x > max.x) || (transform.position.y < min.y) || (transform.position.y > max.y))
            {
                Destroy(gameObject);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        // mendeteksi tabrakan enemy bullet dengan player ship
        if (col.tag == "PlayerShipTag")
        {
            Destroy(gameObject);
        }
    }
}