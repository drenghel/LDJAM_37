using System.Diagnostics;
using UnityEngine.SceneManagement;

public class EndingTube : Interactable
{
    protected override void Interact()
    {
        base.Interact();

        ScientistController player = MySceneManager.GetPlayerController();


        if (player.BecherHeld.ContainingChemicalType == ChemicalType.None)
        {
            MySceneManager.GetDialogueBox().DialogueActivate();
            MySceneManager.GetDialogueBox().SetDialogue("You have nothing to send in the base !");
        }
        else
        {
            MySceneManager.GetDialogueBox().DialogueActivate();
            string foo;
            Microscope.GiveResult(player.BecherHeld.CurrentLiquidColor, out foo);
            MySceneManager.GetDialogueBox().SetDialogue("You sended your antidote in the base  ! ");
            MySceneManager.GetDialogueBox().DialogueActivate(inSec: 5);
            MySceneManager.GetDialogueBox().SetDialogue(foo);


            Invoke("LoadMenu", 15);
        }
    }


    void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}