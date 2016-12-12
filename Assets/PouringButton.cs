using UnityEngine;

public class PouringButton : MonoBehaviour
{
    [SerializeField] SpriteRenderer _overSpriteRenderer;
    [SerializeField] private MixerAnimationsHandling _mixerAnimationsHandling;
    private void Start()
    {
        _overSpriteRenderer.enabled = false;
    }


    private void OnMouseUpAsButton()
    {


        Debug.Log("Click on pourring !" + _mixerAnimationsHandling.gameObject.transform.parent.name);

        _mixerAnimationsHandling.TriggerAnimation();
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