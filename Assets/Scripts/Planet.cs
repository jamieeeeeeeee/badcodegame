using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{

    [SerializeField] GameObject prefabExplosion;
    [SerializeField] GameObject prefabLostLife;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Decrease lives
            GameObject.Find("Canvas").GetComponent<Canvas>().DecreaseLives(transform.position);


            Instantiate(prefabExplosion, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            Instantiate(prefabExplosion, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Increase player's points
            GameObject.Find("Canvas").GetComponent<Canvas>().IncreaseScore(1);
            //Instantiate(prefabExplosion, gameObject.transform.position, Quaternion.identity);
        }
    }
}
