using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    private void Awake()
    {
        GameObject grandpa = GameObject.Find("Grandpa");
        transform.position = grandpa.transform.position - Vector3.up;
        transform.rotation = grandpa.transform.rotation;
    }
}
