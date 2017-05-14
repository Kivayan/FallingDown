using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotate : MonoBehaviour {

    [Range(5, 50)] public float rotateSpeed = 25;
    private int orientation = 1;
    public bool gyroSteer = false;

    public float maxZRotate = 20;
    public Slider slider;
     
    private void Start()
    {
        if (gyroSteer)
            Input.gyro.enabled = true;
        SetSliderValues();
    }

    private void FixedUpdate()
    {
        if (gyroSteer)
            GyroSteer();
        else
            SliderSteer();

        DebugInfo();
    }

    private void SliderSteer()
    {
        float z = slider.value;
        transform.rotation = Quaternion.Euler(0, 0, z);
    }

    private void GyroSteer()
    {
        // z - 90 due to the fact that default gyro placement is landscape
        transform.rotation = Quaternion.Euler(0, 0, Input.gyro.attitude.eulerAngles.z + 90);
    }

    private void SetSliderValues()
    {
        slider.minValue = -maxZRotate;
        slider.maxValue = maxZRotate;
    }

    private void DebugInfo()
    {
        DebugPanel.Log("Slider Value", "Input", slider.value);
    }

    /*
    private void OnGUI()
    {
        GUI.TextArea(new Rect(150, 400, 70, 30), "orient = " + orientation);

        if (GUI.Button(new Rect(150, 500, 60, 60), "Click"))
            if (orientation < 3)
                orientation++;
            else
                orientation = 1;
    }
    */


}
