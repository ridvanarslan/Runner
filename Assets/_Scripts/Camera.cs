using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 targetOffset;
    [SerializeField] [Range(.05f, .200f)] private float cameraFollowSpeed;

    [SerializeField] private Transform lastFightCamPosition;

    private void Start() => targetOffset = transform.position - target.position;

    private void LateUpdate()
    {
        if (!GameManager.Instance.IsLastFightStarted) 
            transform.position = Vector3.Lerp(transform.position, target.position + targetOffset, cameraFollowSpeed);
        else 
            transform.position = Vector3.Lerp(transform.position, lastFightCamPosition.position, cameraFollowSpeed / 2);
    }
}