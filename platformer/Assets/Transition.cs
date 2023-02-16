using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    
    public Animator animator;
    public AudioSource audio;

    private int levelToLoad;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            FadeToNextLevel();
        }
    }

    public void FadeToNextLevel() {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void playAudio() {
        audio.Play(0);
    }

    public void FadeToLevel(int levelIndex) {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete() {
        SceneManager.LoadScene(levelToLoad);
    }
}
