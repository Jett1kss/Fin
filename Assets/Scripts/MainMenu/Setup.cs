using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Setup : MonoBehaviour
{
    void Start()
    {
        if (!File.Exists(Application.persistentDataPath + "/OptionsVolume.txt"))
        {
            File.WriteAllText(Application.persistentDataPath + "/OptionsVolume.txt", "-30");
        }

        if (!File.Exists(Application.persistentDataPath + "/OptionsSensitivity.txt"))
        {
            File.WriteAllText(Application.persistentDataPath + "/OptionsSensitivity.txt", "1");
        }

        if (!File.Exists(Application.persistentDataPath + "/Score.txt"))
        {
            File.WriteAllText(Application.persistentDataPath + "/Score.txt", "0");
        }
    }
}
