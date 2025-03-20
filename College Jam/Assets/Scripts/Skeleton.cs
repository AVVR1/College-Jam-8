using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    private void Awake()
    {
        GameObject grandpa = GameObject.Find("Grandpa");
        transform.position = grandpa.transform.position - Vector3.up;
        transform.rotation = Quaternion.Euler(0, grandpa.transform.rotation.eulerAngles.y + 90, 0);
        print(grandpa.transform.rotation.eulerAngles.y);
        print(transform.rotation.eulerAngles.y);
    }
}