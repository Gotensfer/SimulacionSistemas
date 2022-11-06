using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOscillation : MonoBehaviour
{
    Vector3 inicialposicion;

    [SerializeField] private float alcance = 3;
    [SerializeField] private bool diagonal = false;

    void Start()
    {
        inicialposicion = transform.position;
    }

    void Update()
    {
        float rhu = Mathf.Sin(4f * Time.time) + Mathf.Sin(2f * Time.time) + Mathf.Sin(1f * Time.time) + Mathf.Sin(4f * Time.time);
        
        if (diagonal)
        {
            transform.position = inicialposicion + new Vector3(1, 1, 1) * rhu * alcance;
        }
        else
        {
            transform.position = inicialposicion + Vector3.right * rhu * alcance;
        }
    }
}