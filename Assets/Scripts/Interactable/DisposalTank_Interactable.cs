using UnityEngine;

public class DisposalTank_Interactable : Interactable
{
    protected override void Interact()
    {
        base.Interact();

        ScientistController player = MySceneManager.GetPlayerController();


        if (player.BecherHeld.ContainingChemicalType == ChemicalType.None)
        {
            MySceneManager.GetDialogueBox().DialogueActivate();
            MySceneManager.GetDialogueBox().SetDialogue("You have nothing to throw Away !");
        }
        else
        {
            player.BecherHeld.EditBecher(ChemicalType.None);


            MySceneManager.GetDialogueBox().DialogueActivate();
            MySceneManager.GetDialogueBox().SetDialogue("You threw away your becher");
        }
    }
}