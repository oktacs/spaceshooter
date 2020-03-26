using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour
{
    public float speed;
    public bool isMoving;
    Vector2 min;
    Vector2 max;
    void Awake()
    {
        isMoving = false;
        min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        max.y = max.y + GetComponent<SpriteRenderer>().sprite.bounds.extents.y;
        min.y = min.y - GetComponent<SpriteRenderer>().sprite.bounds.extents.y;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (!isMoving)
            return;
        // dapatkan posisi planet sekarang
        Vector2 position = transform.position;
        // hitung posisi baru planet
        position = new Vector2(position.x, position.y + speed * Time.deltaTime);
        // update posisi planet
        transform.position = position;
        // jika planet ke posisi min y, maka planet berhenti bergerak
        if (transform.position.y < min.y)
        {
            isMoving = false;
        }
    }
    public void ResetPosition()
    {
        // reset posisi planet ke random x dan max y
        transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
    }
}
