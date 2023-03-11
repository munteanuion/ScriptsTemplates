using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Rigidbody2D ballRigidbody;
    public Transform maxPosition;
    public Transform minPosition;
    public float fortaAdaugata;
    public float timpMinimIntreForta = 1f;
    public bool adaugaFortaFix = false; 
    public TextMeshProUGUI scoreComponentDinJoc;
    public TextMeshProUGUI scoreComponentDinGameOver;
    public TextMeshProUGUI highScoreComponentDinJoc;
    public TextMeshProUGUI highScoreComponentDinGameOver;
    [SerializeField] public KeyCode _butonulAdaugaForta;

    private float forceMultiplier = 1f;
    private int score = 0;
    private int highScore = 0;
    private float timeSinceLastForceAdded = 0f; 
    private bool hasFirstShoot = false; 

    private const string HighScoreKey = "HighScore";

    private void Start()
    {
        score = 0;
        highScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        UpdateScoreText();
        ballRigidbody.simulated = false;
    }

    public void AddForceToBall()
    {
        if (timeSinceLastForceAdded >= timpMinimIntreForta) 
        {
            float distanceToMin = Mathf.Abs(ballRigidbody.position.y - minPosition.position.y);
            float distanceToMax = Mathf.Abs(ballRigidbody.position.y - maxPosition.position.y);

            float forcePercent = Mathf.InverseLerp(0f, distanceToMax, distanceToMin);

            float finalForceMagnitude = 0;

            if (adaugaFortaFix)
                finalForceMagnitude = fortaAdaugata;
            else
                finalForceMagnitude = fortaAdaugata * forcePercent * forceMultiplier;

            ballRigidbody.velocity = Vector3.zero;

            ballRigidbody.AddForce(Vector2.up * finalForceMagnitude);

            AddScore();

            timeSinceLastForceAdded = 0f; // resetam timer-ul
        }
    }

    private void Update()
    {
        if (ballRigidbody.position.y > minPosition.position.y && ballRigidbody.position.y < maxPosition.position.y)
        {
            if (Input.GetKeyDown(_butonulAdaugaForta) && hasFirstShoot)
            {
                AddForceToBall();
            }
        }
        if (Input.GetKeyDown(_butonulAdaugaForta) && !hasFirstShoot)
        {
            ballRigidbody.simulated = true;
            hasFirstShoot = true;
        }

        timeSinceLastForceAdded += Time.deltaTime; // actualizam timer-ul
    }

    public void ButtonMobilPentruAdaugareForta()
    {
        if (ballRigidbody.position.y > minPosition.position.y && ballRigidbody.position.y < maxPosition.position.y)
        {
            if (hasFirstShoot)
            {
                AddForceToBall();
            }
        }
        if (!hasFirstShoot)
        {
            ballRigidbody.simulated = true;
            hasFirstShoot = true;
        }
    }

    private void AddScore()
    {
        score++;
        UpdateScoreText();

        if (score > highScore)
        {
            highScore = score;
            UpdateScoreText();
            PlayerPrefs.SetInt(HighScoreKey, highScore);
        }
    }
    private void UpdateScoreText()
    {
        if (scoreComponentDinJoc != null)
        {
            (scoreComponentDinJoc).text = "Score: " + score.ToString();
        }

        if (highScoreComponentDinJoc != null)
        {
            (highScoreComponentDinJoc).text = "High Score: " + highScore.ToString();
        }

        if (scoreComponentDinGameOver != null)
        {
            (scoreComponentDinGameOver).text = "Score: " + score.ToString();
        }

        if (highScoreComponentDinGameOver != null)
        {
            (highScoreComponentDinGameOver).text = "High Score: " + highScore.ToString();
        }
    }
}
