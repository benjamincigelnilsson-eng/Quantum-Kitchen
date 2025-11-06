using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    public float range = 0.7f;
    public LayerMask interactMask;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            Debug.Log("E tryckt!");

        {
            var hit = Physics2D.OverlapCircle(transform.position, range, interactMask);
            if (hit != null)
            {
                var interactable = hit.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    interactable.Interact(gameObject);
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public HeldItem GetHeld() => GetComponent<HeldItem>();
}
