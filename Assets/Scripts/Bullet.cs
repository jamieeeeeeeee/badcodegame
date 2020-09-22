using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls the bullets shot from the spaceship
public class Bullet : MonoBehaviour
{

    Timer timer;
    const float bulletLifespan = 20;

    // Start is called before the first frame update
    void Start()
    {
        // create and run timer
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = bulletLifespan;
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        //if (timer.Finished)
        //{
        //    Destroy(gameObject);
        //}
    }


    /// <summary>
    /// Allow spaceship to determine direction of bullets
    /// </summary>
    /// <param name="vector"></param>
    public void ApplyForce(Vector2 vector)
    {
        float forceMagnitude = 10;
        // Need to fetch instance of object since this method is public
        GetComponent<Rigidbody2D>().AddForce(vector * forceMagnitude, ForceMode2D.Impulse);

    }
}
