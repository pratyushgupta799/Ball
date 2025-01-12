using UnityEngine;

public class Paddle : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed;

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
        
    }

    private void FixedUpdate()
    {
        //TouchMove();
        KeyboardMove();
    }

    void TouchMove()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (touchPos.x < 0)
            {
                rb.linearVelocity = Vector2.left * moveSpeed;
            }
            if (touchPos.x > 0)
            {
                rb.linearVelocity = Vector2.right * moveSpeed;
            }
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
    void KeyboardMove()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.linearVelocity = Vector2.left * moveSpeed;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.linearVelocity = Vector2.right * moveSpeed;
        }
        else
        {
            rb.linearVelocity = Vector2.zero; // Stop movement when no key is pressed
        }
    }
}
