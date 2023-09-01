using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HingeJoint))]
public class HingedDoorController : MonoBehaviour
{
    [SerializeField] private float _hingeMotorVelocity = 100f;
    [SerializeField] private float _hingeMotorForce = 50f;

    private HingeJoint _hingeJoint;
    private void OnEnable()
    {
        _hingeJoint = GetComponent<HingeJoint>();
    }

    public void SetDoorState(bool isOpen)
    {
        // Negative velocity opens the door
        _hingeMotorVelocity = Mathf.Abs(_hingeMotorVelocity);
        
        if (isOpen)
            _hingeMotorVelocity *= -1f;

        JointMotor motor = new JointMotor();
        motor.force = _hingeMotorForce;
        motor.targetVelocity = _hingeMotorVelocity;

        _hingeJoint.motor = motor;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            SetDoorState(true);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            SetDoorState(false);
        }

    }
}
