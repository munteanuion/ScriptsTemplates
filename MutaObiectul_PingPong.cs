using UnityEngine;

[DisallowMultipleComponent]
public class MutaObiectul_PingPong : MonoBehaviour
{
    [SerializeField] private Vector3 _directiaDeplasare;
    [SerializeField] private float _vitezaDeplasare = 0.8f;
    private Vector3 _startPosition; 

    void Start()
    {
        _startPosition = transform.position; 
    }
    
    void FixedUpdate()
    {
        transform.position = _startPosition + (_directiaDeplasare * Mathf.PingPong(Time.time * _vitezaDeplasare, 1));
    }
}
