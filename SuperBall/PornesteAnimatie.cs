using UnityEngine;

public class PornesteAnimatie : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private string _numeAnimatie;
    [SerializeField] private KeyCode _buttonActiveazaAnimatia;

    private void Update()
    {
        if (Input.GetKeyDown(_buttonActiveazaAnimatia))
        {
            PlayAnimation(_numeAnimatie);
        }
    }
    public void PlayAnimation(string animName)
    {
        animator.Play(animName);
    }
}
