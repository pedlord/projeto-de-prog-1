using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public string attackedCountry;

    public bool battleHasEnded;
    public bool battleWon;
    //adicionar um caso para checar se é IA:
    public string attackedCountrybyIA;
    public bool battleWonIA;
    public bool isIA;
    //specialattack
    public bool battleWonspecial;

    public int exp;
    public int money;
    
    [System.Serializable]
    public class SaveData
    {
        public List<Country> savedCountries = new List<Country>();
        public int cur_money;
        public int cur_exp;
    }

    void Awake()
    {
        //CountryManager.instance.Showhudpanel(money, exp);
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    public void Saving()
    {
        SaveData data = new SaveData();
        for (int i = 0; i < CountryManager.instance.countryList.Count; i++)
        {
            data.savedCountries.Add(CountryManager.instance.countryList[i].GetComponent<CountryHandler>().country);

        }
        //money e xp
        data.cur_exp = exp;
        data.cur_money = money;
        
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/SaveFile.octo", FileMode.Create);
        
        bf.Serialize(stream, data);
        stream.Close();
        print("Jogo Salvo");
    }
    public void Loading()
    {
        if (File.Exists(Application.persistentDataPath + "/SaveFile.octo"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/SaveFile.octo", FileMode.Open);

            SaveData data = (SaveData)bf.Deserialize(stream);
            stream.Close();

            for (int i = 0; i < data.savedCountries.Count; i++)
            {
                for (int j = 0; j < CountryManager.instance.countryList.Count; j++)
                {
                    if (data.savedCountries[i].name == CountryManager.instance.countryList[j].GetComponent<CountryHandler>().country.name)
                    {
                        CountryManager.instance.countryList[i].GetComponent<CountryHandler>().country = data.savedCountries[i];
                    }
                }
            }
            exp = data.cur_exp;
            money = data.cur_money;
            CountryManager.instance.Showhudpanel(money, exp);

            CountryManager.instance.Tintcountries();
            print("Jogo Carregado");
        }
        else
        {
            print("Nenhum Arquivo Salvo Encontrado");
        }
    }
    public void DeleteSaveFile()
    {
        if (File.Exists(Application.persistentDataPath + "/SaveFile.octo"))
        {
            File.Delete(Application.persistentDataPath + "/SaveFile.octo");
            print("arquivo deletado");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
