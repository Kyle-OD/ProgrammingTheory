using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject target, player;
    [SerializeField] Vector3 offset;

    [SerializeField] float mouseX, mouseY;
    [SerializeField] float rotationSpeed = 1;
    [SerializeField] float yMinAngle = -35f;
    [SerializeField] float yMaxAngle = 60f;
    // Start is called before the first frame update
    void Start()
    {
        MoveWithPlayer();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        MoveWithPlayer();
        camControl();
    }

    void MoveWithPlayer()
    {
        transform.position = target.transform.position + offset;

    }

    void camControl()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY += Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, yMinAngle, yMaxAngle);

        transform.LookAt(target.transform);

        target.transform.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        player.transform.rotation = Quaternion.Euler(0, mouseX, 0);
    }
}
