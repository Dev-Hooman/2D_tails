using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    private void Update()
    {
        //if we want to move it to every frame then we use Time.deltaTime
        transform.Rotate(0, 0, 360 * speed * Time.deltaTime);
    }
}
