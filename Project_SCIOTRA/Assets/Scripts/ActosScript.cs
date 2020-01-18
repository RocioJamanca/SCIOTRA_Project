using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;

public class ActosScript : MonoBehaviour
{
    [SerializeField]
    GameObject prefabPoint;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ActosScript");
        StartCoroutine("Actos");
      
    }

    IEnumerator Actos()
    {
        WWW www = new WWW("https://api.bsmsa.eu/ext/api/ao/waos/es/actosanella.json");
        yield return www;

        JObject obj = JObject.Parse(www.text);
        JArray chargePoints = (JArray)obj["actes"]["acte"];
       Debug.Log("Number chargePoints: " + chargePoints.Count);
        int uid;
        string name;
        int location_id;

        for (var i = 0; i < chargePoints.Count; i++)
        {
            JObject chargePoint = (JObject)chargePoints.GetItem(i);
            uid = (int)chargePoint["uid"];
            name = (string)chargePoint["name"];
            location_id = (int)chargePoint["location_id"]; 
           // Debug.Log("Lista de puntos: "+ uid.ToString() + "," + name);

            GameObject o = Instantiate(prefabPoint);
            
            if (location_id == 1)
            {
              // Debug.Log("location: " + location_id.ToString() + "," + name);
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.363685;
                o.GetComponent<PoiScript>().lonObject = 2.152560;
            }
            if (location_id == 2)
            {
              //Debug.Log("location: " + location_id.ToString() + "," + name);
               o.GetComponent<PoiScript>().descrip = name;
               o.GetComponent<PoiScript>().latObject = 41.365601;
               o.GetComponent<PoiScript>().lonObject = 2.152603;
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
