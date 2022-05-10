using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] Transform cam;

    [SerializeField] float speed = 6f;

    [SerializeField] float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    Vector3 spawnPosition;
    [SerializeField] float playerRange;

    private void Start()
    {
        spawnPosition = transform.position;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float distanceFromSpawn = (transform.position - spawnPosition).magnitude;
        Vector3 direction;

        if (distanceFromSpawn < playerRange)
        {
            direction = new Vector3(horizontal, 0f, vertical).normalized;
            MovePlayer(direction);
        }
        else
        {
            direction = (spawnPosition - transform.position).normalized;
            controller.Move(direction * speed * Time.deltaTime);
        }
        
    }

    void MovePlayer(Vector3 direction)
    {
        if (direction.magnitude >= 0.1)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            transform.rotation = Quaternion.Euler(0, angle, 0);

            Vector3 moveDir = (Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward).normalized;

            controller.Move(moveDir * speed * Time.deltaTime);
        }
    }
}
