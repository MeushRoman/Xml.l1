using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XML
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("https://news.rambler.ru/rss/world");

            foreach (XmlElement root in doc.DocumentElement.ChildNodes)
            {
                foreach (XmlNode channel in root.ChildNodes)
                {
                    if (root.Name.Equals("title"))
                    {
                        string title = channel.InnerText;
                        Console.WriteLine(title);
                    }
                }
            }

            XmlNode titleNode = doc.SelectSingleNode("//rss/channel/title");
            Console.WriteLine(titleNode.InnerText);
        }


        static void CreateXmlDoc()
        {

            XmlDocument doc = new XmlDocument();

            //способ 1
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.8", "utf-8", null); //добавление декларации в документ
            // doc.AppendChild(xmlDeclaration);

            XmlElement note = doc.CreateElement("note");
            //<note> </note>

            //1
            doc.AppendChild(note);

            XmlElement to = doc.CreateElement("to");
            XmlElement from = doc.CreateElement("from");
            XmlElement heading = doc.CreateElement("heading");
            XmlElement body = doc.CreateElement("body");

            //-------------------------

            note.AppendChild(to);
            XmlAttribute date = doc.CreateAttribute("date");
            note.Attributes.Append(date);
            date.InnerText = DateTime.Now.ToShortDateString();

            note.AppendChild(from);
            note.AppendChild(heading);
            note.AppendChild(body);

            /*
             <note> 
                 <to></to>
                 <from></from>
                 <heading></heading>
                 <body></body>
             </note>
           */

            //способ 2
            //XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.8", "utf-8", null);
            //doc.InsertBefore(xmlDeclaration, note);

            doc.Save("Note.xml"); //сохраняет в файл
        }
    }
}
