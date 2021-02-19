using UnityEngine;
using Cinemachine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera previousVirtualCamera;
    [SerializeField] CinemachineVirtualCamera newVirtualCamera;

    int currentRoomIndex;

    Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UpdateActiveCamera();
        } 
    }

    private void UpdateActiveCamera()
    {
        previousVirtualCamera.Priority = 0;
        newVirtualCamera.Priority = 1;

        currentRoomIndex = newVirtualCamera.gameObject.name[newVirtualCamera.gameObject.name.Length - 1] - 48;

        player.CurrentRoom = currentRoomIndex;
    }
}
