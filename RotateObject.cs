using UnityEngine;

[DisallowMultipleComponent]
public class RotateObject : MonoBehaviour
{
    private enum AxisRotate { X, Y, Z};

    [SerializeField] private int _rotationSpeed = 100;
    [SerializeField] private bool _rotationClockWise = true;
    [SerializeField] private AxisRotate _axisRotate;

    private int _rotationAngles = 0;

    void FixedUpdate()
    {
        if (_rotationClockWise)
            _rotationAngles += _rotationSpeed;
        else
            _rotationAngles -= _rotationSpeed;

        switch (_axisRotate)
        {
            case AxisRotate.X:
                transform.eulerAngles = new Vector3( _rotationAngles * Time.deltaTime, 0, 0);
                break;
            case AxisRotate.Y:
                transform.eulerAngles = new Vector3(0, _rotationAngles * Time.deltaTime, 0);
                break;
            case AxisRotate.Z:
                transform.eulerAngles = new Vector3(0, 0, _rotationAngles * Time.deltaTime);
                break;
            default:
                break;
        }
    }
}
