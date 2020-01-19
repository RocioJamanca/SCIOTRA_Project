using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class MapHandlerScript : MonoBehaviour
{
    [SerializeField] //OBJETO PUBLICO
    GameObject centerTileMap; // 'MapHandlerScript.centerTileMap' is never assigned to, and will always have its default value fnul

    public static int centerTileX, centerTileY; //valor de x e y que ta bajas para printar 
    //el tile (el centro de este mapa)

    public static int zoom; //el zoom con el que centro el mapa
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("MapHandlerScript");
        zoom = 15;//  15 el zoom maximo
                 //checked gps status
                 //Input.location.lastData.longitude instead 1.9875f;
                 // Input.location.lastData.latitude instead 41.275250f;   X:16579,6977864583 Y12241,6750331169
                 //WorldToTilePos(2.15f, 41.365f, zoom);
        WorldToTilePos(2.1522f, 41.3658f, zoom); //a partir de la longuitud, latitud y un zoom me calcula el tile correspondiete al centro del mapa (centretile)

       StartCoroutine(LoadTile(centerTileX, centerTileY, centerTileMap));



    }

    public static void DowlandPoint() {

        GameObject[] poiList = GameObject.FindGameObjectsWithTag("poi"); //lista de los objetos del script
        foreach (GameObject o in poiList)
        {
            Debug.Log("poiList1", o);
            o.SendMessage("MapLocation"); //envio un mensage a todos los objetos para que se situen en el mapa, nos ayuda a controlar el rden de ejecucion
        }
        
    }

    public void DownLoadCenterMapTileGps() //carga el title centrado en el GPS, antes hbra bajado un title fijo
    {
        Debug.Log("cargar mapa "+ Input.location.lastData.longitude);
        WorldToTilePos(2.15f, 41.365f, zoom);
        LoadTile(centerTileX, centerTileY, centerTileMap);        
    } 

    public void WorldToTilePos(float lon, float lat, int zoom)//baja un title centrado similar al otro con los datos que les pasa
    {
        double tileX, tileY;
        tileX = (double)((lon + 180.0f) / 360.0f * (1 << zoom));
        tileY = (double)((1.0f - Mathf.Log(Mathf.Tan((float)lat * Mathf.PI / 180.0f) + 1.0f / Mathf.Cos((float)lat * Mathf.PI / 180.0f)) / Mathf.PI) / 2.0f * (1 << zoom));
        centerTileX = Mathf.FloorToInt((float)tileX);
        centerTileY = Mathf.FloorToInt((float)tileY);
        Debug.Log("X:" + centerTileX + "    " + "Y" + centerTileY);
      
    }

    IEnumerator LoadTile(int x, int y, GameObject quadTile) //valores de x, y, mapa
    {
        Debug.Log("loadTile");
        string uri = "https://a.tile.openstreetmap.org/" + zoom + "/" + x + "/" + y + ".png"; //buscamos el mapa con la URI, con los parametros dados
        
        //CustomCertificateHandler certHandler = new CustomCertificateHandler();
        UnityWebRequest www = UnityWebRequestTexture.GetTexture("https://a.tile.openstreetmap.org/"+zoom+"/"+x+"/"+y+".png");
        //www.certificateHandler = certHandler;
        yield return www.SendWebRequest();  //espera que el servidor responda, lo que me pasa no es una imagen si no una TEXTURA    

        Debug.Log("server");
        if (www.isNetworkError || www.isHttpError){
            Debug.Log(www.error);
        }else{
            Debug.Log("Received");
            centerTileMap.GetComponent<MeshRenderer>().material.mainTexture = DownloadHandlerTexture.GetContent(www);
        } 
    }
}
