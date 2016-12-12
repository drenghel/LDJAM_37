using UnityEngine;

public class PouringButton : MonoBehaviour
{
    [SerializeField] SpriteRenderer _overSpriteRenderer;
    [SerializeField] private Mixer _mixer;
    private void Start()
    {
        _overSpriteRenderer.enabled = false;
    }


    private void OnMouseUpAsButton()
    {


        Debug.Log("Click on pourring !" + _mixer.gameObject.transform.parent.name);

        _mixer.TriggerAnimation();
    }

    private void OnMouseOver()
    {
        _overSpriteRenderer.enabled = true;
    }

    private void OnMouseExit()
    {
        _overSpriteRenderer.enabled = false;
    }
}