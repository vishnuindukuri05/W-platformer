using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;
    [SerializeField] private int _numFound;
    [SerializeField] private InteractionPromptUI _interactionPromptUI;

    private IInteractable _interactable;
    private readonly Collider[] _colliders = new Collider[3];
    
    private void Start() {
        // Debug.Log("?????");
    }

    private void Update()
    {
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders, _interactableMask);
    
        if(_numFound > 0)
        {
            // Debug.Log(_colliders[0]);
            _interactable = _colliders[0].GetComponent<IInteractable>();
            if(_interactable != null)
            {
                if(!_interactionPromptUI.IsDisplayed) {
                    _interactionPromptUI.SetUp(_interactable.InteractionPrompt);
                }
                if(Input.GetKey(KeyCode.E)) {
                    _interactable.Interact(this);
                    _interactionPromptUI.Close();
                }   
            }
        }
        else 
        {
            if(_interactable != null) _interactable = null;
            if(_interactionPromptUI.IsDisplayed) _interactionPromptUI.Close();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }
}
