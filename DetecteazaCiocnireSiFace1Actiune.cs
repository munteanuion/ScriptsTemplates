using UnityEngine;
using UnityEngine.SceneManagement;

public class DetecteazaCiocnireSiFace1Actiune : MonoBehaviour
{
    enum TipObiectCollider
    {
        Trigger,
        Collider
    }

    [SerializeField] private TipObiectCollider _tipObiectCollider;
    [SerializeField] private string _numeTagIntersectie;
    [SerializeField] private GameObject _gameOverPanel;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == _numeTagIntersectie && _tipObiectCollider.Equals(TipObiectCollider.Collider))
        {
            GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == _numeTagIntersectie && _tipObiectCollider.Equals(TipObiectCollider.Trigger))
        {
            GameOver();
        }
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void GameOver()
    {
        Time.timeScale = 0f;
        _gameOverPanel.SetActive(true);
    }
}
