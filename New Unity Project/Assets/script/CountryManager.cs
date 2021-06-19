using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CountryManager : MonoBehaviour
{
    public static CountryManager instance;

    public GameObject attackPanel;
    public GameObject hud;
    

    public List<GameObject> countryList = new List<GameObject>();

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        hud.SetActive(true);
        attackPanel.SetActive(false);
        AddCountryData();
        if (GameManager.instance.battleHasEnded && GameManager.instance.battleWon)
        {
            print("eu ataquei");
            CountryHandler count = GameObject.Find(GameManager.instance.attackedCountry).GetComponent<CountryHandler>();
            count.country.tribe = Country.theTribes.PLAYER;
            GameManager.instance.exp += count.country.expReward;
            GameManager.instance.money += count.country.moneyReward;
            Tintcountries();
        }
        else if (GameManager.instance.battleHasEnded && GameManager.instance.battleWonspecial)
        {
            print("eu ataquei special");
            CountryHandler cout = GameObject.Find(GameManager.instance.attackedCountry).GetComponent<CountryHandler>();
            cout.country.tribe = Country.theTribes.PLAYER;
            GameManager.instance.exp -= 100;
            
            Tintcountries();
        }
        else if (GameManager.instance.battleHasEnded && GameManager.instance.battleWonIA && GameManager.instance.isIA)
        {
            print("IA venceu");
            print(GameManager.instance.attackedCountrybyIA);
            //detectar o pais atacado pela IA
            CountryHandler cunt = GameObject.Find(GameManager.instance.attackedCountrybyIA).GetComponent<CountryHandler>();
            print(cunt);
            cunt.country.tribe = Country.theTribes.GANGS;
            Tintcountries();
        }
        GameManager.instance.Saving();
        //adicionar um caso para IA conquistando
    }
    void AddCountryData()
    {
        GameObject[] theArray = GameObject.FindGameObjectsWithTag("country") as GameObject[];
        foreach (GameObject country in theArray)
        {
            countryList.Add(country);
        }
        GameManager.instance.Loading();
        Tintcountries();
    }
    public void Tintcountries()
    {
        for (int i = 0; i < countryList.Count; i++) 
        {
            CountryHandler countHandler = countryList[i].GetComponent<CountryHandler>();
            if (countHandler.country.tribe == Country.theTribes.BADS)
            {
                countHandler.TintColor(new Color32(255,0,0,128));
            }
            if (countHandler.country.tribe == Country.theTribes.GANGS)
            {
                countHandler.TintColor(new Color32(255, 17, 0, 128));
            }
            if (countHandler.country.tribe == Country.theTribes.HUNTERS)
            {
                countHandler.TintColor(new Color32(0, 255, 0, 128));
            }
            if (countHandler.country.tribe == Country.theTribes.NORDS)
            {
                countHandler.TintColor(new Color32(255, 0, 255, 128));
            }
            if (countHandler.country.tribe == Country.theTribes.PLAYER)
            {
                countHandler.TintColor(new Color32(255, 255, 255, 255));
            }
        }
    }
    public void ShowAttackPanel(string description, int moneyReward, int expReward)
    {
        hud.SetActive(false);
        attackPanel.SetActive(true);
        AttackPanel gui = attackPanel.GetComponent<AttackPanel>();
        gui.descriptionText.text = description;
        gui.MoneyRewardText.text = "dinheiro: +" + moneyReward.ToString();
        gui.ExpRewardText.text = "experiencia: +" + expReward.ToString();
    }
    public void DisableAttackPanel()
    {
        attackPanel.SetActive(false);
        hud.SetActive(true);
    }
    public void Showhudpanel(int infodinheiro, int infoexp)
    {
        //hud.SetActive(true);
        HUD g = hud.GetComponent<HUD>();
        g.MoneyRewardText.text = "dinheiro: " + infodinheiro.ToString();
        g.ExpRewardText.text = "Experiência: " + infoexp.ToString();
    }
    public void BackMenu() 
    {
        SceneManager.LoadScene("Menu");
    }
    public void StartFight()
    {
        SceneManager.LoadScene("Fight");
    }
    public void Specialattack() 
    {
        if (GameManager.instance.exp > 0)
            SceneManager.LoadScene("FightSpecial");
        else
            print("sem experiência suficiente");
    }
}
