using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public bool isDead = false;
    public float velocity = 1f;
    public GameObject scoreUI;
    public GameObject gameOverUI;
    public GameObject gameOverScoreUI;

    private int score = 0;
    private Text scoreUIText;
    private Text gameOverScoreUIText;
    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        scoreUIText = scoreUI.GetComponent<Text>();
        gameOverScoreUIText = gameOverScoreUI.GetComponent<Text>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (transform.position.y < 4.6 && !isDead)
        {
            rigidBody.velocity = Vector2.up * velocity;
        }
    }

    // Called when the parrot hits an object
    void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
        scoreUI.SetActive(false);
        gameOverUI.SetActive(true);
        Time.timeScale = 0.0f;
    }

    // Called when the parrot passes through an obstacle
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ScoreIncrease")
        {
            score += 1;
            scoreUIText.text = "Score: " + score;
            gameOverScoreUIText.text = "Score: " + score;
        }
    }
}
