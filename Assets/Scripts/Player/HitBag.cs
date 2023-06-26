using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitBag : MonoBehaviour
{

    AudioSource src;
    [SerializeField] AudioClip[] bag_clips;
    [SerializeField] AudioClip[] umbrella_clips;
    PlayerMovement movement;

    [SerializeField] TMPro.TextMeshProUGUI txt;


    int previous_idx = -1;

    private void Start()
    {
        src = GetComponent<AudioSource>();
        movement = GetComponent<PlayerMovement>();
    }

    private void play_clip(AudioClip[] clips)
    {
        if (clips.Length == 0 || src.isPlaying)
            return;
        int idx = Random.Range(0, clips.Length);
        if(idx == previous_idx)
        {
            idx = (idx + 1) % clips.Length;
        }
        previous_idx = idx;
        src.clip = clips[idx];
        src.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.CompareTag("Bag"))
        {
            play_clip(bag_clips);
            if(movement.state != PlayerMovement.State.freefall)
            {
                movement.toggle_state();
            }
        }
        else if (collision.gameObject.CompareTag("Umbrella"))
        {

            play_clip(umbrella_clips);
            Destroy(collision.gameObject);
            if (movement.state != PlayerMovement.State.umbrella)
            {
                movement.toggle_state();
            }
        }
        else if (collision.gameObject.CompareTag("Bean"))
        {
            GameManager.got_bean();
            txt.text = "Score: " + GameManager.score;
            Destroy(collision.gameObject);
        }
    }
}
