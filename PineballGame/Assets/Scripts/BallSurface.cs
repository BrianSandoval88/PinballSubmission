using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallSurface : MonoBehaviour
{
    public GameObject floor;
    public float score = 0f;
    float highscore = 0f;
    public TMP_Text displyTxt;

    ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetFloat("highscore", 0);
        scoreManager = GameObject.FindWithTag("UI").GetComponent<ScoreManager>();
        scoreManager.AddPoints(10);

        GetComponent<Rigidbody>().velocity = new Vector3(0.1f, 0, 0.1f);
        if (displyTxt == null)
        {
            displyTxt = GameObject.FindWithTag("ScoreDisplay").GetComponent<TMP_Text>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position.Set(0, floor.transform.position.y + 0.17501f, 0);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        score += collision.gameObject.GetComponent<BounceBackBumper>().value;
        //scoreManager.AddPoints(10);
        displyTxt.text = "Score: " + score;

        if(highscore < score)
        {
            PlayerPrefs.SetFloat("highscore", score);
        }
    }
}
