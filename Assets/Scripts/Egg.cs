using UnityEngine;

public class Egg : MonoBehaviour
{
    public bool IsRotten;

    private void OnTriggerEnter(Collider other)
    {
        var player = other.transform.parent.GetComponent<PlayerController>();

        if (IsRotten)
            player.ReduceHeart();
        else
            player.IncrementEggCount();

        Destroy(gameObject);
    }
}
