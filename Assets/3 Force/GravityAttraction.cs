using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAttraction : MonoBehaviour
{
    [SerializeField] CustomVector2 position;
    [SerializeField] CustomVector2 aceleracion;
    [SerializeField] CustomVector2 velocity;
    [SerializeField] CustomVector2 f;
    [SerializeField] GravityAttraction target;

    public float mass = 1f;

    private void Start()
    {
        position = transform.position;
    }

    private void FixedUpdate()
    {
        aceleracion *= 0;

        CustomVector2 r = target.transform.position - transform.position;
        float rMagnitude = r.magnitude;
        f = r.normalized * ((target.mass * mass) / (rMagnitude * rMagnitude));
        
        if (velocity.magnitude > 10)
        {
            velocity.Normalized();
            velocity *= 10;
        }

        ApplyForce(f);

        f.Draw(transform.position, Color.red);
    }

    public void Move()
    {
        velocity = velocity + aceleracion * Time.fixedDeltaTime;
        position = position + velocity * Time.fixedDeltaTime;
        transform.position = position;
    }

    void ApplyForce(CustomVector2 force)
    {
        aceleracion += force * (1 / mass);
        Move();
    }
}
