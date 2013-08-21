using System.Xml.Xsl;

class XSLTransform
{
    static void Main()
    {
        XslCompiledTransform xslt = new XslCompiledTransform();
        xslt.Load("../../catalogue.xsl");
        xslt.Transform("../../catalogue.xml", "../../catalogue.html");
    }
}