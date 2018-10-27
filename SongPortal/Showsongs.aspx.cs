using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace SongPortal.Songs
{
    public partial class Showsongs : System.Web.UI.Page
    {


        public void show(string pathh,Panel Pan)
        {
            
            DirectoryInfo d = new DirectoryInfo(pathh);
            FileInfo []files = d.GetFiles();
            foreach (FileInfo f in files)
            {
                LiteralControl lc = new LiteralControl(f.Name);
                
                Button play = new Button();
                play.Text = "Play";
                play.CommandName = (pathh + "\\" + f.Name).Substring(25, (pathh + "\\" + f.Name).Length - 25);
                if(f.Extension==".mp3")
                  play.Click+=new EventHandler(play_Click);
                else
                    play.Click += new EventHandler(play_vid_Click);
                
                Button download = new Button();
                download.Text = "Download";
                download.CommandName = (pathh + "\\" + f.Name).Substring(25, (pathh + "\\" + f.Name).Length - 25);
                download.Click+=new EventHandler(download_Click);
                
                Pan.Controls.Add(lc);
                Pan.Controls.Add(new LiteralControl("</br>"));
                Pan.Controls.Add(play);
                Pan.Controls.Add(download);
                Pan.Controls.Add(new LiteralControl("</br>"));
                Pan.Controls.Add(new LiteralControl("</br>"));
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string p = Request.Params["para"];
           
           
            show(p, Panel1);

        }
        protected void play_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string player = "<audio controls='controls' autoplay='autoplay'>" + "<source src='"+btn.CommandName+"' type='audio/mp3'></source>" + "</audio>";
            LiteralControl lc = new LiteralControl(player);
            Panel1.Controls.Add(lc);

        }
        protected void play_vid_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string player = "<video controls='controls' autoplay='autoplay'>" + "<source src='" + btn.CommandName + "' type='video/mp4'></source>" + "</video>";
            LiteralControl lc = new LiteralControl(player);
            Panel1.Controls.Add(lc);

        }
        protected void download_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            FileStream fs = new FileStream(btn.CommandName, FileMode.Open, FileAccess.Read);
            int size = (int)fs.Length;
            byte[] bt = new byte[size];
            fs.Read(bt, 0, size);
            Response.AddHeader("content-disposition", "attachment;filename=" + fs.Name);
            Response.BinaryWrite(bt); 
        }
    }
}