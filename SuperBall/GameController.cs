using UnityEngine;

public class GameController : MonoBehaviour
{
    public Rigidbody2D ballRigidbody;
    public Transform maxPosition;
    public Transform minPosition;
    public float fortaAdaugata;
    public float timpMinimIntreForta = 1f; // noua variabila
    public Component scoreComponent;
    public Component highScoreComponent;

    private float forceMultiplier = 1f;
    private int score = 0;
    private int highScore = 0;
    private float timeSinceLastForceAdded = 0f; // noua variabila

    private const string HighScoreKey = "HighScore";

    private void Start()
    {
        score = 0;
        highScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        UpdateScoreText();
    }

    public void AddForceToBall()
    {
        if (timeSinceLastForceAdded >= timpMinimIntreForta) // noua verificare
        {
            float distanceToMin = Mathf.Abs(ballRigidbody.position.y - minPosition.position.y);
            float distanceToMax = Mathf.Abs(ballRigidbody.position.y - maxPosition.position.y);

            float forcePercent = Mathf.InverseLerp(0f, distanceToMax, distanceToMin);

            float finalForceMagnitude = fortaAdaugata * forcePercent * forceMultiplier;

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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                AddForceToBall();
            }
        }

        timeSinceLastForceAdded += Time.deltaTime; // actualizam timer-ul
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
        if (scoreComponent != null)
        {
            if (scoreComponent is UnityEngine.UI.Text)
            {
                ((UnityEngine.UI.Text)scoreComponent).text = "Score: " + score.ToString();
            }
            else if (scoreComponent is TMPro.TMP_Text)
            {
                ((TMPro.TMP_Text)scoreComponent).text = "Score: " + score.ToString();
            }
        }

        if (highScoreComponent != null)
        {
            if (highScoreComponent is UnityEngine.UI.Text)
            {
                ((UnityEngine.UI.Text)highScoreComponent).text = "High Score: " + highScore.ToString();
            }
            else if (highScoreComponent is TMPro.TMP_Text)
            {
                ((TMPro.TMP_Text)highScoreComponent).text = "High Score: " + highScore.ToString();
            }
        }
    }
}
