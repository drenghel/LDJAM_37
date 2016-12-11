using UnityEngine;

public class ChemicalTank : MonoBehaviour
{

    [SerializeField]
    private SpriteRenderer _overSprite;


    [SerializeField]
    private ChemicalType _containingChemicalType;


    private ScientistController _scientistController;

    // Use this for initialization
    void Start()
    {
        _overSprite.enabled = false;
        _scientistController = SceneManager.GetPlayerController();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseOver()
    {
        //Debug.Log("Hey  a mouse is over " + transform.parent.gameObject.name);
    }

    private void OnMouseEnter()
    {
        _overSprite.enabled = true;
    }

    private void OnMouseExit()
    {
        _overSprite.enabled = false;

    }

    private void OnMouseUpAsButton()
    {
        Debug.Log("Hey  someonetried to take some juice from  " + transform.parent.gameObject.name);
        if (_scientistController.BecherHeld.ContainingChemicalType == ChemicalType.Empty)
        {
            _scientistController.BecherHeld.EditBecher(_containingChemicalType);
        }
        else
        {
            //TODO Real error message
            Debug.LogError("Your becher is already full, empty it before !");
        }
    }


}
