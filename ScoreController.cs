using UnityEngine;

public class ScoreController : MonoBehaviour
{
    enum AxaPeCareCalculeazaScorul
    {
        X,Y,Z
    }

    [SerializeField] private TMPro.TMP_Text _textElementCuScor;
    [SerializeField] private Transform _jucatorul;
    [Header("Scorul va fi distanta de impartit la valoarea de mai jos, se primete ca jucatorul cand parcurge un segment cu lungimea distantei de mai jos primeste + 1 score")]
    [SerializeField] private float _lungimeaSegmentului;
    [SerializeField] private AxaPeCareCalculeazaScorul _axaPeCareCalculeazaScorul;

    private Vector3 startPosition;
    private int score;

    void Start()
    {
        startPosition = _jucatorul.position;
    }

    void Update()
    {
        switch (_axaPeCareCalculeazaScorul)
        {
            case AxaPeCareCalculeazaScorul.X:
                score = (int)((_jucatorul.position.x - startPosition.x) / _lungimeaSegmentului);
                _textElementCuScor.text = "Score: " + score.ToString();
                break;
            case AxaPeCareCalculeazaScorul.Y:
                score = (int)((_jucatorul.position.y - startPosition.y) / _lungimeaSegmentului);
                _textElementCuScor.text = "Score: " + score.ToString();
                break;
            case AxaPeCareCalculeazaScorul.Z:
                score = (int)((_jucatorul.position.z - startPosition.z) / _lungimeaSegmentului);
                _textElementCuScor.text = "Score: " + score.ToString();
                break;
            default:
                break;
        }
    }
}
