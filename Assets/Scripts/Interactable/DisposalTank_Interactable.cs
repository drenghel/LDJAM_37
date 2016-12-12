using UnityEngine;

public class DisposalTank_Interactable : Interactable
{
    protected override void Interact()
    {
        base.Interact();

        ScientistController player = MySceneManager.GetPlayerController();


        if (player.BecherHeld.ContainingChemicalType == ChemicalType.None)
        {
            //TODO Real error msg
            Debug.LogError("You have nothing to throw away :(");
        }
        else
        {
            //TODO Feedback
            player.BecherHeld.EditBecher(ChemicalType.None);
        }
    }
}