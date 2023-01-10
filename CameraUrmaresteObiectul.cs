using UnityEngine;

public class CameraUrmaresteObiectul : MonoBehaviour
{
    enum AxaDeUrmarire
    {
        X,
        Y,
        Z,
        XY,
        XZ,
        YZ,
        XYZ
    }

    [SerializeField] private Transform _peCineUrmareste;
    [SerializeField] private Vector3 _pozitiaFataDeUrmaritor;
    [SerializeField] private float _vitezaDeUrmarire = 0.1f;
    [SerializeField] private AxaDeUrmarire _axaDeUrmarire;

    private Vector3 _initialPosition;

    private void Start()
    {
        _initialPosition = _peCineUrmareste.transform.position;
    }

    private void Update()
    {
        switch (_axaDeUrmarire)
        {
            case AxaDeUrmarire.X:
                transform.position = Vector3.Lerp(
                    transform.position,
                    new Vector3(_peCineUrmareste.position.x, _initialPosition.y, _initialPosition.z) + _pozitiaFataDeUrmaritor,
                    _vitezaDeUrmarire);
                break;
            case AxaDeUrmarire.Y:
                transform.position = Vector3.Lerp(
                    transform.position,
                    new Vector3(_initialPosition.x, _peCineUrmareste.position.y, _initialPosition.z) + _pozitiaFataDeUrmaritor,
                    _vitezaDeUrmarire);
                break;
            case AxaDeUrmarire.Z:
                transform.position = Vector3.Lerp(
                    transform.position,
                    new Vector3(_initialPosition.x, _initialPosition.y, _peCineUrmareste.position.z) + _pozitiaFataDeUrmaritor,
                    _vitezaDeUrmarire);
                break;
            case AxaDeUrmarire.XY:
                transform.position = Vector3.Lerp(
                    transform.position,
                    new Vector3(_peCineUrmareste.position.x, _peCineUrmareste.position.y, _initialPosition.z) + _pozitiaFataDeUrmaritor,
                    _vitezaDeUrmarire);
                break;
            case AxaDeUrmarire.XZ:
                transform.position = Vector3.Lerp(
                    transform.position,
                    new Vector3(_peCineUrmareste.position.x, _initialPosition.y, _peCineUrmareste.position.z) + _pozitiaFataDeUrmaritor,
                    _vitezaDeUrmarire);
                break;
            case AxaDeUrmarire.YZ:
                transform.position = Vector3.Lerp(
                    transform.position,
                    new Vector3(_initialPosition.x, _peCineUrmareste.position.y, _peCineUrmareste.position.z) + _pozitiaFataDeUrmaritor,
                    _vitezaDeUrmarire);
                break;
            case AxaDeUrmarire.XYZ:
                transform.position = Vector3.Lerp(
                    transform.position,
                    new Vector3(_peCineUrmareste.position.x, _peCineUrmareste.position.y, _peCineUrmareste.position.z) + _pozitiaFataDeUrmaritor,
                    _vitezaDeUrmarire);
                break;
            default:
                break;
        }
    }
}
