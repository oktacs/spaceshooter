using UnityEngine;
using System.Collections;
public class Star : MonoBehaviour
{
    public float speed;
    void Start()
    {
    }
    void Update()
    {
        // mendapatkan posisi bintang sekarang
        Vector2 position = transform.position;
        // menghitung posisi baru bintang
        position = new Vector2(position.x, position.y + speed * Time.deltaTime);
        // update posisi bintang
        transform.position = position;
        // poin kiri bawah layar
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        // poin kanan atas layar
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        // jika bintang keluar layar pada bagian bawah
        // pindah posisi bintang pada atas layar
        // secara acak antara kiri dan kanan layar
        if (transform.position.y < min.y)
        {
            transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
        }
    }
}