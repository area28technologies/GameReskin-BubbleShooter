using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void PlayMain()
    {
        SceneManager.LoadScene("game");
    }

    public void PlayGamePlay()
    {
        SceneManager.LoadScene("Tuan-Gameplay");
    }
}
