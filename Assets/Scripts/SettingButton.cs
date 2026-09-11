using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SettingButton : MonoBehaviour
{
    public Button openSettingButton;
    public Button closeSettingButton;

    public void settingsOpened()
    {
        openSettingButton.gameObject.SetActive(false);
        closeSettingButton.gameObject.SetActive(true);
        closeSettingButton.interactable = true;
    }

    public void SettingClosed()
    {
        openSettingButton.gameObject.SetActive(true);
        openSettingButton.interactable = true;
        closeSettingButton.gameObject.SetActive(false);
    }
}
