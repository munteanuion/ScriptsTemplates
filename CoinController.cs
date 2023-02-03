using UnityEngine;
using UnityEngine.UI;

public class CoinController : MonoBehaviour
{
    public Text coinText;
    public int coinCount = 0;
    public string coinTag = "Coin";

    private void Start()
    {
        if (PlayerPrefs.HasKey("CoinCount"))
        {
            coinCount = PlayerPrefs.GetInt("CoinCount");
        }

        UpdateCoinText();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == coinTag)
        {
            coinCount++;
            UpdateCoinText();
            Destroy(other.gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("CoinCount", coinCount);
    }

    private void UpdateCoinText()
    {
        coinText.text = coinCount.ToString();
    }
}
