using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    internal float horizontal;
    internal bool isJumpDown;
    internal bool isHorizontalUp;
    internal bool isHorizontalPressed;
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        isJumpDown = Input.GetButtonDown("Jump");
        isHorizontalUp = Input.GetButtonUp("Horizontal");
        isHorizontalPressed = Input.GetButton("Horizontal");
    }
}