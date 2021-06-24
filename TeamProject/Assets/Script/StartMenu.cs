using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StartMenu : MonoBehaviour
{
    public Button PlayBtn;
    public Button ExitBtn;
    private void Awake()
    {
        PlayBtn.onClick.AddListener(PlayGame);
        ExitBtn.onClick.AddListener(ExitGame);
    }

    private void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
