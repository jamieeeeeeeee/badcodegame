using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float Speed = 0.2f;
    public float MaxSpeed = 0.5f;

    public bool grounded;

    private Rigidbody2D rb;

    [SerializeField] GameObject prefabExplosion;
    [SerializeField] GameObject prefabBullet;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.drag = 50;
    }

    // Update is called once per frame
    void Update()
    {
        // Check on the left side of the screen
        if (transform.position.x <= -8f)
        {
            transform.position = new Vector3(-8f, transform.position.y, 0f);
        }
        // Check on the right side of the screen
        if (transform.position.x >= 8f)
        {
            transform.position = new Vector3(8f, transform.position.y, 0f);
        }

        // Fire a bullet
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 bulletPosition = transform.position;
            // Place the bullet above the player
            bulletPosition.y += GetComponent<CircleCollider2D>().radius;
            GameObject bullet = Instantiate(prefabBullet, bulletPosition, Quaternion.identity);
            Bullet script = bullet.GetComponent<Bullet>();

            // Send it up
            script.ApplyForce(new Vector3(0, 1, 0));
        }
    }

    /// <summary>
    /// Move the character left and right
    /// </summary>
    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        Rigidbody2D rb2d = gameObject.GetComponent<Rigidbody2D>();
        rb2d.AddForce((Vector2.right * Speed) * h, ForceMode2D.Impulse);
        if (rb2d.velocity.x > MaxSpeed)
        {
            rb2d.velocity = new Vector2(MaxSpeed, rb.velocity.y);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FallingNumber"))
        {
            // Decrease lives
            GameObject.Find("Canvas").GetComponent<Canvas>().DecreaseLives(transform.position);


            Instantiate(prefabExplosion, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }
}
