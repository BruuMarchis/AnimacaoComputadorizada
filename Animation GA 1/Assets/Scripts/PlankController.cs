using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankController : MonoBehaviour
{

    public Transform startTarget;
    public Transform endTarget;
    public GameObject[] planks;

    void Start()
    {
        StartCoroutine(newPlank());
    }

    IEnumerator newPlank()
    {
        yield return new WaitForSeconds(1.5f);
        int num = Random.Range(0, planks.Length);
        GameObject plank = Instantiate(planks[num], startTarget.position, startTarget.rotation);
        plank.GetComponent<MovePlank>().targetPos1 = startTarget;
        plank.GetComponent<MovePlank>().targetPos2 = endTarget;

        StartCoroutine(newPlank());
    }
}
