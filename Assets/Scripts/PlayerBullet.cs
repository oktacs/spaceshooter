using UnityEngine;
using System.Collections;
public class PlayerBullet : MonoBehaviour
{
    float speed;
    void Start()
    {
        speed = 8f;
    }
    void Update()
    {
        // mendapatkan posisi bullet sekarang
        Vector2 position = transform.position;

        // menghitung posisi baru bullet
        position = new Vector2(position.x, position.y + speed * Time.deltaTime);

        // update posisi bullet
        transform.position = position;

        // poin kanan atas layar
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        // jika bullet keluar dari layar atas, maka hancurkan bullet
        if (transform.position.y > max.y)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        // mendeteksi tabrakan player bullet dengan enemy ship
        if (col.tag == "EnemyShipTag")
        {
            Destroy(gameObject);
        }
    }
}