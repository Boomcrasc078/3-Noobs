using System.Linq;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 cameraOffset = new Vector3(0, 0, -10);
    [SerializeField] private float cameraSmoothing = 5f;
    [SerializeField] private float zoomPadding = 2f;
    [SerializeField] private float minZoom = 5f;
    private Transform[] cameraTargets;

    void LateUpdate()
    {
        cameraTargets = GameObject.FindGameObjectsWithTag("Player").Select(player => player.transform).ToArray();
        if (cameraTargets.Length == 0)
        {
            return;
        }

        Bounds playerBounds = new Bounds(cameraTargets[0].position, Vector3.zero);
        foreach (var cameraTarget in cameraTargets)
        {
            playerBounds.Encapsulate(cameraTarget.position);
        }

        Camera camera = GetComponent<Camera>();
        float requiredHalfHeight = Mathf.Max(playerBounds.size.x / camera.aspect, playerBounds.size.y) * 0.5f + zoomPadding;
        Vector3 desiredPosition = playerBounds.center + cameraOffset;

        if (camera.orthographic)
        {
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, Mathf.Max(minZoom, requiredHalfHeight), cameraSmoothing * Time.deltaTime);
        }
        else
        {
            float requiredDistance = requiredHalfHeight / Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad);
            desiredPosition.z = playerBounds.center.z - Mathf.Max(Mathf.Abs(cameraOffset.z), requiredDistance);
        }

        transform.position = Vector3.Lerp(transform.position, desiredPosition, cameraSmoothing * Time.deltaTime);
    }
}
