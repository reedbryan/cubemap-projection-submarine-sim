using UnityEngine;

public class ConfigureDisplays : MonoBehaviour
{
    void Start()
    {
        // Fullscreen on the main display
        Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        Screen.fullScreen = true;

        for (int i = 1; i < Display.displays.Length; i++)
        {
            Display.displays[i].Activate();
        }
    }
}
