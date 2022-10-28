using UnityEngine;

public class CameraUrmaresteObiectul : MonoBehaviour
{
    [SerializeField] private Transform _peCineUrmareste;
    [SerializeField] private Vector3 _pozitiaFataDeUrmaritor;
    [SerializeField] private float _vitezaDeUrmarire = 0.1f;
    
    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(_peCineUrmareste.position.x, _peCineUrmareste.position.y, _peCineUrmareste.position.z) + _pozitiaFataDeUrmaritor, _vitezaDeUrmarire);
    }
}
