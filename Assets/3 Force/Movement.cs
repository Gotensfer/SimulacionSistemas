using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] CustomVector2 position;
    [SerializeField] CustomVector2 aceleracion;
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
        velocity = velocity + aceleracion * Time.deltaTime;
        position = position + velocity * Time.deltaTime;
        transform.position = position;

        aceleracion = Target.position - transform.position;
    }
}
