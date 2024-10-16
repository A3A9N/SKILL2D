using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleLife : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private int lives = 5;
    public static event Action onHeroDeath;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Delete))
        {
            lives--;
            animator.SetInteger("lives", lives);
            if (lives == 0)
            {
                onHeroDeath?.Invoke();
            }
        }
    }
}