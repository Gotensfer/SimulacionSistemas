using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] CustomVector2 position;
    [SerializeField] CustomVector2 aceleracion;
    CustomVector2 Displacement;
    [SerializeField] CustomVector2 velocity;
    [SerializeField] Transform Target;

    void Start()
    {
        position = transform.position;
    }

    void Update()
    {  
        Move();
        aceleracion.Draw(position, Color.blue);
        position.Draw(Color.green);
        velocity.Draw(position, Color.red);
    }
    public void Move()
    {
        // Displacement =velocity*Time.deltaTime;
        Displacement = velocity * Time.deltaTime;
        velocity = velocity + aceleracion * Time.deltaTime;
        position = position + Displacement;

        transform.position = position;

        aceleracion = Target.position - transform.position;
    }
}
