using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class Options : MonoBehaviour
{
    [SerializeField]
    Slider volumeSlider;

    [SerializeField]
    Slider SensitivitySlider;


    [SerializeField]
    TMP_Text volumeText;

    [SerializeField]
    TMP_Text SensitivityText;

    public void OnVolumeChanged()
    {
        File.WriteAllText(Application.persistentDataPath + "/OptionsVolume.txt", volumeSlider.value.ToString());
        volumeText.text = volumeSlider.value.ToString() + " dB";
    }

    public void OnSensitivityChanged()
    {
        File.WriteAllText(Application.persistentDataPath + "/OptionsSensitivity.txt", SensitivitySlider.value.ToString());
        SensitivityText.text = SensitivitySlider.value.ToString();
    }

    public void Start()
    {
        volumeSlider.value = float.Parse(File.ReadAllText(Application.persistentDataPath + "/OptionsVolume.txt"));
        SensitivitySlider.value = float.Parse(File.ReadAllText(Application.persistentDataPath + "/OptionsSensitivity.txt"));

        volumeText.text = File.ReadAllText(Application.persistentDataPath + "/OptionsVolume.txt");
        SensitivityText.text = File.ReadAllText(Application.persistentDataPath + "/OptionsSensitivity.txt");
    }
}
