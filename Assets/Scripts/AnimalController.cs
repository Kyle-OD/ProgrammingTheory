using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimalController : MonoBehaviour
{
    [SerializeField] GameManager manager;
    public int score { get; protected set; }
    [SerializeField] protected Vector3 moveDirection;
    protected float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
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

    public virtual void setManager(GameManager gManager)
    {
        manager = gManager;
    }
}
