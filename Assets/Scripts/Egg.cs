using UnityEngine;

public class Egg : MonoBehaviour
{
    public bool IsRotten;
    public AudioClip soundWhenTaken;

    private void OnTriggerEnter(Collider other)
    {
        var player = other.transform.parent.GetComponent<PlayerController>();

        if (IsRotten)
            player.ReduceHeart();
        else
            player.IncrementEggCount();

        var audioPlayer = GameObject.FindObjectOfType<PlayAudio>();
        audioPlayer.Play(soundWhenTaken);

        Destroy(gameObject);
    }
}
