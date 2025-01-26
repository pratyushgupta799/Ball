using UnityEngine;

public class Paddle : MonoBehaviour
{
    private Rigidbody2D _rb; 
    [SerializeField] private float moveSpeed;
    [SerializeField] private float mouseMoveSpeed = 500f;
    private Transform _paddleTransform;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _paddleTransform = GetComponent<Transform>();
    }

    void Update()
    {
        if (Input.GetAxis("Mouse X") > 0 && _paddleTransform.position.x < 7.2f)
        {
            _paddleTransform.Translate(Input.GetAxis("Mouse X") * mouseMoveSpeed, 0, 0);
        }

        if (Input.GetAxis("Mouse X") < 0 && _paddleTransform.position.x > -7.2f)
        {
            _paddleTransform.Translate(Input.GetAxis("Mouse X") * mouseMoveSpeed, 0, 0);
        }
    }

    private void FixedUpdate()
    {
        KeyboardMove();
    }

    void TouchMove()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (touchPos.x < 0)
            {
                _rb.linearVelocity = Vector2.left * moveSpeed;
            }
            if (touchPos.x > 0)
            {
                _rb.linearVelocity = Vector2.right * moveSpeed;
            }
        }
        else
        {
            _rb.linearVelocity = Vector2.zero;
        }
    }
    void KeyboardMove()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _rb.linearVelocity = Vector2.left * moveSpeed;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            _rb.linearVelocity = Vector2.right * moveSpeed;
        }
        else
        {
            _rb.linearVelocity = Vector2.zero; // Stop movement when no key is pressed
        }
    }
}
