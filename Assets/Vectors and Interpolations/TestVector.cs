using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestVector : MonoBehaviour
{
    [SerializeField] CustomVector2 vector1;
    [SerializeField] CustomVector2 vector2;

    [SerializeField] CustomVector2 sustractVector;
    [SerializeField] CustomVector2 lerpedVector;
    [Range(0, 1), SerializeField] float relativeDistance;

    [SerializeField] CustomVector2 addVector;

    private void Update()
    {
        vector1.Draw();
        vector2.Draw(Color.blue);

        sustractVector = vector2 - vector1;
        sustractVector.Draw(vector1, Color.yellow);

        // Lerped vector
        lerpedVector = CustomVector2.Lerp(vector1, vector2, relativeDistance);
        lerpedVector.Draw(Color.green);

        // Add
        addVector = vector1 + vector2;
        addVector.Draw(Color.white);
    }
}
