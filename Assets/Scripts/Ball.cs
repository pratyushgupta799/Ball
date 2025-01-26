using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField]private float speedIncreaseRate;
    [SerializeField]private float maxSpeed;
    [SerializeField]private float bounceForce;
    private bool _gameStarted = false;
    public GameObject paddle;
    private Vector3 _paddleCenter;

    private void Awake()
    { 
        _rb = GetComponent<Rigidbody2D>();
    }
    
    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.anyKeyDown && !_gameStarted)
        {
            GameManager.Instance.GameStart();
            StartBounce();
        }

        if (_gameStarted)
        {
            float newSpeed = speedIncreaseRate * Time.time + 8f;
            float finalSpeed = Mathf.Min(newSpeed, maxSpeed);

            _rb.linearVelocity = _rb.linearVelocity.normalized * finalSpeed;
        }
    }

    void StartBounce()
    {
        Vector2 RandomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;

        _rb.AddForce(RandomDirection * bounceForce, ForceMode2D.Impulse);

        _gameStarted = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("FallCheck"))
        {
            GameManager.Instance.Restart();
        }

        else if(collision.gameObject.CompareTag("Paddle"))
        {
            _paddleCenter = paddle.GetComponent<Collider2D>().bounds.center;
            Vector2 impactPoint = transform.position;
            float impactFactor = (impactPoint.x - _paddleCenter.x);
            
            _rb.AddForce(new Vector2(impactFactor * 10f, 0), ForceMode2D.Impulse);
            GameManager.Instance.ScoreUp();
        }
    }
}
