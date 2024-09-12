using Entities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITeamElement : MonoBehaviour
{
    public Image Icon;
    public Text Name;
    public Text HpText;
    public GameObject Mark;

    public void SetCharacterInfo(CharBase character)
    {
        Name.text = character.define.Name;
        HpText.text = character.attributes.HP.ToString() + "/" + character.attributes.MaxHP.ToString();
    }
}
