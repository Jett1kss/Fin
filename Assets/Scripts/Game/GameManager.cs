using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverCanvas;
    [SerializeField]
    private TMP_Text score;
    [SerializeField]
    private TMP_Text bestScore;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioMixer audioMixer;
    [SerializeField]
    private GameObject pauseCanvas;

    private int time = 0;

    private bool pause = false;


    private void Start()
    {
        InvokeRepeating("Timer", 0, 1);
        float volume = float.Parse(File.ReadAllText(Application.persistentDataPath + "/OptionsVolume.txt"));
        audioMixer.SetFloat("Volume", volume);
        if (volume == -45)
        {
            audioSource.mute = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (pause)
            {
                EndPause();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;

        audioSource.Pause();

        pauseCanvas.SetActive(true);
        int max = Mathf.Max(int.Parse(File.ReadAllText(Application.persistentDataPath + "/Score.txt")), time);
        File.WriteAllText(Application.persistentDataPath + "/Score.txt", max.ToString());

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        pause = true;
    }

    public void EndPause()
    {
        pause = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        pauseCanvas.SetActive(false);

        audioSource.Play();

        Time.timeScale = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Time.timeScale = 0;

            audioSource.Pause();

            gameOverCanvas.SetActive(true);
            int max = Mathf.Max(int.Parse(File.ReadAllText(Application.persistentDataPath + "/Score.txt")), time);
            File.WriteAllText(Application.persistentDataPath + "/Score.txt", max.ToString());
            score.text = "Ñ÷¸ò: " + time.ToString();
            bestScore.text = "Ëó÷øèé ñ÷¸ò: " + max.ToString();

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void Timer()
    {
        time++;
    }
}
