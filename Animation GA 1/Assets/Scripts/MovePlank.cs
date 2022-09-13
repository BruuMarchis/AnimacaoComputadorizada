using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlank : MonoBehaviour
{
    [SerializeField] public AnimationCurve curve;
    public Transform targetPos1;
    public Transform targetPos2;
    public Vector3 target;
    public float moveTime = 4000;
    public float currentTime = 0;
    bool touched;

    void Start()
    {
        touched= false;
    }

    void Update()
    {
        if (currentTime < moveTime)
        {
            float normalizedProgress = currentTime / moveTime;
            float easing = curve.Evaluate(normalizedProgress);
            transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos2.position, easing);
            currentTime++;
        }
        if (currentTime > moveTime)
        {
            this.gameObject.SetActive(false);
            //Destroy(this);
        }
    }


}
