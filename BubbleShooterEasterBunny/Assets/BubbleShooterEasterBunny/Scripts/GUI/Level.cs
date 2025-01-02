using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public int number;
    public Text label;
    public GameObject lockimage;

    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.GetInt("Score" + (number - 1)) > 0)
        {
            if (label != null)
            {
                label.text = "" + number;
            }

            if (lockimage != null)
            {
                lockimage.gameObject.SetActive(false);
            }
        }

        int stars = PlayerPrefs.GetInt(string.Format("Level.{0:000}.StarsCount", number), 0);

        if (stars > 0)
        {
            for (int i = 1; i <= stars; i++)
            {
                transform.Find("Star" + i).gameObject.SetActive(true);
            }

        }

    }

    public void StartLevel()
    {
        InitScriptName.InitScript.Instance.OnLevelClicked(number);
    }
}
