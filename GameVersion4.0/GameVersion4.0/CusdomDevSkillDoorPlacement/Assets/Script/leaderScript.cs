using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Xml;
using System.IO;

public class leaderScript : MonoBehaviour {

    public Text index;
    public Text pname;
    public Text score;
    public GameObject panel;

    string playername;
    float mintime = System.Single.PositiveInfinity;
	// Use this for initialization
	void Start () {
        float x = panel.transform.position.x;
        float y = panel.transform.position.y;

        XmlDocument doc = new XmlDocument();

        if (File.Exists("C:\\Users\\NILAY\\Desktop\\GameVersion3.0\\GameVersion3.0\\CusdomDevSkillDoorPlacement\\XML Docs\\Level1.xml"))
        {
            doc.Load("C:\\Users\\NILAY\\Desktop\\GameVersion3.0\\GameVersion3.0\\CusdomDevSkillDoorPlacement\\XML Docs\\Level1.xml");

            foreach(XmlNode node in doc.DocumentElement.ChildNodes)
            {
                float nodetime=0.0f;
                string tempname="";
                foreach (XmlNode cnode in node.ChildNodes)
                {
                    if (cnode.Name== "Player-ID")
                    {
                        tempname = cnode.InnerText;
                    }
                    if(cnode.Name== "Time-Elapsed")
                    {
                        nodetime= System.Single.Parse(cnode.InnerText);
                    }

                }

                if(nodetime<mintime)
                {
                    mintime = nodetime;
                    playername = tempname;
                }

            }
            GameObject newPanel = Instantiate(panel);
            GameObject lbody = GameObject.FindGameObjectWithTag("leaderbody");

            newPanel.transform.parent = lbody.transform;
            newPanel.transform.position = new Vector3(x, y, 0);
            newPanel.transform.GetChild(1).gameObject.GetComponent<Text>().text = playername;
            newPanel.transform.GetChild(2).gameObject.GetComponent<Text>().text = "Level 1";
            newPanel.transform.GetChild(0).gameObject.GetComponent<Text>().text = mintime.ToString();

            y = y - 60;
        }
        if (File.Exists("C:\\Users\\NILAY\\Desktop\\GameVersion3.0\\GameVersion3.0\\CusdomDevSkillDoorPlacement\\XML Docs\\Level2.xml"))
        {
            doc.Load("C:\\Users\\NILAY\\Desktop\\GameVersion3.0\\GameVersion3.0\\CusdomDevSkillDoorPlacement\\XML Docs\\Level2.xml");
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                float nodetime = 0.0f;
                string tempname = "";
                foreach (XmlNode cnode in node.ChildNodes)
                {
                    if (cnode.Name == "Player-ID")
                    {
                        tempname = cnode.InnerText;
                    }
                    if (cnode.Name == "Time-Elapsed")
                    {
                        nodetime = System.Single.Parse(cnode.InnerText);
                    }

                }

                if (nodetime < mintime)
                {
                    mintime = nodetime;
                    playername = tempname;
                }

            }
            GameObject newPanel = Instantiate(panel);
            GameObject lbody = GameObject.FindGameObjectWithTag("leaderbody");

            newPanel.transform.parent = lbody.transform;
            newPanel.transform.position = new Vector3(x, y, 0);
            newPanel.transform.GetChild(1).gameObject.GetComponent<Text>().text = playername;
            newPanel.transform.GetChild(2).gameObject.GetComponent<Text>().text = "Level 2";
            newPanel.transform.GetChild(0).gameObject.GetComponent<Text>().text = mintime.ToString();


            y = y -60;
        }
        if (File.Exists("C:\\Users\\NILAY\\Desktop\\GameVersion3.0\\GameVersion3.0\\CusdomDevSkillDoorPlacement\\XML Docs\\Level3.xml"))
        {
            doc.Load("C:\\Users\\NILAY\\Desktop\\GameVersion3.0\\GameVersion3.0\\CusdomDevSkillDoorPlacement\\XML Docs\\Level3.xml");
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                float nodetime = 0.0f;
                string tempname = "";
                foreach (XmlNode cnode in node.ChildNodes)
                {
                    if (cnode.Name == "Player-ID")
                    {
                        tempname = cnode.InnerText;
                    }
                    if (cnode.Name == "Time-Elapsed")
                    {
                        nodetime = System.Single.Parse(cnode.InnerText);
                    }

                }

                if (nodetime < mintime)
                {
                    mintime = nodetime;
                    playername = tempname;
                }

            }
            GameObject newPanel = Instantiate(panel);
            GameObject lbody = GameObject.FindGameObjectWithTag("leaderbody");

