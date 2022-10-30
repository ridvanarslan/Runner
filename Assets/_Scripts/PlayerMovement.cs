using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] [Range(0f, 5f)] private float forwardSpeed;
    [SerializeField] [Range(0f, 5f)] private float sidewaysSpeed;

    [SerializeField] private Transform lastFightPosition;

    private void FixedUpdate()
    {
        if (GameManager.Instance.IsLastFightStarted)
        {
            transform.position = Vector3.Lerp(transform.position, lastFightPosition.position, 5f);
        }
        else
        {
            transform.Translate(Vector3.forward * (forwardSpeed * Time.deltaTime));
        }
    }

    private void Update()
    {
        if (GameManager.Instance.IsLastFightStarted) return;

        if (Input.GetMouseButton(0))
        {
            if (Input.GetAxis("Mouse X") < 0)
            {
                transform.position = Vector3.Lerp
                (transform.position,
                    new Vector3(transform.position.x - .1f, transform.position.y, transform.position.z),
                    sidewaysSpeed);
            }
            else if (Input.GetAxis("Mouse X") > 0)
            {
                transform.position = Vector3.Lerp
                (transform.position,
                    new Vector3(transform.position.x + .1f, transform.position.y, transform.position.z),
                    sidewaysSpeed);
            }
        }
    }
}