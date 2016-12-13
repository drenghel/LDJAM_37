using System;
using System.Text;
using UnityEngine;

public class Microscope : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _overSpriteRenderer;

    Color _solutionColor;


    private PlayerBecher _playerBecher;
    //TODO should be a child class

    private void OnMouseUpAsButton()
    {
        string res;

        switch (_playerBecher.ContainingChemicalType)
        {
            case ChemicalType.None:
                res = "I don't have any Becher, so I can't try out an antidote on the zombie blood sample!";
                break;
            case ChemicalType.Base:
                res =
                    "That's just some base solution my colleagues produced before their zombification, that won't suffice !";
                break;
            case ChemicalType.Mixed:
                res = GiveResult(_playerBecher.CurrentLiquidColor);
                break;
            case ChemicalType.Blue:
                res =
                    "That's just some blue [INSERT COMPLICATED CHEMISTRY THING], that's not even remotely effective!";
                break;
            case ChemicalType.Red:
                res =
                    "That's just some Red [INSERT COMPLICATED CHEMISTRY THING], that's not even remotely effective!";
                break;
            case ChemicalType.Green:
                res =
                    "That's just some Green [INSERT COMPLICATED CHEMISTRY THING], that's not even remotely effective! (Smeels nice tho) ";
                break;

                defaut:
                throw new UnityException("Could handle result calculations !");
                break;
        }

        MySceneManager.GetDialogueBox().SetDialogue("res");
        MySceneManager.GetDialogueBox().DialogueActivate();
    }

    private string GiveResult(Color playerBecherCurrentLiquidColor /*, out float percentScore*/)
    {
        Color diffColor = playerBecherCurrentLiquidColor - _solutionColor;


        var score = (int) Mathf.Abs(diffColor.r) + (int) Mathf.Abs(diffColor.g) +
                    (int) Mathf.Abs(diffColor.b);

        float diffAlpha = Mathf.Abs(diffColor.a);

        if (score == 0)
        {
            return "THAT'S IT, THAT LOOKS PERFECT !";
        }
        if (score > 0 && Math.Abs(diffAlpha) < 0.001f)
        {
            return
                "God, it's really effective, but I wonder if it could be safer for humans ? Looks like it only needs one last operation...";
        }

        if (score > 10)
        {
            return "Nah that's not it ...";
        }

        //float percentScore = score*100;

        throw new UnityException("Could handle result calculations !");
    }


    private void OnMouseOver()
    {
        _overSpriteRenderer.enabled = true;
    }

    private void OnMouseExit()
    {
        _overSpriteRenderer.enabled = false;
    }


    void Start()
    {
        _overSpriteRenderer.enabled = false;

        _playerBecher = MySceneManager.GetPlayerController().BecherHeld;
        //GivePlayerABecher();

        SetSolutionColor();
    }

    private void GivePlayerABecher()
    {
        throw new System.NotImplementedException();
    }

    private void SetSolutionColor()
    {
    }
}