using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    private bool _playerIsCloseEnough;

    void Start()
    {
        _playerIsCloseEnough = false;
    }
    void Update()
    {
        CheckInteraction();

    }

    protected virtual void CheckInteraction()
    {
        if (Input.GetButtonUp("Interact") && _playerIsCloseEnough)
        {
            Debug.Log("Yey some has interacted with me !");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tags.Player.ToString())
        {
            _playerIsCloseEnough = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == Tags.Player.ToString())
        {
            _playerIsCloseEnough = false;

        }
    }



}
