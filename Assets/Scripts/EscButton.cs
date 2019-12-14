using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EscButton : MonoBehaviour
{
    public Text EscText;
    public bool isQuestionTextBeingShown;

    // Start is called before the first frame update
    void Start()
    {
        EscText.gameObject.SetActive(false);
        isQuestionTextBeingShown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isQuestionTextBeingShown = !isQuestionTextBeingShown;

            EscText.gameObject.SetActive(isQuestionTextBeingShown);
        }
    }

    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    public void HideQuestionText()
    {
        EscText.gameObject.SetActive(false);
        isQuestionTextBeingShown = false;
    }
}
