using System;
using System.Collections;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Animator animator;

    public Transform waypoint1;
    public Transform waypoint2;

    Vector3 originalPos;

    public float moveSpeed = 2f;
    private MyCharacterController player;

    private void Start()
    {
        originalPos = transform.position;
        StartCoroutine(AICoroutine());
        player = FindAnyObjectByType<MyCharacterController>();
    }

    IEnumerator AICoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            animator.SetBool("IsWalking", true);
            transform.forward = (waypoint1.position - transform.position).normalized;
            while (Vector3.Distance(transform.position, waypoint1.position) > 0.001f)
            {
                transform.position = Vector3.MoveTowards(transform.position, waypoint1.position, moveSpeed * Time.deltaTime);
                yield return null;
            }
            animator.SetBool("IsWalking", false);

            yield return new WaitForSeconds(2);

            Vector3 direction = player.transform.position - transform.position;
            transform.forward = direction.normalized;

            animator.SetTrigger("Taunt");

            yield return new WaitForSeconds(5);
            animator.SetBool("IsWalking", true);
            transform.forward = (waypoint2.position - transform.position).normalized;
            while (Vector3.Distance(transform.position, waypoint2.position) > 0.001f)
            {
                transform.position = Vector3.MoveTowards(transform.position, waypoint2.position, moveSpeed * Time.deltaTime);
                yield return null;
            }
            animator.SetBool("IsWalking", false);

            yield return new WaitForSeconds(2);
            animator.SetBool("IsWalking", true);
            transform.forward = (originalPos - transform.position).normalized;
            while (Vector3.Distance(transform.position, originalPos) > 0.001f)
            {
                transform.position = Vector3.MoveTowards(transform.position, originalPos, moveSpeed * Time.deltaTime);
                yield return null;
            }
            animator.SetBool("IsWalking", false);
        }
    }
}
