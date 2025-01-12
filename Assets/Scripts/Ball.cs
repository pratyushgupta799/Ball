using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;
    public float bounceForce;
    bool GameStarted = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && !GameStarted)
        {
            GameManager.instance.GameStart();
            StartBounce();
        }

    }

    void StartBounce()
    {
        Vector2 RandomDirection = new Vector2(0.5f, 1);

        rb.AddForce(RandomDirection * bounceForce, ForceMode2D.Impulse);

        GameStarted = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "FallCheck")
        {
            GameManager.instance.Restart();
        }

        else if(collision.gameObject.tag == "Paddle")
        {
            GameManager.instance.ScoreUp();
        }
    }
}
