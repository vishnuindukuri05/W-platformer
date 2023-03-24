using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class NPC_Talk : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public AudioSource audio;

    private PostProcessVolume _postProcessVolume;
    private ColorGrading _cr;

    private bool on = false;
    private int color = 0;
    private bool brub;

    public string InteractionPrompt => _prompt;

    private void Start() 
    {
        _postProcessVolume = GameObject.Find("Player_Camera").GetComponent<PostProcessVolume>();
        _postProcessVolume.profile.TryGetSettings(out _cr);
        brub = true;
    }

    public bool Interact(Interactor interactor)
    {
        // put command to do here (maybe trigger dialogue?)
        Debug.Log("Initiate Dialogue");
        on = true;
        audio.Play(0);
        // GetComponent<scriptName>().triggerDialogue; or something like that
        return true;
    }

    private void Update() {
        if(on) {
            if (brub){
                color++;
            }
            else{
                color--;
            }
            if(color < -180) {
                brub = true;
            }
            if(color > 180) {
                brub = false;
            }
        }
        _cr.hueShift.value = color;
    }
}
