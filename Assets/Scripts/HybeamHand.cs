using UnityEngine;
using Oculus.Interaction.Input;

public class HybeamHand : OVRHand
{
    public bool IsPalmFacingCamera()
    {
        // Assuming PointerPose represents the palm's orientation and position
        Vector3 palmForward = PointerPose.forward; // Palm's forward direction
        Vector3 toCamera = (Camera.main.transform.position - PointerPose.position).normalized; // Direction from palm to camera

        // Calculate the dot product to determine if the palm faces the camera
        // Dot product > 0 means the angle is less than 90 degrees, indicating "facing"
        return Vector3.Dot(palmForward, toCamera) > 0;
    }
}
