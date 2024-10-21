using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCar : MonoBehaviour
{
    [Header("Steer")] [SerializeField] private float _maxSteer = 45;
    [SerializeField] private Wheel[] steerWheels;
    [Header("Power")] [SerializeField] private float _power = 10;
    [SerializeField] private Wheel[] powerWheels;
    [Space][SerializeField] private Lights lights;

    void Update()
    {
       Turning();
       Powering();
       Lights();
    }

    private void Turning()
    {
        foreach (var _wheelCollider in steerWheels)
        {
            _wheelCollider.Steer (Input.GetAxis("Horizontal") * _maxSteer);
        }
    }

    private void Powering()
    {
        foreach (var powerWheel in powerWheels)
        {
            powerWheel.Torque (Input.GetAxis("Vertical") * _power * Time.deltaTime);
        }
    }

    private void Lights()
    {
        lights.TailLights(Input.GetAxis("Vertical") < 0);
    }
}
