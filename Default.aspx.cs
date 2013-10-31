using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        XmlDocument doc = new XmlDocument();
        doc.LoadXml("<node><childnode><grandchildnode>Innertext of grandchildnode</grandchildnode>Innertext of childnode</childnode><childnode><grandchildnode>Innertext of grandchildnode 2</grandchildnode>Innertext of childnode 2</childnode></node>");
        //doc.LoadXml(@"E:\Sami\ExXml\xml.xml");
        Response.Write("== Multiple child nodes ==");
        Response.Write("</br>");
        XmlNodeList childNodes = doc.GetElementsByTagName("childnode");
        if (childNodes != null)
        {
            for (int i = 0; i < childNodes.Count; i++)
            {
                XmlNode valueNode = childNodes[i].SelectSingleNode("text()");
                if (valueNode != null)
                    Response.Write(i + " " + valueNode.Value);
                Response.Write("</br>");
            }
        }


        Response.Write("== Single child node (first one) ==");
        Response.Write("</br>");
        XmlNode singleChildNode = doc.SelectSingleNode("/node/childnode/text()");
        if (singleChildNode != null)
            Response.Write(" singleChildNode.Value" + singleChildNode.Value);
            
        else
            Response.Write("Single node not found"); Response.Write("</br>");
        Response.Write("------------------------------------");
    }
}