using UnityEngine;
using UnityEngine.SceneManagement;
public class QuestChecker : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject finishedText;
    [SerializeField] private GameObject unfinishedText;
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<PlayerQuest>().ApplesCollected >= other.GetComponent<PlayerQuest>().ApplesToCollect)
            {
                panel.SetActive(true);
                finishedText.SetActive(true);
                animator.SetTrigger("QuestFinished");
                Invoke(nameof(LoadNextLevel), 3f);
            }
            else
            {
                panel.SetActive(true);
                unfinishedText.SetActive(true);

            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        panel.SetActive(false);
        unfinishedText.SetActive(false);
        finishedText.SetActive(false);
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings);
    }
}
