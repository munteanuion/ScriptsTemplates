using UnityEngine;

public class UrmaresteObiectPeAxe : MonoBehaviour
{
    enum Direction { X, Y, Z}

    [SerializeField] private Transform _peCineUrmareste;
    [SerializeField] private Vector3 _pozitiaFataDeUrmaritor;
    [SerializeField] private float _vitezaDeUrmarire = 0.1f;
    [SerializeField] private Direction _axaDeUrmarire;

    private Vector3 _vector3 = new Vector3(0,0,0);

    private void Start()
    {
        _vector3.x = _peCineUrmareste.position.x + _pozitiaFataDeUrmaritor.x;
        _vector3.y = _peCineUrmareste.position.y + _pozitiaFataDeUrmaritor.y;
        _vector3.z = _peCineUrmareste.position.z + _pozitiaFataDeUrmaritor.z;
    }

    private void Update()
    {
        switch (_axaDeUrmarire)
        {
            case Direction.X:
                _vector3.x = _peCineUrmareste.position.x + _pozitiaFataDeUrmaritor.x;
                break;
            case Direction.Y:
                _vector3.y = _peCineUrmareste.position.y + _pozitiaFataDeUrmaritor.y;
                break;
            case Direction.Z:
                _vector3.z = _peCineUrmareste.position.z + _pozitiaFataDeUrmaritor.z;
                break;
            default:
                break;
        }
        
        transform.position = Vector3.Lerp(
            transform.position,
            _vector3,
            _vitezaDeUrmarire);
    }
}
