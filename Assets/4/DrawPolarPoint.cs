using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPolarPoint : MonoBehaviour
{
    [SerializeField] CustomVector2 polarCoordinate;
    [SerializeField] CustomVector2 cartesianCoordinate;   

    private void Update()
    {
        cartesianCoordinate = polarCoordinate.FromPolarToCartesian();

        cartesianCoordinate.Draw();
    }
}
