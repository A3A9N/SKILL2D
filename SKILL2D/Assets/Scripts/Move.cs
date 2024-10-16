using UnityEngine;
public class Move : MonoBehaviour
{
    [SerializeField] private float speedModifier = 4f;
    private Animator animator;
    private float speed = 0;
    private Vector3 flipped = new Vector3(-1f, 1f, 1f);
    void Start()
    {
        animator = GetComponent<Animator>();
        HandleLife.onHeroDeath += OnDeath;
    }
    void Update()
    {
        speed = Input.GetAxis("Horizontal") * speedModifier;
        animator.SetFloat("speed", Mathf.Abs(speed));
        transform.position += Vector3.right * speed * Time.deltaTime;
        if (speed < 0) { transform.localScale = flipped; }
        else if (speed > 0) { transform.localScale = Vector3.one; }
    }
    private void OnDeath()
    {
        this.enabled = false;
    }
}