using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform[] cameraTargets;
    [SerializeField] private Vector3 cameraOffset = new Vector3(0, 0, -10);
    [SerializeField] private float cameraSmoothing;

    void LateUpdate()
    {
        cameraTargets = GameObject.FindGameObjectsWithTag("Player").Select(player => player.transform).ToArray();
        Vector2 middlePosition = Vector2.zero;
        foreach (var cameraTarget in cameraTargets)
        {
            middlePosition = new Vector2(middlePosition.x + cameraTarget.position.x, middlePosition.y + cameraTarget.position.y);
        }
        middlePosition = new Vector2(middlePosition.x / cameraTargets.Length, middlePosition.y / cameraTargets.Length);

        Vector3 newPosition = Vector3.Lerp(transform.position, (Vector3)middlePosition + cameraOffset, cameraSmoothing * Time.deltaTime);
        transform.position = newPosition;
    }
}
