using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private int _shards = 0;

    public void AddShard(int amount)
    {
        _shards += amount;
    }
}
