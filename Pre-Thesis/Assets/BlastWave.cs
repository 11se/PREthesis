using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastWave : MonoBehaviour
{
    public int PointsCount;

    public float maxradius;

    public float speed;

    public float startwidth;

    private LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.positionCount = PointsCount + 1;
    }
    private IEnumerator Blast()
    {
        float currentRadius = 0f;

        while(currentRadius < maxradius)
        {
            currentRadius += Time.deltaTime * speed;
            Draw(currentRadius);
            yield return null;
        }
    }

    private void Draw(float currentRadius)
    {
        float angleBetweenPoint = 360 / PointsCount;

        for(int i = 0; i <= PointsCount; i++)
        {
            float angle = i * angleBetweenPoint * Mathf.Deg2Rad;

            Vector3 direction = new Vector3(Mathf.Sin(angle),Mathf.Cos(angle),0f);
            Vector3 position = direction * currentRadius;

            lineRenderer.SetPosition(i, position);
        }

        lineRenderer.widthMultiplier = Mathf.Lerp(0f, startwidth, 1f - currentRadius / maxradius);
    }

    private void Update()
    {
        
    }
}
