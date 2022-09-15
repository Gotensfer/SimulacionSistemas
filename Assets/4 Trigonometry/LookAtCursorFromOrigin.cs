using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCursorFromOrigin : MonoBehaviour
{
    /* Manera vaquera, no tan """"""elegante"""""" pero practicamente igual de eficiente
    Vector3 offsetOrigin;
    private void Start()
    {
        offsetOrigin = transform.position - Vector3.zero;
    }
    */

    void Update()
    {
        Vector4 worldMousePosition = GetWorldMousePosition();
        Vector3 relativeMousePosition = (Vector3)worldMousePosition - transform.position;
        float radians = Mathf.Atan2(relativeMousePosition.y, relativeMousePosition.x);
        RotateZ(radians);
    }

    private Vector4 GetWorldMousePosition()
    {
        Camera camera = Camera.main;
        Vector3 screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane);
        Vector4 worldPos = Camera.main.ScreenToWorldPoint(screenPos) /* - offsetOrigin */ ;
        print(worldPos);
        return worldPos;
    }

    private void RotateZ(float radians)
    {
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, radians * Mathf.Rad2Deg);
    }
}
