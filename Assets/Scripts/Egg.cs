using UnityEngine;

public class Egg : MonoBehaviour
{
    public bool IsRotten;
    public AudioClip soundWhenTaken;

    private void OnTriggerEnter(Collider other)
    {
        var player = other.transform.parent.GetComponent<PlayerController>();
        if (!player)
            return;

        if (IsRotten)
            player.ReduceHeart();
        else
            player.IncrementEggCount();

        var audioPlayer = GameObject.FindObjectOfType<PlayAudio>();
        if (audioPlayer)
        {
            audioPlayer.Play(soundWhenTaken);
        }
        else
        {
            Debug.LogError("Egg cannot play sounds because PlayAudio is not in the scene");
        }

        Destroy(gameObject);
    }
}
