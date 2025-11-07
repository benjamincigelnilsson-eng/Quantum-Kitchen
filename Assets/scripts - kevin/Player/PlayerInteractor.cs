using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    public float range = 1.5f;
    public LayerMask interactMask = ~0; // Everything som default (bra för test)

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("[Interactor] E pressed");
            TryInteract();
        }
    }

    void TryInteract()
    {
        // Hitta ALLA colliders i en cirkel runt spelaren
        Collider2D[] hits = Physics2D.OverlapCircleAll((Vector2)transform.position, range, interactMask);

        if (hits == null || hits.Length == 0)
        {
            Debug.Log("[Interactor] No colliders in range");
            return;
        }

        // Logga vad vi träffade (hjälper vid felsökning)
        for (int k = 0; k < hits.Length; k++)
        {
            if (hits[k] != null)
                Debug.Log("[Interactor] Hit: " + hits[k].name);
        }

        // Välj närmaste objekt som har IInteractable
        IInteractable best = null;
        float bestDist = float.MaxValue;

        for (int i = 0; i < hits.Length; i++)
        {
            Collider2D col = hits[i];
            if (col == null) continue;

            // Leta på objektet och ev. på dess parent
            IInteractable interactable = col.GetComponent<IInteractable>();
            if (interactable == null) interactable = col.GetComponentInParent<IInteractable>();
            if (interactable == null) continue;

            // Avstånd från spelaren till colliderns närmaste punkt
            float d = Vector2.Distance((Vector2)transform.position, col.bounds.ClosestPoint(transform.position));
            if (d < bestDist)
            {
                bestDist = d;
                best = interactable;
            }
        }

        if (best != null)
        {
            Debug.Log("[Interactor] Interacting with nearest interactable");
            best.Interact(gameObject);
        }
        else
        {
            Debug.Log("[Interactor] Found colliders, but none implement IInteractable");
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    // Används ibland av andra scripts – kvar för bekvämlighet
    public HeldItem GetHeld()
    {
        return GetComponent<HeldItem>();
    }
}
