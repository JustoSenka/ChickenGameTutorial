using System;
using UnityEngine;
using UnityEngine.UI;

public class HeartDisplay : MonoBehaviour
{
    [SerializeField]
    private Image[] Hearts;

    private Color activeHeart = new Color(1, 1, 1, 1);
    private Color disabledHeart = new Color(0.8f, 0.8f, 0.8f, 0.3f);

    public void SetHearts(int amountOfLives)
    {
        for (int i = 0; i < Hearts.Length; i++)
        {
            if (i + 1 <= amountOfLives)
            {
                // set heart to active
                Hearts[i].color = activeHeart;
            }
            else
            {
                // set heart transparent
                Hearts[i].color = disabledHeart;
            }
        }
    }
}
