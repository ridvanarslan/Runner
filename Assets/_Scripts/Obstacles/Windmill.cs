using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Windmill : MonoBehaviour
{
    [SerializeField] private WindDirection windDirection;
    [SerializeField] [Range(.5f, 10f)] private float windForceAmount;
    [SerializeField] [Range(.5f, 1f)] private float minCooldown;
    [SerializeField] [Range(1f, 5f)] private float maxCooldown;

    [SerializeField] private bool isWindmillActive;
    private Animator animator;

    private void Awake() => animator = GetComponent<Animator>();

    private void Start() => AnimationStuation("true");

    public void AnimationStuation(string stuation)
    {
        if (stuation == "true")
        {
            animator.SetBool("__startWind", true);
            isWindmillActive = true;
        }
        else
        {
            animator.SetBool("__startWind", false);
            isWindmillActive = false;
            StartCoroutine(TriggerAnimation());
        }
    }

    private float RandomCooldown() => Random.Range(minCooldown, maxCooldown);

    private IEnumerator TriggerAnimation()
    {
        yield return new WaitForSeconds(RandomCooldown());
        AnimationStuation("true");
    }

    private void OnTriggerStay(Collider other)
    {
        if (isWindmillActive)
        {
            if (!other.CompareTag("Clone")) return;
            switch (windDirection)
            {
                case WindDirection.LeftToRight:
                    other.GetComponent<Rigidbody>().AddForce(Vector3.right * windForceAmount, ForceMode.Impulse);
                    break;
                case WindDirection.RightToLeft:
                    other.GetComponent<Rigidbody>().AddForce(Vector3.left * windForceAmount, ForceMode.Impulse);
                    break;
            }
        }
    }

    private enum WindDirection
    {
        LeftToRight,
        RightToLeft
    }
}