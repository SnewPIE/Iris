using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    private float lifeTime = 5f;
    private float spawnTime;
    SpriteRenderer rb;

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Time.time;
        rb = GetComponent<SpriteRenderer>();
        rb.flipX = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.localScale.x >= 0)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        }
        if (Time.time - spawnTime > lifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            
            Destroy(gameObject);
        }
    }
}
