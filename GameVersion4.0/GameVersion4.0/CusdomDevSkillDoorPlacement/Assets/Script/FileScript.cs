using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.ComponentModel;
using System.Text;
using System.IO;
using System.Net;
using UnityEngine.SceneManagement;


public class FileScript : MonoBehaviour
{
    public static List<List<Transform>> tempListList;
    public static float time;
    static bool flag = true;
    static bool headFlag = false;

    void Awake()
    {
        flag = true;
    }
    // Use this for initialization
    void Start()
    {
        flag = true;
        headFlag = false;
        tempListList = new List<List<Transform>>();
        time = 0;
    }

    // Update is called once per frame

    public static void createXML()
    {
        if (flag)
        {

            flag = false;
            if (!File.Exists("C:\\Users\\Public\\Documents\\Unity Projects\\GameVersion4.0\\CusdomDevSkillDoorPlacement\\Assets\\XMLDocs\\" + SceneManager.GetActiveScene().name + ".xml"))
            {
                FileStream s = new FileStream("C:\\Users\\Public\\Documents\\Unity Projects\\GameVersion4.0\\CusdomDevSkillDoorPlacement\\Assets\\XMLDocs\\" + SceneManager.GetActiveScene().name + ".xml", FileMode.Append, FileAccess.Write);
                XmlTextWriter xwriter = new XmlTextWriter(s, Encoding.UTF8);
                xwriter.Formatting = Formatting.Indented;
                xwriter.WriteStartDocument();
                xwriter.WriteStartElement("document");
                xwriter.WriteStartElement("User-Data");
                xwriter.WriteStartElement("Player-ID");
                xwriter.WriteString(nameStore.name);
                xwriter.WriteEndElement();
                xwriter.WriteStartElement("Walls");

                int count = 1;
                foreach (Transform wall in tempListList[0])
                {
                    xwriter.WriteStartElement("Wall");
                    xwriter.WriteStartElement("Wall-No");
                    xwriter.WriteString(count.ToString());
                    xwriter.WriteEndElement();
                    xwriter.WriteStartElement("Position");
                    xwriter.WriteStartElement("X");
                    xwriter.WriteString(wall.position.x.ToString());
                    xwriter.WriteEndElement();
                    xwriter.WriteStartElement("Y");
                    xwriter.WriteString(wall.position.y.ToString());
                    xwriter.WriteEndElement();
                    xwriter.WriteStartElement("Z");
                    xwriter.WriteString(wall.position.z.ToString());
                    xwriter.WriteEndElement();
                    xwriter.WriteEndElement();

                    xwriter.WriteStartElement("Rotation");
                    xwriter.WriteStartElement("X");
                    xwriter.WriteString(wall.rotation.x.ToString());
                    xwriter.WriteEndElement();
                    xwriter.WriteStartElement("Y");
                    xwriter.WriteString(wall.rotation.y.ToString());
                    xwriter.WriteEndElement();
                    xwriter.WriteStartElement("Z");
                    xwriter.WriteString(wall.rotation.z.ToString());
                    xwriter.WriteEndElement();
                    xwriter.WriteEndElement();

                    xwriter.WriteStartElement("Scale");
                    xwriter.WriteStartElement("X");
                    xwriter.WriteString(wall.localScale.x.ToString());
                    xwriter.WriteEndElement();
                    xwriter.WriteStartElement("Y");
                    xwriter.WriteString(wall.localScale.y.ToString());
                    xwriter.WriteEndElement();
                    xwriter.WriteStartElement("Z");
                    xwriter.WriteString(wall.localScale.z.ToString());
                    xwriter.WriteEndElement();
                    xwriter.WriteEndElement();
                    xwriter.WriteEndElement();
                    count++;
                }

                xwriter.WriteEndElement();

                count = 0;
                xwriter.WriteStartElement("Doors");

                foreach (Transform door in tempListList[1])
                {
                    xwriter.WriteStartElement("Door");
                    xwriter.WriteStartElement("Door-No");
                    xwriter.WriteString(count.ToString());
                    xwriter.WriteEndElement();
                    xwriter.WriteStartElement("Position");
                    xwriter.WriteStartElement("X");
                    xwriter.WriteString(door.position.x.ToString());
                    xwriter.WriteEndElement();
                    xwriter.WriteStartElement("Y");
                    xwriter.WriteString(door.position.y.ToString());
                    xwriter.WriteEndElement();
                    xwriter.WriteStartElement("Z");
                    xwriter.WriteString(door.position.z.ToString());
                    xwriter.WriteEndElement();
                    xwriter.WriteEndElement();

                    xwriter.WriteStartElement("Rotation");
                    xwriter.WriteStartElement("X");
                    xwriter.WriteString(door.rotation.x.ToString());
                    xwriter.WriteEndElement();
                    xwriter.WriteStartElement("Y");
                    xwriter.WriteString(door.rotation.y.ToString());
                    xwriter.WriteEndElement();
                    xwriter.WriteStartElement("Z");
                    xwriter.WriteString(door.rotation.z.ToString());
                    xwriter.WriteEndElement();
                    xwriter.WriteEndElement();

                    xwriter.WriteStartElement("Scale");
                    xwriter.WriteStartElement("X");
                    xwriter.WriteString(door.localScale.x.ToString());
                    xwriter.WriteEndElement();
                    xwriter.WriteStartElement("Y");
                    xwriter.WriteString(door.localScale.y.ToString());
                    xwriter.WriteEndElement();
                    xwriter.WriteStartElement("Z");
                    xwriter.WriteString(door.localScale.z.ToString());
                    xwriter.WriteEndElement();
                    xwriter.WriteEndElement();
                    xwriter.WriteEndElement();
                    count++;
                }
                xwriter.WriteEndElement();

                count = 0;
                xwriter.WriteStartElement("Pillars");

                foreach (Transform pillar in tempListList[2])
                {
                    xwriter.WriteStartElement("Pillar");
                    xwriter.WriteStartElement("Pillar-No");
                    xwriter.WriteString(count.ToString());
                    xwriter.WriteEndElement();
                    xwriter.WriteStartElement("Position");
                    xwriter.WriteStartElement("X");
                    xwriter.WriteString(pillar.position.x.ToString());
                    xwriter.WriteEndElement();
                    xwriter.WriteStartElement("Y");
                    xwriter.WriteString(pillar.position.y.ToString());
                    xwriter.WriteEndElement();
                    xwriter.WriteStartElement("Z");
                    xwriter.WriteString(pillar.position.z.ToString());
                    xwriter.WriteEndElement();
                    xwriter.WriteEndElement();

                    xwriter.WriteStartElement("Rotation");
                    xwriter.WriteStartElement("X");
                    xwriter.WriteString(pillar.rotation.x.ToString());
                    xwriter.WriteEndElement();
                    xwriter.WriteStartElement("Y");
                    xwriter.WriteString(pillar.rotation.y.ToString());
                    xwriter.WriteEndElement();
                    xwriter.WriteStartElement("Z");
                    xwriter.WriteString(pillar.rotation.z.ToString());
                    xwriter.WriteEndElement();
                    xwriter.WriteEndElement();

                    xwriter.WriteStartElement("Scale");
                    xwriter.WriteStartElement("X");
                    xwriter.WriteString(pillar.localScale.x.ToString());
                    xwriter.WriteEndElement();
                    xwriter.WriteStartElement("Y");
                    xwriter.WriteString(pillar.localScale.y.ToString());
                    xwriter.WriteEndElement();
                    xwriter.WriteStartElement("Z");
                    xwriter.WriteString(pillar.localScale.z.ToString());
                    xwriter.WriteEndElement();
                    xwriter.WriteEndElement();
                    xwriter.WriteEndElement();
                    count++;
                }
                xwriter.WriteEndElement();
                //-----------------each color element-----------------------------------
                xwriter.WriteStartElement("Heatmap");
                Dictionary<Vector2, float> points = Camera.main.GetComponent<collectResults>().allData;
                foreach (KeyValuePair<Vector2, float> keyval in points)
                {
                    xwriter.WriteStartElement("Point");
                    xwriter.WriteStartElement("Position");
                    xwriter.WriteString("(" + keyval.Key.x + "," + keyval.Key.y + ")");
                    xwriter.WriteEndElement();
                    xwriter.WriteStartElement("Value");
                    xwriter.WriteString(""+keyval.Value);
                    xwriter.WriteEndElement();
                    xwriter.WriteEndElement();
                }
                xwriter.WriteEndElement();

                xwriter.WriteStartElement("UsefulInfo");
                xwriter.WriteStartElement("AmountOfPeopleEscaped");
                xwriter.WriteString("" + (GameController.maxNumberPeople - GameController.numberLeft));
                xwriter.WriteEndElement();
                xwriter.WriteStartElement("AmountOfPeopleLeft");
                xwriter.WriteString("" + GameController.numberLeft);
                xwriter.WriteEndElement();
                xwriter.WriteStartElement("totalEscapeTime");
                xwriter.WriteString("" + GameController.totalTime);
                xwriter.WriteEndElement();
                xwriter.WriteStartElement("averageEscapeTime");
                xwriter.WriteString("" + (GameController.totalTime / (GameController.maxNumberPeople - GameController.numberLeft)));
                xwriter.WriteEndElement();
                xwriter.WriteEndElement();


                //-----------------------------------------------------



                xwriter.WriteStartElement("Time-Elapsed");
                xwriter.WriteString(""+GameController.maxTime);//time.ToString());
                xwriter.WriteEndElement();
                xwriter.WriteEndElement();
                xwriter.WriteEndElement();
                xwriter.WriteEndDocument();

                StreamWriter sw = new StreamWriter(s);
                sw.WriteLine("\n");
                xwriter.Close();
            }
            else
            {
                Debug.Log("no xml file yet");
				WebClient web=new WebClient();
				web.DownloadFile("https://crowdevac.com//var/www/crowdevac/XMLUserData/"+ SceneManager.GetActiveScene().name + ".xml", SceneManager.GetActiveScene().name + ".xml");
                XmlDocument doc = new XmlDocument();
				doc.Load(SceneManager.GetActiveScene().name + ".xml");
				XmlNode document = doc.SelectSingleNode("document");

                XmlNode userdata = doc.CreateElement("User-Data");
                document.AppendChild(userdata);

                XmlNode playerid = doc.CreateElement("Player-ID");
                playerid.InnerText=nameStore.name;
                userdata.AppendChild(playerid);

                XmlNode wallsnode = doc.CreateElement("Walls");
                userdata.AppendChild(wallsnode);

                foreach(Transform wall in tempListList[0])
                {
                    XmlNode wallnode = doc.CreateElement("Wall");
                    wallsnode.AppendChild(wallnode);

                    XmlNode position = doc.CreateElement("Position");
                    XmlNode rotation = doc.CreateElement("Rotation");
                    XmlNode scale = doc.CreateElement("Scale");
                    wallnode.AppendChild(position);
                    wallnode.AppendChild(rotation);
                    wallnode.AppendChild(scale);

                    XmlNode pxnode = doc.CreateElement("X");
                    pxnode.InnerText = wall.position.x.ToString();
                    XmlNode pynode = doc.CreateElement("Y");
                    pynode.InnerText = wall.position.y.ToString();
                    XmlNode pznode = doc.CreateElement("Z");
                    pznode.InnerText = wall.position.z.ToString();

                    position.AppendChild(pxnode);
                    position.AppendChild(pynode);
                    position.AppendChild(pznode);

                    //rotation
                    XmlNode rxnode = doc.CreateElement("X");
                    rxnode.InnerText = wall.rotation.x.ToString();
                    XmlNode rynode = doc.CreateElement("Y");
                    rynode.InnerText = wall.rotation.y.ToString();
                    XmlNode rznode = doc.CreateElement("Z");
                    rznode.InnerText = wall.rotation.z.ToString();

                    rotation.AppendChild(rxnode);
                    rotation.AppendChild(rynode);
                    rotation.AppendChild(rznode);


                    //scale

                    XmlNode sxnode = doc.CreateElement("X");
                    sxnode.InnerText = wall.localScale.x.ToString();
                    XmlNode synode = doc.CreateElement("Y");
                    synode.InnerText = wall.localScale.y.ToString();
                    XmlNode sznode = doc.CreateElement("Z");
                    sznode.InnerText = wall.localScale.z.ToString();

                    scale.AppendChild(sxnode);
                    scale.AppendChild(synode);
                    scale.AppendChild(sznode);
                }

                XmlNode doorsnode = doc.CreateElement("Doors");
                userdata.AppendChild(doorsnode);

                foreach (Transform door in tempListList[1])
                {
                    XmlNode doornode = doc.CreateElement("Door");
                    doorsnode.AppendChild(doornode);

                    XmlNode position = doc.CreateElement("Position");
                    XmlNode rotation = doc.CreateElement("Rotation");
                    XmlNode scale = doc.CreateElement("Scale");
                    doornode.AppendChild(position);
                    doornode.AppendChild(rotation);
                    doornode.AppendChild(scale);

                    XmlNode pxnode = doc.CreateElement("X");
                    pxnode.InnerText = door.position.x.ToString();
                    XmlNode pynode = doc.CreateElement("Y");
                    pynode.InnerText = door.position.y.ToString();
                    XmlNode pznode = doc.CreateElement("Z");
                    pznode.InnerText = door.position.z.ToString();

                    position.AppendChild(pxnode);
                    position.AppendChild(pynode);
                    position.AppendChild(pznode);

                    //rotation
                    XmlNode rxnode = doc.CreateElement("X");
                    rxnode.InnerText = door.rotation.x.ToString();
                    XmlNode rynode = doc.CreateElement("Y");
                    rynode.InnerText = door.rotation.y.ToString();
                    XmlNode rznode = doc.CreateElement("Z");
                    rznode.InnerText = door.rotation.z.ToString();

                    rotation.AppendChild(rxnode);
                    rotation.AppendChild(rynode);
                    rotation.AppendChild(rznode);


                    //scale

                    XmlNode sxnode = doc.CreateElement("X");
                    sxnode.InnerText = door.localScale.x.ToString();
                    XmlNode synode = doc.CreateElement("Y");
                    synode.InnerText = door.localScale.y.ToString();
                    XmlNode sznode = doc.CreateElement("Z");
                    sznode.InnerText = door.localScale.z.ToString();

                    scale.AppendChild(sxnode);
                    scale.AppendChild(synode);
                    scale.AppendChild(sznode);
                }

                XmlNode pillarsnode = doc.CreateElement("Pillars");
                userdata.AppendChild(pillarsnode);

                foreach (Transform pillar in tempListList[2])
                {
                    XmlNode pillarnode = doc.CreateElement("Pillar");
                    pillarsnode.AppendChild(pillarnode);

                    XmlNode position = doc.CreateElement("Position");
                    XmlNode rotation = doc.CreateElement("Rotation");
                    XmlNode scale = doc.CreateElement("Scale");
                    pillarnode.AppendChild(position);
                    pillarnode.AppendChild(rotation);
                    pillarnode.AppendChild(scale);

                    XmlNode pxnode = doc.CreateElement("X");
                    pxnode.InnerText = pillar.position.x.ToString();
                    XmlNode pynode = doc.CreateElement("Y");
                    pynode.InnerText = pillar.position.y.ToString();
                    XmlNode pznode = doc.CreateElement("Z");
                    pznode.InnerText = pillar.position.z.ToString();

                    position.AppendChild(pxnode);
                    position.AppendChild(pynode);
                    position.AppendChild(pznode);

                    //rotation
                    XmlNode rxnode = doc.CreateElement("X");
                    rxnode.InnerText = pillar.rotation.x.ToString();
                    XmlNode rynode = doc.CreateElement("Y");
                    rynode.InnerText = pillar.rotation.y.ToString();
                    XmlNode rznode = doc.CreateElement("Z");
                    rznode.InnerText = pillar.rotation.z.ToString();

                    rotation.AppendChild(rxnode);
                    rotation.AppendChild(rynode);
                    rotation.AppendChild(rznode);


                    //scale

                    XmlNode sxnode = doc.CreateElement("X");
                    sxnode.InnerText = pillar.localScale.x.ToString();
                    XmlNode synode = doc.CreateElement("Y");
                    synode.InnerText = pillar.localScale.y.ToString();
                    XmlNode sznode = doc.CreateElement("Z");
                    sznode.InnerText = pillar.localScale.z.ToString();

                    scale.AppendChild(sxnode);
                    scale.AppendChild(synode);
                    scale.AppendChild(sznode);
                }

                //------------------------------------------------------------------------
                XmlNode heatmapNode = doc.CreateElement("Heatmap");
                userdata.AppendChild(heatmapNode);

                Dictionary<Vector2, float> points = Camera.main.GetComponent<collectResults>().allData;
                foreach (KeyValuePair<Vector2, float> keyval in points)
                {
                    XmlNode pointNode = doc.CreateElement("Point");
                    heatmapNode.AppendChild(pointNode);
                    XmlNode positionNode = doc.CreateElement("Position");
                    positionNode.InnerText = "(" + keyval.Key.x + "," + keyval.Key.y + ")";
                    pointNode.AppendChild(positionNode);

                    XmlNode valueNode = doc.CreateElement("Value");
                    valueNode.InnerText = "" + keyval.Value;
                    pointNode.AppendChild(valueNode);
                }

                XmlNode usefulInfo = doc.CreateElement("UsefulInfo");
                userdata.AppendChild(usefulInfo);
                XmlNode AmountOfPeopleEscaped = doc.CreateElement("AmountOfPeopleEscaped");
                AmountOfPeopleEscaped.InnerText = ""+(GameController.maxNumberPeople - GameController.numberLeft);
                usefulInfo.AppendChild(AmountOfPeopleEscaped);
                XmlNode AmountOfPeopleLeft = doc.CreateElement("AmountOfPeopleLeft");
                AmountOfPeopleLeft.InnerText = ("" + GameController.numberLeft);
                usefulInfo.AppendChild(AmountOfPeopleLeft);
                XmlNode totalEscapeTime = doc.CreateElement("totalEscapeTime");
                totalEscapeTime.InnerText = "" + GameController.totalTime;
                usefulInfo.AppendChild(totalEscapeTime);
                XmlNode averageEscapeTime = doc.CreateElement("averageEscapeTime");
                averageEscapeTime.InnerText = "" + (GameController.totalTime / (GameController.maxNumberPeople - GameController.numberLeft));
                usefulInfo.AppendChild(averageEscapeTime);
                








                //--------------------------------------------------------------------------








                XmlNode timenode = doc.CreateElement("Time-Elapsed");
                timenode.InnerText = ""+GameController.maxTime;
                userdata.AppendChild(timenode);
				doc.Save(SceneManager.GetActiveScene().name + ".xml");
				web.UploadFile ("https://crowdevac.com//var/www/crowdevac/XMLUserData/" + SceneManager.GetActiveScene ().name + ".xml", SceneManager.GetActiveScene ().name + ".xml");
			 }
        }
    }
}