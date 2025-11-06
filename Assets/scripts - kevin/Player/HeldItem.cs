using UnityEngine;

public class HeldItem : MonoBehaviour
{
    // Vad spelaren håller i just nu
    public Dish carried;

    // Koll om spelaren håller något
    public bool HasDish => carried != null;

    // När spelaren tar upp mat
    public void Take(Dish d)
    {
        carried = d;
        Debug.Log("Spelaren tog: " + d.dishName);
    }

    // När spelaren ger bort maten (till kund)
    public void Clear()
    {
        Debug.Log("Spelaren gav bort: " + (carried != null ? carried.dishName : "inget"));
        carried = null;
    }
}
