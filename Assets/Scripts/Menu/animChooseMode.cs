using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animChooseMode : MonoBehaviour
{
    [SerializeField] private Animator _animABC;
    [SerializeField] private Animator _animDigits;

    private bool _isABC = true;
    private bool _isDigits = false;

    private void Start()
    {
        PlayerPrefs.SetString("Mode", "ABC");
    }

    public void IncreaseABCMode()
    {
        if (!_isABC)
        {
            _animABC.Play("ChooseModeIncreaseABC");
            _animDigits.Play("ChooseModeDecreaseDigits");

            _animABC.SetBool("isABC", true);
            _animDigits.SetBool("isChecked", false);

            _isABC = true;
            _isDigits = false;

            PlayerPrefs.SetString("Mode", "ABC");            
        }
    }

    public void IncreaseDigitsMode ()
    {
        if (!_isDigits)
        {
            _animABC.Play("ChooseModeDecreaseABC");
            _animDigits.Play("ChooseModeIncreaseDigits");

            _animABC.SetBool("isABC", false);
            _animDigits.SetBool("isChecked", true);

            _isABC = false;
            _isDigits = true;

            PlayerPrefs.SetString("Mode", "Digits");
        }
    }

}
