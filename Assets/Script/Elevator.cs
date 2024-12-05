using KinematicCharacterController;
using System;
using System.Collections;
using UnityEngine;

public class Elevator : MonoBehaviour, IMoverController
{
    public Transform topTransform;
    public Transform bottomTransform;
    Vector3 originalPosition;
    Vector3 targetPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<PhysicsMover>().MoverController = this;

        originalPosition = transform.position;
        targetPosition = originalPosition;
        //StartCoroutine(MoveCoroutine());
    }

    //IEnumerator MoveCoroutine()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(2);
    //        targetPosition = topTransform.position;
    //        while (Vector3.Distance(transform.position, topTransform.position) > 0.001f)
    //        {
    //            yield return null;
    //            //yield return new WaitForEndOfFrame();
    //        }

    //        yield return new WaitForSeconds(2);
    //        targetPosition = originalPosition;

    //        while (Vector3.Distance(transform.position, originalPosition) > 0.001f)
    //        {
    //            yield return null;
    //            //yield return new WaitForEndOfFrame();
    //        }
    //    }
    //}

    // Update is called once per frame

    public void UpdateMovement(out Vector3 goalPosition, out Quaternion goalRotation, float deltaTime)
    {
        goalPosition = Vector3.MoveTowards(transform.position, targetPosition, 2 * deltaTime);
        goalRotation = Quaternion.identity;
    }

    internal void GotoFloor(int floorNumber)
    {
        if (floorNumber == 1)
        {
            targetPosition = originalPosition;
        }
        else if (floorNumber == 2)
        {
            targetPosition = topTransform.position;
        }
    }
}
