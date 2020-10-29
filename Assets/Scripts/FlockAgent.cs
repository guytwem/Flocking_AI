using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))] // we have to be attached to a gameobject that has a collider2d attached
public class FlockAgent : MonoBehaviour
{
    Flock agentFlock;

    public Flock AgentFlock { get { return agentFlock; } }

    private Collider2D agentCollider;

    public Collider2D AgentCollider { get { return agentCollider; } }


    void Start()
    {
        agentCollider = GetComponent<Collider2D>();
    }

    public void Initialize(Flock flock)
    {
        agentFlock = flock;
    }

    public void Move(Vector2 velocity)
    {
        transform.up = velocity;
        transform.position += (Vector3)velocity * Time.deltaTime;
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
