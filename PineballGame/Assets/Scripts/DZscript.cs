using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DZscript : MonoBehaviour
{
    public GameObject newBall;

    public TMP_Text over;

    int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

 
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<Rigidbody>().CompareTag("Ball"))
        {
            Destroy(collision.gameObject);
            counter++;

            if(counter < 3)
            {
                Instantiate(newBall);
            }
            else
            {
                over = GameObject.FindWithTag("GameOver").GetComponent<TMP_Text>();
                over.text = "Game Over!";
            }
        }
    }
}
