using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private Transform orientation;

    private float sense = 0;

    private float xRotation = 0;
    private float yRotation = 0;


    private void Start()
    {
        sense = float.Parse(File.ReadAllText(Application.persistentDataPath + "/OptionsSensitivity.txt"));
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sense * 1000;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sense * 1000;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
