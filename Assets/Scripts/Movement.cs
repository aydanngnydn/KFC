using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float direction;
    [SerializeField] private float typeChangeTime;
    private bool move, layDown;

    private void Start()
    {
        StartCoroutine(MovementType());
    }

    private void Update()
    {
        if (move && !layDown)
        {
            transform.Translate(Vector3.up * (direction * speed * Time.deltaTime));
        }
        else if (!move && layDown)
        {
            //animplay
        }
    }

    private IEnumerator MovementType()
    {
        move = true;
        layDown = false;
        yield return new WaitForSeconds(typeChangeTime);
        layDown = true;
        move = false;

    }
}
