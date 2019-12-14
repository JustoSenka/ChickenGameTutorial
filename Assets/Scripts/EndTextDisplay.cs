using UnityEngine;
using UnityEngine.UI;

public class EndTextDisplay : MonoBehaviour
{
    [SerializeField]
    private Text winText;

    [SerializeField]
    private Text loseText;

    public void ShowWinText()
    {
        winText.gameObject.SetActive(true);
    }

    public void ShowLoseText()
    {
        loseText.gameObject.SetActive(true);
    }

    void Start()
    {
        winText.gameObject.SetActive(false);
        loseText.gameObject.SetActive(false);
    }
}
