using UnityEngine;
using UnityEngine.UI;

public class DistanceController : MonoBehaviour
{
    [SerializeField] private Transform lastFightTrigger;
    [SerializeField] private Transform playerPosition;

    [SerializeField] private Slider slider;

    private void Start() => slider.maxValue = Distance();
    private void LateUpdate() => slider.value = Distance();
    
    private float Distance() => Vector3.Distance(playerPosition.position, lastFightTrigger.position);
}
