using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class GameManager : MonoBehaviour {

    private Data data = new Data();

    [SerializeField]
    private TextMeshProUGUI valueText;

    [SerializeField]
    private TextMeshProUGUI nameText;

    [SerializeField]
    private TMP_InputField valueInput;

    [SerializeField]
    private TMP_InputField nameInput;

    [SerializeField,Tooltip("Eðer kaydet butonuna bastýktan sonra yükleme iþlemini de gerçekleþtirmek istiyorsanýz týklayýn.")]
    bool SaveToLoad;

    private void Start()
    {
        if(File.Exists("player.bin"))
        {
            Load();
        }
    }

    public void Save()
    {

        try
        {
            data.Value = Convert.ToInt32(valueInput.text);
        }
        catch (Exception e)
        {
            Debug.LogError("Lütfen Sayý Alanýný Boþ Býrakma \n\n\n" + e);
        }

         
        data.Name = nameInput.text;
        SaveLoadProcess.SaveProcess("player.bin",data);

        if(SaveToLoad)
        Load();
    }

    public void Load()
    {
        Data data =  SaveLoadProcess.LoadProcess("player.bin") as Data;

        valueText.text = data.Value.ToString();
        nameText.text = data.Name;

    }
}
