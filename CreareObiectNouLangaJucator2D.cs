using UnityEngine;

public class CreareObiectNouLangaJucator2D : MonoBehaviour
{
    enum DirectiaCreareObiect2D
    {
        Sus,
        Jos,
        Dreapta,
        Stanga
    }

    [SerializeField] private Transform _personajul;
    [SerializeField] private DirectiaCreareObiect2D _diretiaCreareObiect;
    [SerializeField] private GameObject[] _obstaculePrefaburi;
    [SerializeField] private float _distantaDintreObiecteleCreate;
    [Header("Instructiunea in descriere.")]
    [Tooltip("Valoarea inaltimei unde este situata linia pe care vor fi create obiectele pentru directia Dreapta, Stanga. Iar pentru Sus, Jos va fi latimea.")]
    [SerializeField] private float _valoareaAxei;
    
    private float _monitoringObjectPosition = 0;
    private float _playerPositionStartX = 0;
    private float _playerPositionStartY = 0;

    private void Start()
    {
        InstantiateObject();
        _playerPositionStartX = _personajul.position.x;
        _playerPositionStartY = _personajul.position.y;
    }

    private void Update()
    {
        switch (_diretiaCreareObiect)
        {
            case DirectiaCreareObiect2D.Sus:
                if (_monitoringObjectPosition <= _personajul.position.y)
                    InstantiateObject();
                break;
            case DirectiaCreareObiect2D.Jos:
                if (_monitoringObjectPosition <= System.Math.Abs(_personajul.position.y))
                    InstantiateObject();
                break;
            case DirectiaCreareObiect2D.Dreapta:
                if (_monitoringObjectPosition <= _personajul.position.x)
                    InstantiateObject();
                break;
            case DirectiaCreareObiect2D.Stanga:
                if (_monitoringObjectPosition <= System.Math.Abs(_personajul.position.x))
                    InstantiateObject();
                break;
            default:
                break;
        }
    }

    private void InstantiateObject()
    {
        Instantiate1Object(
            _obstaculePrefaburi[Random.Range(0, _obstaculePrefaburi.Length)]
            );
    }

    private void Instantiate1Object(GameObject objectTaked)
    {
        Instantiate(
            objectTaked,
            AmountVector3(objectTaked),
            Quaternion.identity);

        _monitoringObjectPosition += _distantaDintreObiecteleCreate;
    }

    private Vector3 AmountVector3(GameObject objectTaked)
    {
        Vector3 tmpVector3 = tmpVector3 = new Vector3(0,0,0);

        switch (_diretiaCreareObiect)
        {
            case DirectiaCreareObiect2D.Sus:
                tmpVector3 = new Vector3(
                    _valoareaAxei,
                    _personajul.position.y + _distantaDintreObiecteleCreate,
                    _personajul.position.z);
                break;
            case DirectiaCreareObiect2D.Jos:
                tmpVector3 = new Vector3(
                    _valoareaAxei,
                    _personajul.position.y - _distantaDintreObiecteleCreate,
                    _personajul.position.z);
                break;
            case DirectiaCreareObiect2D.Dreapta:
                tmpVector3 = new Vector3(
                    _personajul.position.x + _distantaDintreObiecteleCreate,
                    _valoareaAxei,
                    _personajul.position.z);
                break;
            case DirectiaCreareObiect2D.Stanga:
                tmpVector3 = new Vector3(
                    _personajul.position.x - _distantaDintreObiecteleCreate,
                    _valoareaAxei,
                    _personajul.position.z);
                break;
            default:
                break;
        }
        return tmpVector3;
    }
}
