using UnityEngine;

public class ControlPersonaj2D : MonoBehaviour
{
    private float horizontal;
    private bool isFacingRight = true;
    private Rigidbody2D _rigidbody;

    [SerializeField] private float _vitezaDeplasare = 8f;
    [SerializeField] private float _putereaSariturii = 16f;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _putereaSariturii);
        }

        if (Input.GetButtonUp("Jump") && _rigidbody.velocity.y > 0f)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.y * 0.5f);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(horizontal * _vitezaDeplasare, _rigidbody.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, 0.1f, _groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}