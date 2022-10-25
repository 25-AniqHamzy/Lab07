using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    private int i, score;

    public Text scoreboard;
    public GameObject[] blocks;

    private float _upwardForceMultiplier = 250f;
    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;

        i = 0;

    }

    void Update()
    {
        blocks = GameObject.FindGameObjectsWithTag("Obstacle");

        if (Input.GetKeyDown(KeyCode.Space) && transform.position.y <= 2.9f && transform.position.y >= -4.5f)
        {
            thisAnimation.Play();

            Rigidbody rigidbody = GetComponent<Rigidbody>();

            rigidbody.velocity = Vector3.zero;

            rigidbody.AddForce(Vector3.up * _upwardForceMultiplier);
        }
        else if (transform.position.y <= -4.5f)
        {
            LoseScene();
        }

        print(i);
        /*
        if (blocks[i].transform.position.x <= transform.position.x)
        {
            score++;

            scoreboard.text = "SCORE : " + score;
            if (i < 3)
            {
                i++;
                print(i);
            }
            else if(i >= 3)
            {
                i = 4;
            }

            
        }
        */
    
    }
    void OnTriggerEnter(Collider collision)
    {
        score++;
        scoreboard.text = "SCORE : " + score;
    }

    void OnCollisionEnter(Collision collision)
    {
        LoseScene();
    }

    void LoseScene()
    {
        SceneManager.LoadScene(1);
    }
}
