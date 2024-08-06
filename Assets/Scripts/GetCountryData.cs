using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GetCountryData : MonoBehaviour
{
    private const string URL = "http://igc.deca.jp/country-data/country_data-get.php";
    void Start()
    {
        Debug.Log("");
        StartCoroutine(GetCountry());
    }

    IEnumerator GetCountry()
    {
        UnityWebRequest request = UnityWebRequest.Get(URL);
        yield return request.SendWebRequest();
        if (request.responseCode == 200) 
        {
            var countryData = ReShapingData(request.downloadHandler.text);
            foreach (var item in countryData)
            {
                Debug.Log($"{item.Id} {item.Name} {item.Population} {item.Area} {item.Gdp} {item.Longitude} {item.Latitude}");
            }
        }
        else 
        {
            Debug.LogError($"Bad request. error code {request.responseCode}");
        }
    }

    private List<CountryData> ReShapingData(string data)
    {
        List<CountryData> countryDatas = new List<CountryData>();
        data = data.Replace("<br>", "\n");
        var records = data.Split('\n');
        foreach (var record in records)
        {
            if(record == "") continue;
            var fields = record.Split(':');
            CountryData countryData = new CountryData();
            countryData.Set(int.Parse(fields[0]),
                            fields[1],
                            int.Parse(fields[2]),
                            int.Parse(fields[3]),
                            int.Parse(fields[4]),
                            int.Parse(fields[5]),
                            int.Parse(fields[6]));
            countryDatas.Add(countryData);
        }
        return countryDatas;
    }
}
