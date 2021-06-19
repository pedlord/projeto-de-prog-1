using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class CountryHandler : MonoBehaviour
{
    public Country country;

    private SpriteRenderer sprite;

    private Color32 oldColor;
    private Color32 hoverColor;
    //public Color32 startColor;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        //sprite.color = startColor;
    }
    void OnMouseEnter()
    {
        oldColor = sprite.color;
        if (country.tribe == Country.theTribes.PLAYER)
        {
            hoverColor = oldColor;
        }
        else
        {
            hoverColor = new Color32(oldColor.r, oldColor.g, oldColor.b, 190);
        }
        sprite.color = hoverColor;
    }
    void OnMouseExit()
    {
        sprite.color = oldColor;
    }
    void OnMouseUpAsButton()
    {
        //print("pressed");
        if (country.tribe != Country.theTribes.PLAYER)
        {
            ShowGUI();
        }
    }
    void OnDrawGizmos()
    {
        country.name = name;
        this.tag = "country";
    }
    public void TintColor(Color32 color)
    {
        sprite.color = color;
    }
    void ShowGUI()
    {
        CountryManager.instance.ShowAttackPanel("esse país pertence a: " + country.tribe.ToString() + ". Certeza que quer atacar essa galera?", country.moneyReward, country.expReward);
        GameManager.instance.attackedCountry = country.name;
        GameManager.instance.battleHasEnded = false;
        GameManager.instance.battleWon = false;
    }
    //adicionar um attackedcountry para IA
}
