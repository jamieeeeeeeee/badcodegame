using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FallingNumber : MonoBehaviour
{
    public Sprite[] sprites;
    [SerializeField] GameObject prefabExplosion;


    private SpriteRenderer spriteRenderer;
    int number;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        number = Random.Range(0, 9);
        spriteRenderer.sprite = sprites[number];

    }

    private void KillFallingNumber() {
        // Decrease lives
        GameObject.Find("Canvas").GetComponent<Canvas>().DecreaseLives(transform.position);
        Instantiate(prefabExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Lose the game
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Handle level 1
            if (gameObject.scene.name == "Scene0")
            {
                KillFallingNumber();
            }
            // Handle level 2
            else
            {
                // Evens
                if (number % 2 == 0)
                {
                    KillFallingNumber();
                }

                // Odds
                else
                {
                    Destroy(gameObject);
                }
            } 
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Add explosion
            Vector3 explosionPosition = gameObject.transform.position;
            float radius = gameObject.GetComponent<CircleCollider2D>().radius;
            explosionPosition.x -= radius / 2;
            Instantiate(prefabExplosion, explosionPosition, Quaternion.identity);


            // Handle level 2
            if (gameObject.scene.name == "Scene1" && !(number % 2 == 0))
            {
                number = - number;
            }

            // Increase player's points
            GameObject.Find("Canvas").GetComponent<Canvas>().IncreaseScore(number);

            // Destroy FallingNumber
            Destroy(gameObject);
            // Destroy bullet
            Destroy(collision.gameObject);

        }
    }
}
