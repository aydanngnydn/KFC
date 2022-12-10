using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float typeChangeTime;
    private bool move = true, layDown = false, aydo = false;
    private float xDir, yDir;
    private Vector3 dirVector;

    private void Start()
    {
        StartCoroutine(MovementType());
    }

    private void Update()
    {
        if (move && !layDown)
        {
            transform.Translate(dirVector * (speed * Time.deltaTime));
        }
        else if (!move && layDown)
        {
            //animplay
        }
    }

    private IEnumerator MovementType()
    {
        while (true)
        {
            int type = Random.Range(1, 3);
            switch (type)
            {
                case 1:
                    xDir = Random.Range(-1f, 1f); yDir = Random.Range(-1f, 1f);
                    dirVector = Vector3.Normalize(new Vector3(xDir, yDir, 0));
                    move = true; layDown = false;
                    yield return new WaitForSeconds(typeChangeTime);
                    break;
                case 2:
                    layDown = true; move = false;
                    yield return new WaitForSeconds(typeChangeTime);
                    break;
            }
            if (aydo)
            {
                break;
            }
        }
    }
}
