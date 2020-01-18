using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


    public class PoiScript : MonoBehaviour
    { //parametros del obejt, latutud. longutud y la descripcion (cooredenadas del objeto)
        [SerializeField]
        public double latObject;
        [SerializeField]
        public double lonObject;
        [SerializeField]
        public string descrip;
        
            GameObject Description;

        // Start is called before the first frame update
        void Start()
        {
            Debug.Log("PoiScript");
            Description = GameObject.Find("Description"); //busca un objeto que no exsite (Description)
        }

        public void MapLocation() //localizan y centran el mapa
        {   //las map handeler contiene las variables estaticas del mapa 
            int x = MapHandlerScript.centerTileX;
            int y = MapHandlerScript.centerTileY;
            int zoom = MapHandlerScript.zoom;
        
            Debug.Log("datos para centrar el MAPA"+ x+y+zoom);//no pasa por aqui¿?

            double a = DrawCubeX(lonObject, TileToWorldPos(x, y, zoom).X, TileToWorldPos(x + 1, y, zoom).X);
            double b = DrawCubeY(latObject, TileToWorldPos(x, y + 1, zoom).Y, TileToWorldPos(x, y, zoom).Y);
            //TileToWo.. dado un tile y un zoom da la longutud y la latitud de la esquina izqueida superior del title.
            //para calcular en que title estarian los obejtos, me quedo en un caso la x y la y. 
            //lo hago dos veces para tener las las maximas y minimas de la parte x e y. 

            Debug.Log(" Pos" + a + "/" + b);
            this.transform.position = new Vector3((float)a - 0.5f, (float)b - 0.5f, 0.0f);
        } // el mapa se centra en el centro por eso se tranforma dividiendolo por dos
        public struct Point
        {
            public double X;
            public double Y;
        }
        // p.X -> longitud
        // p.Y -> latitud
        // left upper corner

        public Point TileToWorldPos(double tile_x, double tile_y, int zoom)
        {
            Point p = new Point();
            double n = System.Math.PI - ((2.0 * System.Math.PI * tile_y) / System.Math.Pow(2.0, zoom));

            p.X = ((tile_x / System.Math.Pow(2.0, zoom) * 360.0) - 180.0);
            p.Y = (180.0 / System.Math.PI * System.Math.Atan(System.Math.Sinh(n)));

            return p;
        }

        //Funciones para printar los objetos que estan determinados, hay dos porque dibuja priemro x y luego y
        public double DrawCubeY(double targetLat, double minLat, double maxLat)
        {
            double pixelY = ((targetLat - minLat) / (maxLat - minLat));
            return pixelY;
        }

        public double DrawCubeX(double targetLong, double minLong, double maxLong)
        {
            double pixelX = ((targetLong - minLong) / (maxLong - minLong));
            return pixelX;
        }

        public void SetUnpressedColor()
        {
            this.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        public void OnMouseDown() //Clickme cambia de rojo a azul cuando clicas el objeto,
        {
            GameObject[] poiList = GameObject.FindGameObjectsWithTag("poi");
            foreach (GameObject o in poiList)
            {
                o.SendMessage("SetUnpressedColor");
            }
            this.GetComponent<MeshRenderer>().material.color = Color.blue;   //lo que hace es poner a todos rojos y el clicado azul. En el fondo cambia en color de todos
            Description.GetComponent<Text>().text = descrip; // ademas pone la descripcion de este en el text. 
        }
    }