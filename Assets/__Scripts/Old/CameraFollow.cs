using UnityEngine;
using UnityEngine.UIElements;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform cameraTarget;
    [SerializeField] private Vector3 cameraOffset = new Vector3(0, 0, -10);
    [SerializeField] private float cameraSmoothing;

    void LateUpdate()
    {
        Vector3 newPosition = Vector3.Lerp(transform.position, cameraTarget.position + cameraOffset, cameraSmoothing * Time.deltaTime);
        transform.position = newPosition;
    }
}
