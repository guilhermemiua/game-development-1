using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float displacement = 3;
    private float count = 0;
    private Vector2 initialPosition;
    public float width = 1;
    public float height = 0;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        float x = Mathf.Sin(count) * width;
        float y = Mathf.Cos(count) * height;

        transform.position = new Vector2(initialPosition.x + x, initialPosition.y + y);

        count += displacement * Time.deltaTime;

        if (count > 2 * Mathf.PI)
            count = 0;
    }
}
