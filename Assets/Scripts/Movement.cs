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
    private bool move = true;
    private float xDir, yDir;
    private Vector3 dirVector;
    public bool stop = true;
    [SerializeField] private float checkDist = .5f;
    [SerializeField] private LayerMask wallLayerMask;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private bool facingLeft = true;
    private void Start()
    {
        if (!_animator)
            _animator = GetComponent<Animator>();
        if (!_spriteRenderer)
            _spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(MovementType());
    }

    private void Update()
    {
        if(stop) return;
        if (move)
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

            switch (facingLeft)
            {
                case true when dirVector.x > 0:
                    facingLeft = false;
                    _spriteRenderer.flipX = true;
                    break;
                case false when dirVector.x < 0:
                    facingLeft = true;
                    _spriteRenderer.flipX = false;
                    break;
            }

            Debug.DrawLine(transform.position,transform.position + dirVector * checkDist,Color.green);
            transform.Translate(dirVector * (speed * Time.deltaTime));
        }
    }

    private IEnumerator MovementType()
    {
        while (true)
        {
            int type = Random.Range(1, 5);
            float typeChangeTime = Random.Range(minTime, maxTime);
            if (type < 3)
            {
                xDir = Random.Range(-1f, 1f);
                yDir = Random.Range(-1f, 1f);
                dirVector = Vector3.Normalize(new Vector3(xDir, yDir, 0));
                move = true;
                _animator.SetTrigger("Move");

            }

            if (type == 3)
            {
                move = false;
                _animator.SetTrigger("Cluck");
            }
            
            if (type == 4)
            {
                move = false;
                _animator.SetTrigger("Idle");
            }
            
            
            yield return new WaitForSeconds(typeChangeTime);
        }
    }
}
