using UnityEngine;
using Unity.Cinemachine;
public class CameraController : MonoBehaviour
{
    [SerializeField] CinemachineCamera cinemachineCamera;

    public bool isCameraLocked = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) { isCameraLocked = !isCameraLocked; }

        if (isCameraLocked) { cinemachineCamera.enabled = false; }
        else { cinemachineCamera.enabled = true; }
    }
}