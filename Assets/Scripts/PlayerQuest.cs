using UnityEngine;
using TMPro;

public class PlayerQuest : MonoBehaviour
{
    [SerializeField] int applesToCollect = 10;
    [SerializeField] private TMP_Text appleText;
    [SerializeField] private AudioClip pickupSFX;
    public int ApplesToCollect => applesToCollect;
    public int ApplesCollected => applesCollected;
    static int applesCollected = 0;
    private AudioSource audioSource;

    private void Start()
    {
        appleText.text = applesCollected.ToString();
        audioSource = GetComponent<AudioSource>();
    }
    public void AddApple()
    {
        applesCollected++;
        appleText.text = applesCollected.ToString();
        audioSource.pitch = Random.Range(0.8f, 1.2f);
        audioSource.PlayOneShot(pickupSFX);
    }
}
