using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;

public class ActosScript : MonoBehaviour
{
    [SerializeField]
    GameObject prefabPoint; //ActosScript.prefabPoint' is never assigned to, and will always have its default value null

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ActosScript");
        StartCoroutine("Actos");

    }
        
        
        
   IEnumerator Actos()
    {
        Debug.Log("empieza la busqueda en la base de datos");
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

            // GameObject[] poiList = GameObject.FindGameObjectsWithTag("poi");
            GameObject o = Instantiate(prefabPoint);
            Debug.Log("punto numero " + i);
            if (name  == "El Barrio")
            {
               // Debug.Log("location: " + location_id.ToString() + "," + name);
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.35f;
                o.GetComponent<PoiScript>().lonObject = 12.13f;
            }
            if (name == "Nil Moliner")
            {
                //Debug.Log("location: " + location_id.ToString() + "," + name);
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject =21.36f;
                o.GetComponent<PoiScript>().lonObject = 8.15f;
            }
            if (name == "Disney On Ice")
            {
                //Debug.Log("location: " + location_id.ToString() + "," + name);
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 11.36f;
                o.GetComponent<PoiScript>().lonObject = 5.15f;
            }
            if (name == "David Bisbal")
            {
                //Debug.Log("location: " + location_id.ToString() + "," + name);
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 31.37f;
                o.GetComponent<PoiScript>().lonObject = 2.18f;
            }
        }
        MapHandlerScript.DowlandPoint();
    }
}
