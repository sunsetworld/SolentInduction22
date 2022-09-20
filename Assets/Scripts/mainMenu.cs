using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenuCanvas;
    [SerializeField] GameObject settingsCanvas;
    // Start is called before the first frame update
    void Start()
    {
        CloseSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenGame()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevel + 1);
    }

    public void OpenSettings()
    {
        mainMenuCanvas.SetActive(false);
        settingsCanvas.SetActive(true);
    }

    public void CloseSettings()
    {
        mainMenuCanvas.SetActive(true);
        settingsCanvas.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("This should quit the game.");
    }
}
