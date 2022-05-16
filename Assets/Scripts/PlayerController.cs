using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float distanceFromSpawn;

    [SerializeField] GameObject foodPrefab;
    [SerializeField] Vector3 foodOffset;
    [SerializeField] GameObject foodInHand;
    [SerializeField] float foodCooldown = 5f;
    bool foodOnCooldown = false;
    // Start is called before the first frame update
    void Start()
    {
        foodOffset = foodInHand.gameObject.transform.localPosition;
        foodOffset.y = foodInHand.gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();   
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !foodOnCooldown)
        {
            Debug.Log("Space Click Detected");
            foodOnCooldown = true;
            foodInHand.gameObject.SetActive(false);
            Instantiate(foodPrefab, transform.position + foodOffset, transform.rotation);
            StartCoroutine(FoodCooldown());
        }
    }

    IEnumerator FoodCooldown()
    {
        yield return new WaitForSeconds(foodCooldown);
        foodOnCooldown = false;
        foodInHand.gameObject.SetActive(true);
    }
}
