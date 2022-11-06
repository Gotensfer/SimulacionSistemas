using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionGraph : MonoBehaviour
{
    [SerializeField] private GameObject m_pointprefab;
    [SerializeField] private int m_totalSamplePoint = 10;
    [SerializeField] private float separation = 0.5f;
    [SerializeField] private GameObject[] m_points;

    void Start()
    {
        m_points = new GameObject[m_totalSamplePoint];
        for (int i = 0; i < m_totalSamplePoint; i++)
        {
            m_points[i] = Instantiate(m_pointprefab, transform);
        }
    }

    void Update()
    {
        for (int i = 0; i < m_totalSamplePoint; i++)
        {
            var NewPoint = m_points[i];
            Vector3 currePosition = NewPoint.transform.position;
            currePosition.x = i * separation;
            currePosition.y = Mathf.Sin(currePosition.x + Time.time);
            NewPoint.transform.localPosition = currePosition;

        }
    }
}