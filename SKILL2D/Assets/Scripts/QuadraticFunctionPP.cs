using UnityEngine;

public class QuadraticFunctionPP : MonoBehaviour
{
    public float gravity = 10f;
    public float initialVelocity = 10f; 

    public Vector3 startPosition = new Vector3(-3f, -2f, 0f);
    public Vector3 endPosition = new Vector3(2f, 1f, 0f);

    private float jumpTime; 

    void Start()
    {
        transform.position = startPosition;

        jumpTime = CalculateJumpTime(initialVelocity, gravity, startPosition.y, endPosition.y);

        if (jumpTime > 0)
        {
            Debug.Log($"De sprong duurt {jumpTime} seconden.");
            StartCoroutine(SimulateJump(jumpTime));
        }
        else
        {
            Debug.Log("Geen geldige sprong gevonden.");
        }
    }

    float CalculateJumpTime(float v0, float g, float yBegin, float yEnd)
    {
        float a = -0.5f * g;
        float b = v0;
        float c = yBegin - yEnd;

        float discriminant = (b * b) - (4 * a * c);

        if (discriminant < 0)
        {
            return -1;
        }


        float sqrtDiscriminant = Mathf.Sqrt(discriminant);
        float t1 = (-b + sqrtDiscriminant) / (2 * a);
        float t2 = (-b - sqrtDiscriminant) / (2 * a);

        return Mathf.Max(t1, t2);
    }

    System.Collections.IEnumerator SimulateJump(float duration)
    {
        float elapsedTime = 0f;
        Vector3 startPos = startPosition;
        Vector3 endPos = endPosition;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;


            float newX = Mathf.Lerp(startPos.x, endPos.x, t);
            float newY = Mathf.Lerp(startPos.y, endPos.y, t);
            float newZ = Mathf.Lerp(startPos.z, endPos.z, t);

            transform.position = new Vector3(newX, newY, newZ);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = endPos; 
    }
}
