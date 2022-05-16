using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] float projectileBaseSpeed = 8;
    [SerializeField] float projectileSpeed;
    [SerializeField] Vector3 forward;
    [SerializeField] GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
        Vector3 playerVelocity = player.GetComponent<ThirdPersonMovement>().velocity;
        forward = player.transform.forward;
        projectileSpeed = projectileBaseSpeed + Vector3.Dot(playerVelocity, forward);
        //forward = player.GetComponent<ThirdPersonMovement>().direction;
    }

    void Update()
    {
        transform.Translate(forward * projectileSpeed * Time.deltaTime, Space.World);

        // check limits for deletion
    }
}
