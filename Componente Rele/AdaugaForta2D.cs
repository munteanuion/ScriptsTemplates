using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AdaugaForta2D : MonoBehaviour
{
    enum Direction { Dreapta, Stanga, Sus, Jos }

    [SerializeField] private float _limitaVelocity = 17;
    [SerializeField] private float _forta = 1;
    [SerializeField] private Direction _directia = Direction.Sus;
    [SerializeField] private KeyCode _butonulAdaugaForta; 

    private Rigidbody2D _rigidbody;

    public KeyCode GetButtonAddForce()
    {
        return _butonulAdaugaForta;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //if (Input.GetKeyDown(_butonulAdaugaForta))
        //{
          //  AdaugaForta();
        //}
    }

    public void AdaugaForta()
    {
        if (_rigidbody.velocity.y < 0)
        {
            //_rigidbody.velocity *= 0;
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
        }

        if (_rigidbody.velocity.y > _limitaVelocity)
            return;

        switch (_directia)
        {
            case Direction.Dreapta:
                _rigidbody.AddForce(Vector2.right * _forta);
                break;
            case Direction.Stanga:
                _rigidbody.AddForce(Vector2.left * _forta);
                break;
            case Direction.Sus:
                _rigidbody.AddForce(Vector2.up * _forta);
                break;
            case Direction.Jos:
                _rigidbody.AddForce(Vector2.down * _forta);
                break;
            default:
                break;
        }

        if (_rigidbody.velocity.y > _limitaVelocity)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _limitaVelocity);
        }
    }
}
