using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 playerSpawn;
    [SerializeField] Vector3 frisbeeOffset;
    [SerializeField] float playerRange = 7;
    [SerializeField] float playerSpeed = 5;
    [SerializeField] float distanceFromSpawn;

    [SerializeField] GameObject PlayerArm;
    [SerializeField] float petCooldown = 5f;
    bool petOnCooldown = false;
    // Start is called before the first frame update
    void Start()
    {
        playerSpawn = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        CheckInput();
    }

    private void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        distanceFromSpawn = (transform.position - playerSpawn).magnitude;

        if (distanceFromSpawn < playerRange)
        {
            transform.Translate(Vector3.right * Time.deltaTime * playerSpeed * horizontalInput);
            transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed * verticalInput);
        }
        else
        {
            transform.Translate((playerSpawn - transform.position).normalized * Time.deltaTime * playerSpeed);
        }
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !petOnCooldown)
        {
            Debug.Log("Mouse Click Detected");
            petOnCooldown = true;
            RotateArm();
            StartCoroutine(PetCooldown());
        }
    }

    private void RotateArm()
    {

    }

    IEnumerator PetCooldown()
    {
        yield return new WaitForSeconds(petCooldown);
        petOnCooldown = false;
    }
}
