using UnityEngine;

public class DestroyAfterAnimation : MonoBehaviour
{
    private Animator animator;
    private float animationLength;

    private void Start()
    {
        animator = GetComponent<Animator>();
        
        if (animator == null)
        {
            Debug.LogError("No Animator component found on the GameObject.");
            Destroy(gameObject);
            return;
        }
        
        // Calculate the length of the animation by finding the first state.
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        animationLength = stateInfo.length;
    }

    private void Update()
    {
        // Wait for the animation to finish.
        animationLength -= Time.deltaTime;

        if (animationLength <= 0f)
        {
            // Destroy the GameObject after the animation finishes.
            Destroy(gameObject);
        }
    }
}
