using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Talk : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;
    public bool Interact(Interactor interactor)
    {
        // put command to do here (maybe trigger dialogue?)
        Debug.Log("Initiate Dialogue");
        // GetComponent<scriptName>().triggerDialogue; or something like that
        return true;
    }
}
