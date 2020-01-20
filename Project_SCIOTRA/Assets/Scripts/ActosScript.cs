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
        string big_image;
        string horario;
        string title;
        string description;

        for (var i = 0; i < chargePoints.Count; i++)
        {
            JObject chargePoint = (JObject)chargePoints.GetItem(i);
            uid = (int)chargePoint["uid"];
            name = (string)chargePoint["name"];
            location_id = (int)chargePoint["location_id"];
            big_image = (string)chargePoint["big_image"];
            description = (string)chargePoint["description"];
            title = (string)chargePoint["title"];
            horario = description.Substring(0, description.IndexOf('<')); //eliminamos toda la descripcion de la base de datos que no sea la hora
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
                o.GetComponent<PoiScript>().imagen = big_image;
                o.GetComponent<PoiScript>().hora = horario;
                o.GetComponent<PoiScript>().titulo = title;
            }
            else if (name == "El Barrio")
            {
                // Debug.Log("location: " + location_id.ToString() + "," + name);
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.365532;
                o.GetComponent<PoiScript>().lonObject = 2.143303;
                o.GetComponent<PoiScript>().imagen = big_image;
                o.GetComponent<PoiScript>().hora = horario;
                o.GetComponent<PoiScript>().titulo = title;
            }
            else if (name == "Disney On Ice")
            {
                //Debug.Log("location: " + location_id.ToString() + "," + name);
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.364274;
                o.GetComponent<PoiScript>().lonObject = 2.151725;
                o.GetComponent<PoiScript>().imagen = big_image;
                o.GetComponent<PoiScript>().hora = horario;
                o.GetComponent<PoiScript>().titulo = title;
            }          
            else if (name == "Nil Moliner")
            {
                //Debug.Log("location: " + location_id.ToString() + "," + name);
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject =41.361127;
                o.GetComponent<PoiScript>().lonObject = 2.145179;
                o.GetComponent<PoiScript>().imagen = big_image;
                o.GetComponent<PoiScript>().hora = horario;
                o.GetComponent<PoiScript>().titulo = title;
            }
            else if (name == "Serrat & Sabina") {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.366032; 
                o.GetComponent<PoiScript>().lonObject = 2.143303;
                o.GetComponent<PoiScript>().imagen = big_image;
                o.GetComponent<PoiScript>().hora = horario;
                o.GetComponent<PoiScript>().titulo = title;
            }
            else if (name == "Hatsune Miku" & name == "Hatsune Miku VIP")
            {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.266666;
                o.GetComponent<PoiScript>().lonObject = 2.143420;
                o.GetComponent<PoiScript>().imagen = big_image;
                o.GetComponent<PoiScript>().hora = horario;
                o.GetComponent<PoiScript>().titulo = title;
            }
            else if (name == "Dream Theater") {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.301127;
                o.GetComponent<PoiScript>().lonObject = 2.143579;
                o.GetComponent<PoiScript>().imagen = big_image;
                o.GetComponent<PoiScript>().hora = horario;
                o.GetComponent<PoiScript>().titulo = title;
            }
            else if (name == "Trial Indoor") {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.281127;
                o.GetComponent<PoiScript>().lonObject = 2.1436911;
                o.GetComponent<PoiScript>().imagen = big_image;
                o.GetComponent<PoiScript>().hora = horario;
                o.GetComponent<PoiScript>().titulo = title;
            }
            else if (name == "Sabaton")
            {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.311127;
                o.GetComponent<PoiScript>().lonObject = 2.143779; o.GetComponent<PoiScript>().imagen = big_image;
                o.GetComponent<PoiScript>().hora = horario;
                o.GetComponent<PoiScript>().titulo = title;
            }
            else if (name == "Halsey")
            {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.341127;
                o.GetComponent<PoiScript>().lonObject = 2.143879; o.GetComponent<PoiScript>().imagen = big_image;
                o.GetComponent<PoiScript>().hora = horario;
                o.GetComponent<PoiScript>().titulo = title;
            }
            else if (name == "FernandoCosta")
            {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.269999;
                o.GetComponent<PoiScript>().lonObject = 2.143979; o.GetComponent<PoiScript>().imagen = big_image;
                o.GetComponent<PoiScript>().hora = horario;
                o.GetComponent<PoiScript>().titulo = title;
            }
            else if (name == "Arnau Griso")
            {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.364127;
                o.GetComponent<PoiScript>().lonObject = 2.152079; o.GetComponent<PoiScript>().imagen = big_image;
                o.GetComponent<PoiScript>().hora = horario;
                o.GetComponent<PoiScript>().titulo = title;
            }
            else if (name == "Jonas Brothers")
            {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.361127;
                o.GetComponent<PoiScript>().lonObject = 2.144179; o.GetComponent<PoiScript>().imagen = big_image;
                o.GetComponent<PoiScript>().hora = horario;
                o.GetComponent<PoiScript>().titulo = title;
            }
            else if (name == "Izal")
            {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.291127;
                o.GetComponent<PoiScript>().lonObject = 2.144279; o.GetComponent<PoiScript>().imagen = big_image;
                o.GetComponent<PoiScript>().hora = horario;
                o.GetComponent<PoiScript>().titulo = title;
            }
            else if (name == "AbroadFest")
            {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.361127;
                o.GetComponent<PoiScript>().lonObject = 2.144379; o.GetComponent<PoiScript>().imagen = big_image;
                o.GetComponent<PoiScript>().hora = horario;
                o.GetComponent<PoiScript>().titulo = title;
            }
            
            else if (name == "Chayanne")
            {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.361127;
                o.GetComponent<PoiScript>().lonObject = 2.151479; o.GetComponent<PoiScript>().imagen = big_image;
                o.GetComponent<PoiScript>().hora = horario;
                o.GetComponent<PoiScript>().titulo = title;
            }
            else if (name == "Fangoria")
            {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.271127;
                o.GetComponent<PoiScript>().lonObject = 2.144579; o.GetComponent<PoiScript>().imagen = big_image;
                o.GetComponent<PoiScript>().hora = horario;
                o.GetComponent<PoiScript>().titulo = title;
            }
            else if (name == "Nickcare")
            {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.361127;
                o.GetComponent<PoiScript>().lonObject = 2.152525; o.GetComponent<PoiScript>().imagen = big_image;
                o.GetComponent<PoiScript>().hora = horario;
                o.GetComponent<PoiScript>().titulo = title;
            }
            else if (name == "DuaLipa") {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.374274;
                o.GetComponent<PoiScript>().lonObject = 2.144725; o.GetComponent<PoiScript>().imagen = big_image;
                o.GetComponent<PoiScript>().hora = horario;
                o.GetComponent<PoiScript>().titulo = title;
            }
            else if (name == "Maldina Nerea") {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.364274;
                o.GetComponent<PoiScript>().lonObject = 2.144825; o.GetComponent<PoiScript>().imagen = big_image;
                o.GetComponent<PoiScript>().hora = horario;
                o.GetComponent<PoiScript>().titulo = title;
            }
            else if (name == "Carlos Sadness") {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.364274;
                o.GetComponent<PoiScript>().lonObject = 2.144925; o.GetComponent<PoiScript>().imagen = big_image;
                o.GetComponent<PoiScript>().hora = horario;
                o.GetComponent<PoiScript>().titulo = title;
            }
            else if (name == "Ru Paul's Drag Race") {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.364274;
                o.GetComponent<PoiScript>().lonObject = 2.145125; o.GetComponent<PoiScript>().imagen = big_image;
                o.GetComponent<PoiScript>().hora = horario;
                o.GetComponent<PoiScript>().titulo = title;
            }
            else if (name == "Beret") {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.364274;
                o.GetComponent<PoiScript>().lonObject = 2.14525; o.GetComponent<PoiScript>().imagen = big_image;
                o.GetComponent<PoiScript>().hora = horario;
                o.GetComponent<PoiScript>().titulo = title;
            }
            else if (name == "Manuel Carrasco") {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.364274;
                o.GetComponent<PoiScript>().lonObject = 2.145725; o.GetComponent<PoiScript>().imagen = big_image;
                o.GetComponent<PoiScript>().hora = horario;
                o.GetComponent<PoiScript>().titulo = title;
            }
            else if (name == "Paul McCartneg") {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.364274;
                o.GetComponent<PoiScript>().lonObject = 2.151925; o.GetComponent<PoiScript>().imagen = big_image;
                o.GetComponent<PoiScript>().hora = horario;
                o.GetComponent<PoiScript>().titulo = title;
            }
            else if (name == "Iron Maiden") {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.364274;
                o.GetComponent<PoiScript>().lonObject = 2.146725; o.GetComponent<PoiScript>().imagen = big_image;
                o.GetComponent<PoiScript>().hora = horario;
                o.GetComponent<PoiScript>().titulo = title;
            }

            else if (name == "Tash Sultana") {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.364274;
                o.GetComponent<PoiScript>().lonObject = 2.151825; o.GetComponent<PoiScript>().imagen = big_image;
                o.GetComponent<PoiScript>().hora = horario;
                o.GetComponent<PoiScript>().titulo = title;
            }
            else if (name == "EltonJohn 2/10/2020") {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.364274;
                o.GetComponent<PoiScript>().lonObject = 2.143125; o.GetComponent<PoiScript>().imagen = big_image;
                o.GetComponent<PoiScript>().hora = horario;
                o.GetComponent<PoiScript>().titulo = title;
            }
            else if (name == "The 1975") {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.364274;
                o.GetComponent<PoiScript>().lonObject = 2.151625; o.GetComponent<PoiScript>().imagen = big_image;
                o.GetComponent<PoiScript>().hora = horario;
                o.GetComponent<PoiScript>().titulo = title;
            }
            else if (name == "Dani Martin") {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.364274;
                o.GetComponent<PoiScript>().lonObject = 2.151425; o.GetComponent<PoiScript>().imagen = big_image;
                o.GetComponent<PoiScript>().hora = horario;
                o.GetComponent<PoiScript>().titulo = title;
            }
            else if (name == "Helloween") {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.364274;
                o.GetComponent<PoiScript>().lonObject = 2.152125; o.GetComponent<PoiScript>().imagen = big_image;
                o.GetComponent<PoiScript>().hora = horario;
                o.GetComponent<PoiScript>().titulo = title;
            }
            else if (name == "Nill Moliner") {
                o.GetComponent<PoiScript>().descrip = name;
                o.GetComponent<PoiScript>().latObject = 41.364274;
                o.GetComponent<PoiScript>().lonObject = 2.148725; o.GetComponent<PoiScript>().imagen = big_image;
                o.GetComponent<PoiScript>().hora = horario;
                o.GetComponent<PoiScript>().titulo = title;
            }
            else{
                Debug.Log("MAL"+ name);
            }



        }
        MapHandlerScript.DowlandPoint();
    }
}
