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
        string res =
            " Well I don't even know how you can see this message... Contact a dev and tell him he sucks please :D";

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

            //defaut:
            //throw new UnityException("Could handle result calculations !");
            //break;
        }

        MySceneManager.GetDialogueBox().SetDialogue(res);
        MySceneManager.GetDialogueBox().DialogueActivate();
    }

    private string GiveResult(Color playerBecherCurrentLiquidColor /*, out float percentScore*/)
    {
        Vector4 diffColor = playerBecherCurrentLiquidColor - _solutionColor;


        float score = Math.Abs(diffColor.x) + Math.Abs(diffColor.y) +
                      Math.Abs(diffColor.z);

        float diffAlpha = Mathf.Abs(diffColor.w);

        if (score < 0.001f && diffAlpha < 0.001f)
        {
            return "THAT'S IT, THAT LOOKS PERFECT !";
        }
        if (score < 0.001)
        {
            return
                "God, it's really effective, but I wonder if it could be safer for humans ? Looks like it only needs one last operation...";
        }

        if (score > 0.01f)
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

        SetSolutionColor();
    }


    private void SetSolutionColor()
    {
        //todo to replace with base color
        _solutionColor = BecherList.CombineColors(Color.blue, Color.red, Color.white);
    }

#if UNITY_EDITOR || UNITY_EDITOR_64 || UNITY_EDITOR_WIN
    private void OnGUI()
    {
        int xSize = 50;
        if (GUI.Button(new Rect(0, 0, xSize, 20), "Solution"))
        {
            _playerBecher.EditBecher(ChemicalType.Mixed);
            _playerBecher.CurrentLiquidColor = _solutionColor;
        }
        if (GUI.Button(new Rect(xSize, 0, xSize, 20), "blue"))
        {
            _playerBecher.EditBecher(ChemicalType.Blue);
        }
        if (GUI.Button(new Rect(xSize*2, 0, xSize, 20), "red"))
        {
            _playerBecher.EditBecher(ChemicalType.Red);
        }
        if (GUI.Button(new Rect(xSize*3, 0, xSize, 20), "custom"))
        {
            _playerBecher.EditBecher(ChemicalType.Mixed);
            _playerBecher.CurrentLiquidColor = BecherList.CombineColors(Color.blue, Color.white);
        }
    }
#endif
}