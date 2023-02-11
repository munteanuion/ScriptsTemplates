using UnityEngine;

public class DetecteazaCiocnireSiDezactiveazaTrailRender : MonoBehaviour
{
    enum TipObiectCollider
    {
        Trigger,
        Collider
    }

    [SerializeField] private TipObiectCollider _tipObiectCollider;
    [SerializeField] private string _numeTagIntersectie;
    [SerializeField] private TrailRenderer _trailRender;

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

    private void GameOver()
    {
        _trailRender.enabled = false;
    }
}
