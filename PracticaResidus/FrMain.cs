using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.XPath;
using System.Xml;
using System.Collections;

namespace PracticaResidus
{
    public partial class FrMain : Form
    {
        static XPathDocument document = new XPathDocument("ArxiuXml.xml");    // objecte per a carregar el document XML a memòria
        XPathNavigator navegador = document.CreateNavigator();          // objecte per a navegar pel document XML

        // objectes que utilitzarem per a crear un nou arxiu XML
        XmlDocument xDoc;
        XmlNode xNodeArrel;
        XmlDeclaration xDeclaracio;
        XmlComment xComentari;

        Boolean consultaacabadacomarques = false;

        public FrMain()
        {
            InitializeComponent();
        }

        private void FrMain_Load(object sender, EventArgs e)
        {
            afegirdadescomboboxComarques(false);
        }

        private void afegirdadescomboboxComarques(bool creararxiu)
        {
            // mostra els titols dels tutorials ordenats alfabèticament
            XPathNodeIterator cursor = null;
            XPathExpression expr = navegador.Compile("//comarca");

            expr.AddSort("comarca", XmlSortOrder.Ascending, XmlCaseOrder.None, "", XmlDataType.Text);
            cbComarques.Items.Clear();
            cursor = navegador.Select(expr);
            if (!creararxiu)
            {
                foreach (XPathNavigator tut in cursor)
                {
                    if (!cbComarques.Items.Contains(tut.Value.ToString()))
                    {
                        cbComarques.Items.Add(tut.Value.ToString());
                    }
                }
            }
            else
            {
                //Aqui farem el codi per tal de crear l'arxiu XML de manera automatica
                creacioarxiucomarques(cursor);
            }
            consultaacabadacomarques = true;
        }

        private void creacioarxiucomarques(XPathNodeIterator cursor)
        {
            afegirprincipidocument("Totes les comarques");

            afegirdadesmeitatdocument(cursor);

            afegirdadesfidocument("Fi de totes les comarques");
        }

        private void afegirdadesmeitatdocument(XPathNodeIterator cursor)
        {
            List<String> llComarques = new List<String>();
            XmlElement xmlElement = null;

            foreach (XPathNavigator comarca in cursor)
            {
                if (!llComarques.Contains(comarca.Value.ToString()))
                {
                    llComarques.Add(comarca.Value.ToString());
                }
            }
            llComarques.Sort();

            foreach (String comarca in llComarques)
            {
                xmlElement = xDoc.CreateElement("nomComarca"); //Aqui estem creant l'etiqueta
                xmlElement.InnerText = comarca; //Aqui estem afegint el valor de la etiqueta
                xNodeArrel.AppendChild(xmlElement); //Aqui estem dient a on posem letiqueta
            }
        }

        private void afegirdadesfidocument(string v)
        {
            // afegim un comentari al final
            xComentari = xDoc.CreateComment(v);
            xDoc.InsertAfter(xComentari, xNodeArrel);

            if (!sdgXmlFile.FileName.ToLower().EndsWith(".xml"))
            {
                sdgXmlFile.FileName += ".xml";
            }
            xDoc.Save(sdgXmlFile.FileName);
        }

        private void afegirprincipidocument(string v)
        {
            xDoc = new XmlDocument();
            // inserim la declaració sobre l'estàndard XML i la codificació, el "yes" indica que aquest XML no depèn d'una font externa (un arxiu d'schema DTD, XSD)
            xDeclaracio = xDoc.CreateXmlDeclaration("1.0", "utf-8", "yes");
            xDoc.InsertBefore(xDeclaracio, xDoc.DocumentElement);

            // afegim un comentari després de l'arrel
            xComentari = xDoc.CreateComment(v);
            xDoc.InsertAfter(xComentari, xDeclaracio);

            xNodeArrel = xDoc.CreateElement("Comarques");
            xDoc.AppendChild(xNodeArrel);
        }

