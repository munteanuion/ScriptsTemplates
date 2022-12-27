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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == _numeTagIntersectie && _tipObiectCollider.Equals(TipObiectCollider.Collider))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == _numeTagIntersectie && _tipObiectCollider.Equals(TipObiectCollider.Trigger))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
