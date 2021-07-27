using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject character;
    public float yOffset = 2.5f;

    void Update()
    {
        Vector3 pos = new Vector3(character.transform.position.x,
                                  character.transform.position.y + yOffset,
                                  -10);
        transform.position = pos;
    }
}
