using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class settings : MonoBehaviour
{

    Resolution[] resolutions;

    public TMP_Dropdown resDropdown;
    // Start is called before the first frame update
    void Start()
    {
        resolutions =  Screen.resolutions;

        resDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResIndex = i;
            }
        }

        resDropdown.AddOptions(options);
        resDropdown.value = currentResIndex;
        resDropdown.RefreshShownValue();
    }

    public void SetRes(int resIndex)
    {
        Resolution resolution = resolutions[resIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(int fullscreenIndex)
    {
        if (fullscreenIndex == 0)
        {
            Screen.fullScreen = true;
            Debug.Log("The screen should be fullscreen.");
        }
        else if (fullscreenIndex == 1)
        {
            Screen.fullScreen = false;
            Debug.Log("The screen shouldn't be fullscreen.");
        }
    }
}


// Tutorials used:

// https://youtu.be/YOaYQrN1oYQ