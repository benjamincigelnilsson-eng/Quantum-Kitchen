using UnityEngine;

[CreateAssetMenu(menuName = "Cooking/Dish")]
public class Dish : ScriptableObject
{
    public string dishName;
    public Sprite icon;   // bilden från spel grafikern
    public int points = 30;  // hur mycket poäng den ger
}
