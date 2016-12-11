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

        if (Input.GetButtonUp("Interact") && _playerIsCloseEnough)
        {
            Interact();
        }
    }

    protected virtual void Interact()
    {

        Debug.Log("Yey some has interacted with me !(" + GetType().Name + ")");

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
