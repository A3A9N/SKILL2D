using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadratischeFuntion : MonoBehaviour
{
    public float gravity = 9.81f;
    public float initialVelocity = 20f;
    public float targetHeight = 15f;

    void Start()
    {
        CalculateJumpTimes(initialVelocity, targetHeight, gravity);
    }

    void CalculateJumpTimes(float vBegin, float s, float g)
    {
        float a = -0.5f * g;
        float b = vBegin;
        float c = -s;

        float discriminant = (b * b) - (4 * a * c);

        if (discriminant < 0)
        {
            Debug.Log("Geen echte oplossing, het object bereikt deze hoogte nooit.");
            return;
        }


        float sqrtDiscriminant = Mathf.Sqrt(discriminant);
        float t1 = (-b + sqrtDiscriminant) / (2 * a);
        float t2 = (-b - sqrtDiscriminant) / (2 * a);


        Debug.Log($"Het object bereikt {s} meter op:");
        Debug.Log($"t1 = {t1} seconden (opgaande beweging)");
        Debug.Log($"t2 = {t2} seconden (terugkomende beweging)");
    }
}

