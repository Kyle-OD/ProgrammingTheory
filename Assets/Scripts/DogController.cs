using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : AnimalController // INHERITANCE
{
    [SerializeField] float rangeMin = 0;
    [SerializeField] float rangeMax = 5;
    [SerializeField] float dogSpeed = 6;
    [SerializeField] int dogScore = 5;

    private void Start()
    {
        speed = dogSpeed;
        score = dogScore;
        MovementDirection(); // ABSTRACTION
        transform.LookAt(moveDirection);
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
        moveDirection = new Vector3(xPos, 0, zPos);
    }
}
