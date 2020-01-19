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
            if (name == "David Bisbal")
            {
                //Debug.Log("location: " + location_id.ToString() + "," + name);
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.363890; //no tocar
                o.GetComponent<PoiScript>().lonObject = 2.152037; //no tocas
            }
            else if (name == "El Barrio")
            {
                // Debug.Log("location: " + location_id.ToString() + "," + name);
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.365532;
                o.GetComponent<PoiScript>().lonObject = 2.143303;
            }
            else if (name == "Disney On Ice")
            {
                //Debug.Log("location: " + location_id.ToString() + "," + name);
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.364274;
                o.GetComponent<PoiScript>().lonObject = 2.151725;
            }          
            else if (name == "Nil Moliner")
            {
                //Debug.Log("location: " + location_id.ToString() + "," + name);
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject =41.361127;
                o.GetComponent<PoiScript>().lonObject = 2.145179;
            }
            else if (name == "Serrat & Sabina") {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.366032; 
                o.GetComponent<PoiScript>().lonObject = 2.143303; 
            }
            else if (name == "Hatsune Miku" & name == "Hatsune Miku VIP")
            {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.266666;
                o.GetComponent<PoiScript>().lonObject = 2.143420;
            }
            else if (name == "Dream Theater") {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.301127;
                o.GetComponent<PoiScript>().lonObject = 2.143579;
            }
            else if (name == "Trial Indoor") {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.281127;
                o.GetComponent<PoiScript>().lonObject = 2.1436911;
            }
            else if (name == "Sabaton")
            {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.311127;
                o.GetComponent<PoiScript>().lonObject = 2.143779;
            }
            else if (name == "Halsey")
            {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.341127;
                o.GetComponent<PoiScript>().lonObject = 2.143879; }
            else if (name == "FernandoCosta")
            {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.269999;
                o.GetComponent<PoiScript>().lonObject = 2.143979;
            }
            else if (name == "Arnau Griso")
            {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.364127;
                o.GetComponent<PoiScript>().lonObject = 2.152079;
            }
            else if (name == "Jonas Brothers")
            {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.361127;
                o.GetComponent<PoiScript>().lonObject = 2.144179; }
            else if (name == "Izal")
            {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.291127;
                o.GetComponent<PoiScript>().lonObject = 2.144279;
            }
            else if (name == "AbroadFest")
            {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.361127;
                o.GetComponent<PoiScript>().lonObject = 2.144379; }
            
            else if (name == "Chayanne")
            {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.361127;
                o.GetComponent<PoiScript>().lonObject = 2.151479; }
            else if (name == "Fangoria")
            {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.271127;
                o.GetComponent<PoiScript>().lonObject = 2.144579; }
            else if (name == "Nickcare")
            {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.361127;
                o.GetComponent<PoiScript>().lonObject = 2.152525;
            }
            else if (name == "DuaLipa") {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.374274;
                o.GetComponent<PoiScript>().lonObject = 2.144725;
            }
            else if (name == "Maldina Nerea") {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.364274;
                o.GetComponent<PoiScript>().lonObject = 2.144825;
            }
            else if (name == "Carlos Sadness") {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.364274;
                o.GetComponent<PoiScript>().lonObject = 2.144925;
            }
            else if (name == "Ru Paul's Drag Race") {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.364274;
                o.GetComponent<PoiScript>().lonObject = 2.145125;
            }
            else if (name == "Beret") {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.364274;
                o.GetComponent<PoiScript>().lonObject = 2.14525;
            }
            else if (name == "Manuel Carrasco") {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.364274;
                o.GetComponent<PoiScript>().lonObject = 2.145725;
            }
            else if (name == "Paul McCartneg") {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.364274;
                o.GetComponent<PoiScript>().lonObject = 2.151925;
            }
            else if (name == "Iron Maiden") {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.364274;
                o.GetComponent<PoiScript>().lonObject = 2.146725;
            }

            else if (name == "Tash Sultana") {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.364274;
                o.GetComponent<PoiScript>().lonObject = 2.151825;
            }
            else if (name == "EltonJohn 2/10/2020") {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.364274;
                o.GetComponent<PoiScript>().lonObject = 2.143125;
            }
            else if (name == "The 1975") {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.364274;
                o.GetComponent<PoiScript>().lonObject = 2.151625;
            }
            else if (name == "Dani Martin") {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.364274;
                o.GetComponent<PoiScript>().lonObject = 2.151425;
            }
            else if (name == "Helloween") {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.364274;
                o.GetComponent<PoiScript>().lonObject = 2.152125;
            }
            else if (name == "Nill Moliner") {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.364274;
                o.GetComponent<PoiScript>().lonObject = 2.148725;
            }
            else{
                Debug.Log("MAL"+ name);
            }



        }
        MapHandlerScript.DowlandPoint();
    }
}
