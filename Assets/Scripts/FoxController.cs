using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxController : AnimalController // INHERITANCE
{
    [SerializeField] float rangeMin = 4;
    [SerializeField] float rangeMax = 10;
    [SerializeField] float foxSpeed = 10;
    [SerializeField] int foxScore = 10;

    private void Start()
    {
        speed = foxSpeed;
        score = foxScore;
        MovementDirection(); // ABSTRACTION
        transform.LookAt(transform.position + moveDirection);
    }

    protected override void MovementDirection() // POLYMORPHISM
    {
        float xPos = Random.Range(-rangeMax, rangeMax);
        float zMin = Mathf.Sqrt(Mathf.Abs(Mathf.Pow(rangeMin, 2) - Mathf.Pow(xPos, 2)));
        float zMax = Mathf.Sqrt(Mathf.Abs(Mathf.Pow(rangeMax, 2) - Mathf.Pow(xPos, 2)));
        float zPos = Random.Range(zMin, zMax + (zMax - zMin));
        if (zPos > zMax)
        {
            //Debug.Log("zPos: " + zPos + ", zMax: " + zMax + ", zMin: " + zMin);
            zPos = (zMax - zMin) - zPos;
        }

        Vector3 spawn = transform.position;
        Vector3 midPoint = new Vector3(xPos, 0, zPos);

        moveDirection = (midPoint - spawn).normalized;

    }
}
