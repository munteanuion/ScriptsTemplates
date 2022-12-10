using UnityEngine;

public class MutaIntroDirectie2D : MonoBehaviour
{
    enum Direction{ Dreapta, Stanga, Sus, Jos}

    [SerializeField] private float _viteza = 1;
    [SerializeField] private Direction _directia = Direction.Dreapta;

    private void FixedUpdate()
    {
        switch (_directia)
        {
            case Direction.Dreapta:
                transform.position = new Vector2(transform.position.x + _viteza * Time.deltaTime, transform.position.y);
                break;
            case Direction.Stanga:
                transform.position = new Vector2(transform.position.x - _viteza * Time.deltaTime, transform.position.y);
                break;
            case Direction.Sus:
                transform.position = new Vector2(transform.position.x, transform.position.y + _viteza * Time.deltaTime);
                break;
            case Direction.Jos:
                transform.position = new Vector2(transform.position.x, transform.position.y - _viteza * Time.deltaTime);
                break;
            default:
                break;
        }
    }
}
