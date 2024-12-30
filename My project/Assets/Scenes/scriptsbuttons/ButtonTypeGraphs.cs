using UnityEngine;

public class ButtonTypeGraphs : MonoBehaviour
{
    public Animator animator; 
    public Material graphMaterial; 
    public float defaultFrequency = 33.0f; 
    public float newFrequency = 37.0f; 
    private bool isRotatingForward = true; 
    private bool isFrequencyChanged = false; 

    private void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        animator.SetBool("Play2", false);

        if (graphMaterial != null)
        {
            graphMaterial.SetFloat("_Frequency", defaultFrequency);
        }
    }

    private void OnMouseDown()
    {
        if (animator != null)
        {
            animator.SetBool("Play2", true);

            if (isRotatingForward)
            {
                animator.Play("RotateOn");
            }
            else
            {
                animator.Play("RotateBack");
            }

            isRotatingForward = !isRotatingForward;
        }

        if (graphMaterial != null)
        {
            if (isFrequencyChanged)
            {
                graphMaterial.SetFloat("_Frequency", defaultFrequency);
            }
            else
            {
                graphMaterial.SetFloat("_Frequency", newFrequency);
            }

            isFrequencyChanged = !isFrequencyChanged;
        }
    }

    private void Update()
    {
        if (animator != null && animator.GetCurrentAnimatorStateInfo(0).IsName("default"))
        {
            animator.SetBool("Play2", false);
        }
    }
}
