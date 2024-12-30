using UnityEngine;

public class RotateGraph : MonoBehaviour
{
    public Animator animator;
    private bool isRotatingForward = true;

    private void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        animator.SetBool("Play1", false);
    }

    private void OnMouseDown()
    {
        if (animator != null)
        {
            animator.SetBool("Play1", true);

            if (isRotatingForward)
            {
                animator.Play("rotate");
            }
            else
            {
                animator.Play("rotateback");
            }

            isRotatingForward = !isRotatingForward;
        }
    }

    private void Update()
    {
        if (animator != null && animator.GetCurrentAnimatorStateInfo(0).IsName("default"))
        {
            animator.SetBool("Play1", false);
        }
    }
}
