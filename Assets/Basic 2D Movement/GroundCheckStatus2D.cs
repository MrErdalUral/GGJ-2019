using UnityEngine;

public class GroundCheckStatus2D : MonoBehaviour
{
    public bool CanJump
    {
        get
        {
            var result = GroundCheck == null || GroundCheck.Value;
            return result;
        }
    }
    public bool IsTouchingGround
    {
        get
        {
            if(GroundCheck == null)
                Debug.Log("Missing groundcheck Object");
            return GroundCheck != null && GroundCheck.Value;
        }
    }

    public TriggerCheck2D GroundCheck;
}