using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace SongPortal.Pages
{
    public partial class Songs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string p="" ;
            string path="";
            if (Request.Params["sname"] != null)
            {
                p = Request.Params["sname"];
                path = Server.MapPath("~/Songs");
            }
            /*
            if (Request.Params["mname"] != null)
            {
                p = Request.Params["mname"];
                path = Server.MapPath("~/");
            }
            
            if (Request.Params["amname"] != null)
            {
                p = Request.Params["amname"];
                path = Server.MapPath("~/Songs");
            }*/
            if (Request.Params["tvsname"] != null)
            {
                p = Request.Params["tvname"];
                path = Server.MapPath("~/Tvshow");
            }

            if (Request.Params["vname"] != null)
            {
                p = Request.Params["vname"];
                path = Server.MapPath("~/Video");
            }
             
            DirectoryInfo d = new DirectoryInfo(path);
            DirectoryInfo[] dir = d.GetDirectories();
            foreach (DirectoryInfo d1 in dir)
            {
                if (d1.Name.StartsWith(p))
                {
                    LinkButton l = new LinkButton();
                    l.Text = d1.Name;
                    l.CommandName = path;
                    l.Click += new EventHandler(l_Click);
                    Panel1.Controls.Add(l);
                    Panel1.Controls.Add(new LiteralControl("</br>"));
                }
            }


        }

        protected void l_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            Response.Redirect("~/Showsongs.aspx?para="+lbtn.CommandName+"\\" + lbtn.Text);
        }

    }
}