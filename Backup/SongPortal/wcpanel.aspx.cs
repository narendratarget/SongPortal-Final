using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml;

namespace SongPortal
{
    public partial class wcpanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ViewState["dir"] = null;
            
        }
        public void xmlupdation(string filename,string filepath,string node)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("XML/latest.xml"));

            XmlNode mp3 = doc.CreateElement(node);
            XmlNode name = doc.CreateElement("name");
            name.InnerText = filename;

            XmlNode path = doc.CreateElement("path");
            path.InnerText = filepath;

            mp3.AppendChild(name);
            mp3.AppendChild(path);

            doc.DocumentElement.AppendChild(mp3);
            doc.Save(Server.MapPath("XML/latest.xml"));
                        
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
           
            if (RadioButton_adultmovies.Checked)
            {
                ViewState["dir"] = "\\Adultmovies";
            }
            else
            {
                if (RadioButton_Movies.Checked)
                {
                    ViewState["dir"] = "\\Movies";
                }
                else
                {
                    if (RadioButton_mp3songs.Checked)
                    {
                        ViewState["dir"] = "\\Songs";
                    }
                    else
                    {
                        if (RadioButton_tvshows.Checked)
                        {
                            ViewState["dir"] = "\\Tvshow";
                        }
                        else
                        {
                            ViewState["dir"] = "\\Video";
                        }
                    }
                }
            }
            if (ViewState["dir"] != null)
            {
                string filepath = Server.MapPath(ViewState["dir"].ToString());
                HttpFileCollection uploadedFiles = Request.Files;
              ///  Span1.Text = string.Empty;

                for (int i = 0; i < uploadedFiles.Count; i++)
                {
                    HttpPostedFile userPostedFile = uploadedFiles[i];

                    try
                    {
                        
                        if (userPostedFile.ContentLength > 0)
                        {
                            string node = "other";
                            Literal lbl = new Literal();
                            LiteralControl lctrl = new LiteralControl("</br>");
                            lbl.Text = (i + 1) + "-" + userPostedFile.FileName + "   Type:" + userPostedFile.ContentType + "  size:" + userPostedFile.ContentLength+"</br>";
                            Panel_uploaded_files.Controls.Add(lbl);
                            Panel_uploaded_files.Controls.Add(lctrl);
                          /////  Span1.Font.Size = 11;
                            userPostedFile.SaveAs(filepath + "\\" + Path.GetFileName(userPostedFile.FileName));
                 
                        //*xml updation
                            if ("\\Songs"==ViewState["dir"].ToString())
                            {
                                node = "mp3";
                            }
                            xmlupdation(userPostedFile.FileName, filepath + "\\" + Path.GetFileName(userPostedFile.FileName), node);
                        ///*end xml updation
                        }
                    }
                    catch (Exception Ex)
                    {
                        //Span1.Text += "Error: <br>" + Ex.Message;
                    }

                }

            }

        }

    }
}
 