            newPanel.transform.parent = lbody.transform;
            newPanel.transform.position = new Vector3(x, y, 0);
            newPanel.transform.GetChild(1).gameObject.GetComponent<Text>().text = playername;
            newPanel.transform.GetChild(2).gameObject.GetComponent<Text>().text = "Level 3";
            newPanel.transform.GetChild(0).gameObject.GetComponent<Text>().text = mintime.ToString();
            y = y - 60;
        }
        if (File.Exists("C:\\Users\\NILAY\\Desktop\\GameVersion3.0\\GameVersion3.0\\CusdomDevSkillDoorPlacement\\XML Docs\\Level4.xml"))
        {
            doc.Load("C:\\Users\\NILAY\\Desktop\\GameVersion3.0\\GameVersion3.0\\CusdomDevSkillDoorPlacement\\XML Docs\\Level4.xml");
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                float nodetime = 0.0f;
                string tempname = "";
                foreach (XmlNode cnode in node.ChildNodes)
                {
                    if (cnode.Name == "Player-ID")
                    {
                        tempname = cnode.InnerText;
                    }
                    if (cnode.Name == "Time-Elapsed")
                    {
                        nodetime = System.Single.Parse(cnode.InnerText);
                    }

                }

                if (nodetime < mintime)
                {
                    mintime = nodetime;
                    playername = tempname;
                }

            }
            GameObject newPanel = Instantiate(panel);
            GameObject lbody = GameObject.FindGameObjectWithTag("leaderbody");

            newPanel.transform.parent = lbody.transform;
            newPanel.transform.position = new Vector3(x, y, 0);
            newPanel.transform.GetChild(1).gameObject.GetComponent<Text>().text = playername;
            newPanel.transform.GetChild(2).gameObject.GetComponent<Text>().text = "Level 4";
            newPanel.transform.GetChild(0).gameObject.GetComponent<Text>().text = mintime.ToString();

            y = y -60;
        }
        if (File.Exists("C:\\Users\\NILAY\\Desktop\\GameVersion3.0\\GameVersion3.0\\CusdomDevSkillDoorPlacement\\XML Docs\\Level5.xml"))
        {
            doc.Load("C:\\Users\\NILAY\\Desktop\\GameVersion3.0\\GameVersion3.0\\CusdomDevSkillDoorPlacement\\XML Docs\\Level5.xml");
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                float nodetime = 0.0f;
                string tempname = "";
                foreach (XmlNode cnode in node.ChildNodes)
                {
                    if (cnode.Name == "Player-ID")
                    {
                        tempname = cnode.InnerText;
                    }
                    if (cnode.Name == "Time-Elapsed")
                    {
                        nodetime = System.Single.Parse(cnode.InnerText);
                    }

                }

                if (nodetime < mintime)
                {
                    mintime = nodetime;
                    playername = tempname;
                }

            }
            GameObject newPanel = Instantiate(panel);
            GameObject lbody = GameObject.FindGameObjectWithTag("leaderbody");

            newPanel.transform.parent = lbody.transform;
            newPanel.transform.position = new Vector3(x, y, 0);
            
            newPanel.transform.GetChild(1).gameObject.GetComponent<Text>().text = playername;
            newPanel.transform.GetChild(2).gameObject.GetComponent<Text>().text = "Level 5";
            newPanel.transform.GetChild(0).gameObject.GetComponent<Text>().text = mintime.ToString();
        }


    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
