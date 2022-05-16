using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimalController : MonoBehaviour
{
    [SerializeField] GameManager manager;
    public int score { get; protected set; }
    protected Vector3 moveDirection;
    protected float speed;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        MovementDirection();
        transform.LookAt(moveDirection);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }

    protected void OnTriggerEnter(Collider other)
    {
        UpdateScore();
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

    protected virtual void UpdateScore()
    {
        manager.addScore(score);
    }

    protected abstract void MovementDirection();
}
