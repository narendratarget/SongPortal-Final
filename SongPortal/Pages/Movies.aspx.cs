using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace SongPortal.Pages
{
    public partial class Movies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
                string p = Request.Params["mname"];
                string path = Server.MapPath("~/Movies");
                DirectoryInfo d = new DirectoryInfo(path);
                FileInfo[] f = d.GetFiles();
                foreach (FileInfo file in f)
                {
                    if (file.Name.StartsWith(p))
                    {
                        LiteralControl lc = new LiteralControl(file.Name);
                        Button play = new Button();
                        play.Text = "Play";
                        Button download = new Button();
                        download.Text = "Download";
                        //   Panel1.Controls.Clear();
                        Panel1.Controls.Add(lc);
                        Panel1.Controls.Add(new LiteralControl("</br>"));
                        Panel1.Controls.Add(play);
                        Panel1.Controls.Add(download);
                        Panel1.Controls.Add(new LiteralControl("</br>"));
                        Panel1.Controls.Add(new LiteralControl("</br>"));
                    }
                }

            
        }
    }
}