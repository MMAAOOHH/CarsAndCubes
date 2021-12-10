using UnityEngine;

public class Shard : MonoBehaviour, IInteractable
{
    private int _value = 1;
    
    public void Interact()
    {
        Pickup();
    }

    private void Pickup()
    {
        FindObjectOfType<PlayerStats>().AddShard(_value);
        Destroy(gameObject);
    }
}
