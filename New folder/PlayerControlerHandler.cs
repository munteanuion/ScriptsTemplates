using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControlerHandler : MonoBehaviour
{
    [SerializeField] private Text _CountJumpTextInfo;
    [SerializeField] private int _countJumpPosible = 10;

    private AdaugaForta2D _adaugaForta2DComponent;

    private void Start()
    {
        _adaugaForta2DComponent = GetComponent<AdaugaForta2D>();
        _CountJumpTextInfo.text = _countJumpPosible.ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(_adaugaForta2DComponent.GetButtonAddForce()) && _countJumpPosible > 0)
        {
            JumpPlayer();
        }
    }

    public void JumpPlayer()
    {   
        if (_countJumpPosible < 1)
            return;
        _countJumpPosible--;
        _CountJumpTextInfo.text = _countJumpPosible.ToString();
        _adaugaForta2DComponent.AdaugaForta();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "JumpAdd":
                _countJumpPosible++;
                _CountJumpTextInfo.text = _countJumpPosible.ToString();
                Destroy(collision.gameObject);
                break;
            default:
                break;
        }
    }
}
