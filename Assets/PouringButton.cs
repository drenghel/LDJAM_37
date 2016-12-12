using UnityEngine;

public class PouringButton : MonoBehaviour
{


    //todo should be a child class 


    [SerializeField] SpriteRenderer _overSpriteRenderer;
    [SerializeField] private MixerAnimationsHandling _mixerAnimationsHandling;

    private void Start()
    {
        _overSpriteRenderer.enabled = false;
    }


    private void OnMouseUpAsButton()
    {
        Debug.Log("Click on pourring !" + _mixerAnimationsHandling.gameObject.transform.parent.name);
        PlayerBecher playerBecher = MySceneManager.GetPlayerController().BecherHeld;


        if (playerBecher.ContainingChemicalType != ChemicalType.None)
        {
            _mixerAnimationsHandling.TriggerAnimation(playerBecher.CurrentLiquidColor);

        }
        else
        {
            //TODO proper feedback
            Debug.LogError("You have no becher to pour in the machine !");
        }
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