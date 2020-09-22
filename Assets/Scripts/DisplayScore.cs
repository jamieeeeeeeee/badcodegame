using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayScore : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Text highScoreText;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        highScoreText.text = "Score: " + Canvas.GetScore().ToString();
    }
}
