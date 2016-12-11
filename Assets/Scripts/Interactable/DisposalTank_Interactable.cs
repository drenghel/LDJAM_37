using UnityEngine;

public class DisposalTank_Interactable : Interactable
{
    protected override void Interact()
    {
        base.Interact();

        ScientistController player = SceneManager.GetPlayerController();


        if (player.BecherHeld.ContainingChemicalType == ChemicalType.Empty)
        {
            //TODO Real error msg
            Debug.LogError("Your becher is empty you can't empty it !");
        }
        else
        {
            //TODO Feedback
            player.BecherHeld.Editbecher(ChemicalType.Empty);
        }
    }
}