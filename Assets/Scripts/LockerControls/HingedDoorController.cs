using UnityEngine;

[RequireComponent(typeof(HingeJoint))]
public class HingedDoorController : MonoBehaviour
{
    [SerializeField] private float _hingeMotorVelocity = 100f;
    [SerializeField] private float _hingeMotorForce = 50f;

    private HingeJoint _hingeJoint;
    public bool IsOpen = false;
    private void OnEnable()
    {
        _hingeJoint = GetComponent<HingeJoint>();
    }

    public void SwitchDoorState()
    {
        Debug.Log("HingedDoorController SwitchDoorState");
        // Positive velocity opens the door
        _hingeMotorVelocity = Mathf.Abs(_hingeMotorVelocity);
        
        IsOpen = !IsOpen;
        
        if (!IsOpen)
            _hingeMotorVelocity *= -1f;

        JointMotor motor = new JointMotor();
        motor.force = _hingeMotorForce;
        motor.targetVelocity = _hingeMotorVelocity;

        _hingeJoint.motor = motor;
    }
}
