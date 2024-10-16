using UnityEngine;
public class Attack : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        HandleLife.onHeroDeath += OnDeath;
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("attack"))
            {
                animator.SetTrigger("attack");
            }
        }
    }
    private void OnDeath()
    {
        this.enabled = false;
    }
}