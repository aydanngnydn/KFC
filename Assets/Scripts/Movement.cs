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
    [SerializeField] private float maxTime, minTime;
    private bool move = true, layDown = false, aydo = false, hovered = false;
    private float xDir, yDir;
    private Vector3 dirVector;
    public bool stop = false;
    [SerializeField] private float checkDist = .5f;
    [SerializeField] private LayerMask wallLayerMask;

    private void Start()
    {
        StartCoroutine(MovementType());
    }

    private void Update()
    {
        if(stop) return;
        if (move && !layDown)
        {
            RaycastHit2D wallInfo = Physics2D.Raycast(transform.position, dirVector, checkDist,wallLayerMask);

            var normal = wallInfo.normal;

            if (normal.x != 0)
            {
                dirVector = new Vector3(-dirVector.x, dirVector.y, dirVector.z);
            }
            if (normal.y != 0)
            {
                dirVector = new Vector3(dirVector.x, -dirVector.y, dirVector.z);
            }

            Debug.DrawLine(transform.position,transform.position + dirVector * checkDist,Color.green);
            transform.Translate(dirVector * (speed * Time.deltaTime));
        }
        else if (!move && layDown)
        {
            //animplay
        }
    }

    private IEnumerator MovementType()
    {
        int type = Random.Range(1, 3);
        while (true)
        {
            float typeChangeTime = Random.Range(minTime, maxTime);
            while (type == 1 && !hovered)
            {
                xDir = Random.Range(-1f, 1f);
                yDir = Random.Range(-1f, 1f);
                dirVector = Vector3.Normalize(new Vector3(xDir, yDir, 0));
                move = true; layDown = false;
                yield return new WaitForSeconds(typeChangeTime);
                type = Random.Range(1, 3);
            }

            while (type == 2)
            {
                layDown = true; move = false;
                yield return new WaitForSeconds(typeChangeTime);
                type = Random.Range(1, 3);
            }

            if (aydo)
            {
                break;
            }
        }
    }
}