        private void cbComarques_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (consultaacabadacomarques)
            {
                dgResidus.Visible = false;
                dgResidus.Rows.Clear();
                

                XPathNodeIterator cursor = null;
                XPathExpression expr = navegador.Compile("//row[comarca = \""+ cbComarques.SelectedItem +"\" ]/municipi");

                expr.AddSort("municipi", XmlSortOrder.Ascending, XmlCaseOrder.None, "", XmlDataType.Text);
                cursor = navegador.Select(expr);
                lbxPoblacionsComarca.Items.Clear();
                foreach (XPathNavigator tut in cursor)
                {
                    if (!lbxPoblacionsComarca.Items.Contains((string)tut.Value.ToString()))
                    {
                        lbxPoblacionsComarca.Items.Add((string)tut.Value.ToString());
                    }
                    
                } 
                
            }
        }

        private void lbxPoblacionsComarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (consultaacabadacomarques)
            {
                dgResidus.Rows.Clear();
                foreach (String nommunicipi in lbxPoblacionsComarca.SelectedItems)
                {
                    afegirdadesDatagridView(nommunicipi);
                }
                btnRecollida.Text = "Recollida";
                btnRecollida.Enabled = true;
            }
        }

        private void afegirdadesDatagridView(String nomMunicipi)
        {
            List<String> llNoDades = new List<String>();
            llNoDades.Add("any");
            llNoDades.Add("municipi");
            llNoDades.Add("comarca");
            llNoDades.Add("poblaci");
            llNoDades.Add("codi_municipi");
            Hashtable taulaH = new Hashtable();
            taulaH.Clear();

            char[] caractersdelimitadors = { '<', '>' };


            for (int i = 2000; i <= 2019; i++)
            {
                XPathNodeIterator cursor = null;
                String recerca = "//row[municipi = \"" + nomMunicipi + "\" and any = \"" + i + "\" ]";
                XPathExpression expr = navegador.Compile(recerca);

                expr.AddSort("municipi", XmlSortOrder.Ascending, XmlCaseOrder.None, "", XmlDataType.Text);
                cursor = navegador.Select(expr);
                //lbxPoblacionsComarca.Items.Clear();
                foreach (XPathNavigator tut in cursor)
                {
                    String[] diferentscategories = tut.InnerXml.Split('\n'); 
                    for(int z = 6; z <= diferentscategories.Length-1; z++)
                    {
                        
                        String[] dades = diferentscategories[z].Split(caractersdelimitadors);
                        if (!taulaH.Contains(i))
                        {
                            taulaH[i] = Double.Parse(dades[2].Replace("NA","0"));
                        }
                        else
                        {
                            taulaH[i] = Double.Parse(taulaH[i].ToString()) + Double.Parse(dades[2].Replace("NA", "0"));
                        }
                    }
                }
            }

            for( int i = 2000; i <= 2019; i++)
            {
                XPathNodeIterator cursor = null;
                String recerca = "//row[municipi = \"" + nomMunicipi + "\" and any = \"" + i + "\" ]";
                XPathExpression expr = navegador.Compile(recerca);

                expr.AddSort("municipi", XmlSortOrder.Ascending, XmlCaseOrder.None, "", XmlDataType.Text);
                cursor = navegador.Select(expr);
                //lbxPoblacionsComarca.Items.Clear();
                foreach (XPathNavigator tut in cursor)
                {
                    String[] diferentscategories = tut.InnerXml.Split('\n');
                    for (int z = 6; z <= diferentscategories.Length - 1; z++)
                    {
                        String[] dades = diferentscategories[z].Split(caractersdelimitadors);
                        dgResidus.Rows.Add(nomMunicipi, i, dades[1], dades[2].Replace("NA", "0"), ((Double.Parse(dades[2].Replace("NA","0"))) / ((Double.Parse(taulaH[i].ToString())) * 100)) + "%");
                    }
                }

                dgResidus.Rows.Add(nomMunicipi, i, "TOTAL", taulaH[i].ToString(), "100%");
            }
            dgResidus.Visible = true;
        }

        private void btnComarques_Click(object sender, EventArgs e)
        {
            sdgXmlFile.InitialDirectory = Application.StartupPath;
            if (sdgXmlFile.ShowDialog() == DialogResult.OK)
            {
                if (System.IO.File.Exists(sdgXmlFile.FileName))
                {
                    System.IO.File.Delete(sdgXmlFile.FileName);
                }
                afegirdadescomboboxComarques(true);
            }
            
        }

        private void btnMunicipis_Click(object sender, EventArgs e)
        {
            //Aqui es a on es fara la llista de municipis de una comarca
            sdgXmlFile.InitialDirectory = Application.StartupPath;
            if (sdgXmlFile.ShowDialog() == DialogResult.OK)
            {
                if (System.IO.File.Exists(sdgXmlFile.FileName))
                {
                    System.IO.File.Delete(sdgXmlFile.FileName);
                }
                creacioarxiumunicipis();
            }
        }

        private void creacioarxiumunicipis()
        {
            XPathNodeIterator cursor = null;
            XPathExpression expr = navegador.Compile("//comarca");

            expr.AddSort("comarca", XmlSortOrder.Ascending, XmlCaseOrder.None, "", XmlDataType.Text);
            cbComarques.Items.Clear();
            cursor = navegador.Select(expr);

            afegirprincipidocument("Totes els municipis agrupats per comarca");

            afegirdadesmeitatdocumentMunicipis(cursor);

            afegirdadesfidocument("Fi de Tots els municipis agrupats per comarques");
        }

        private void afegirdadesmeitatdocumentMunicipis(XPathNodeIterator cursor)
        {
            List<String> llComarques = new List<String>();
            List<String> llMunicipis = new List<String>();
            XmlElement xmlElement = null;
            

            foreach (XPathNavigator comarca in cursor)
            {
                if (!llComarques.Contains(comarca.Value.ToString()) && comarca.Value.ToString() != "NA" && comarca.Value.ToString() != "")
                {
                    llComarques.Add(comarca.Value.ToString());
                }
            }
            llComarques.Sort();

            foreach (String comarca in llComarques)
            {
                xmlElement = xDoc.CreateElement("nomComarca"); //Aqui estem creant l'etiqueta
                xmlElement.InnerText = comarca; //Aqui estem afegint el valor de la etiqueta
                xmlElement.SetAttribute("Comarca",comarca);
                xNodeArrel.AppendChild(xmlElement);

                XPathNodeIterator cursor2 = null;
                XPathExpression expr2 = navegador.Compile("//row[comarca = \"" + comarca + "\"]/municipi");

                expr2.AddSort("comarca", XmlSortOrder.Ascending, XmlCaseOrder.None, "", XmlDataType.Text);
                //cbComarques.Items.Clear();
                cursor2 = navegador.Select(expr2);

                foreach(XPathNavigator tut2 in cursor2)
                {
                    if (!llMunicipis.Contains(tut2.Value.ToString()))
                    {
                        llMunicipis.Add(tut2.Value.ToString());
                        xmlElement = xDoc.CreateElement("nommunicipi");
                        xmlElement.InnerText = tut2.Value.ToString();
                        xmlElement.SetAttribute("NomComarca", comarca);
                        xNodeArrel.LastChild.AppendChild(xmlElement);
                    }
                }
            }
        }

        private void btnRecollida_Click(object sender, EventArgs e)
        {
            sdgXmlFile.InitialDirectory = Application.StartupPath;
            if (sdgXmlFile.ShowDialog() == DialogResult.OK)
            {
                if (System.IO.File.Exists(sdgXmlFile.FileName))
                {
                    System.IO.File.Delete(sdgXmlFile.FileName);
                }
                creacioarxiuresidus();
            }
        }

        private void creacioarxiuresidus()
        {
            XPathNodeIterator cursor = null;
            XPathExpression expr = navegador.Compile("//comarca");

            expr.AddSort("comarca", XmlSortOrder.Ascending, XmlCaseOrder.None, "", XmlDataType.Text);
            cbComarques.Items.Clear();
            cursor = navegador.Select(expr);

            afegirprincipidocument("Resum dels residus de cada municipi");
            
            afegirdadesmeitatDocumentResidus();

            afegirdadesfidocument("Fi del resum dels residus de cada municipi");
        }

        private void afegirdadesmeitatDocumentResidus()
        {
            List<String> llComarques = new List<String>();
            List<String> llMunicipis = new List<String>();
            XmlElement xmlElement = null;

            xmlElement = xDoc.CreateElement("ResumRecullidaDades"); //Aqui estem creant l'etiqueta
            xNodeArrel.AppendChild(xmlElement);

            String nomComarca = "";
            String nomAnteriorMunicipi = "";
            String AnyAnterior = "";


            foreach (DataGridViewRow linia in dgResidus.Rows)
            {
                //Aqui tenim el titol de cada element

                
                if(nomAnteriorMunicipi != linia.Cells[0].Value.ToString())
                {
                    xmlElement = xDoc.CreateElement("nomMunicipi"); //Aqui estem creant l'etiqueta
                    xmlElement.SetAttribute("nomMunicipi", linia.Cells[0].Value.ToString());
                    xNodeArrel.LastChild.AppendChild(xmlElement);

                    nomAnteriorMunicipi = linia.Cells[0].Value.ToString();
                }
                

                //Aqui tenim el contingut de cada element

                //Abans de posar la comarca haurem de fer una consutla per saber el nom de la comarca

                XPathNodeIterator cursor = null;
                XPathExpression expr = navegador.Compile("//row[municipi = \"" + linia.Cells[0].Value.ToString() +"\"]/comarca");

                expr.AddSort("comarca", XmlSortOrder.Ascending, XmlCaseOrder.None, "", XmlDataType.Text);
                cbComarques.Items.Clear();
                cursor = navegador.Select(expr);

                foreach(XPathNavigator tut in cursor)
                {
                    if(nomComarca != tut.Value.ToString())
                    {
                        nomComarca = tut.Value.ToString();
                    }
                    else
                    {
                        break;
                    }
                }

                //Aqui sacaba la recerca

                xmlElement = xDoc.CreateElement("nomComarca"); //Aqui estem creant l'etiqueta
                xmlElement.SetAttribute("nomComarca", nomComarca);
                xNodeArrel.LastChild.LastChild.AppendChild(xmlElement);

                if(AnyAnterior != linia.Cells[1].Value.ToString())
                {
                    xmlElement = xDoc.CreateElement("Resum"); //Aqui estem creant l'etiqueta
                    xmlElement.SetAttribute("Municipi", linia.Cells[0].Value.ToString());
                    xmlElement.SetAttribute("Any", linia.Cells[1].Value.ToString());
                    xNodeArrel.LastChild.LastChild.AppendChild(xmlElement);
                    AnyAnterior = linia.Cells[1].Value.ToString();
                }

                xmlElement = xDoc.CreateElement("Tipus_Deixalla");
                xmlElement.SetAttribute("Tipus_Deixalla", linia.Cells[2].Value.ToString());
                xNodeArrel.LastChild.LastChild.LastChild.AppendChild(xmlElement);

                xmlElement = xDoc.CreateElement("TonesRecollides"); //Aqui estem creant l'etiqueta
                xmlElement.InnerText = linia.Cells[3].Value.ToString();
                xNodeArrel.LastChild.LastChild.LastChild.LastChild.AppendChild(xmlElement);

                xmlElement = xDoc.CreateElement("Percentatge"); //Aqui estem creant l'etiqueta
                xmlElement.InnerText = linia.Cells[4].Value.ToString();
                xNodeArrel.LastChild.LastChild.LastChild.LastChild.AppendChild(xmlElement);
            }
        }
    }
}
