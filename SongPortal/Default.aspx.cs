using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Xml;
using System.Data;
namespace SongPortal
{
    public partial class Default : System.Web.UI.Page
    {

        DataTable XmlToDataTable(XmlDocument doc,string sel)
        {
                DataTable dt = new DataTable();
                dt.Clear();
                dt.Columns.Add("name");
                dt.Columns.Add("path");
                foreach (XmlNode node in doc.SelectNodes(sel))
                {
                    DataRow _a = dt.NewRow();
                    _a["name"] = node.SelectSingleNode("name").InnerText;
                    _a["path"] = node.SelectSingleNode("path").InnerText;
                    dt.Rows.Add(_a);
                }

                return dt;
        }


        public void readxml(string sel,Panel p)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("XML/latest.xml"));

            foreach (XmlNode node in doc.SelectNodes(sel))
            {
                LiteralControl pth = new LiteralControl("<kbd>" + node.SelectSingleNode("path").InnerText.Substring(25, node.SelectSingleNode("path").InnerText.Length - 26 - node.SelectSingleNode("name").InnerText.Length) + "</kbd>");
                p.Controls.Add(pth);


                Literal lbl = new Literal();
                lbl.Text = node.SelectSingleNode("name").InnerText + "</br>";
                p.Controls.Add(lbl);
             
                LiteralControl lcl = new LiteralControl("</br>");
                p.Controls.Add(lcl);
                LiteralControl lc = new LiteralControl("<kbd>");
                p.Controls.Add(lc);
                LinkButton play = new LinkButton();
                play.Text = "Play";
               
               
                play.ForeColor = System.Drawing.Color.White;
                play.CommandName = node.SelectSingleNode("path").InnerText.Substring(25, node.SelectSingleNode("path").InnerText.Length - 25);
               if(sel.Contains('3'))
                play.Click += new EventHandler(btn_Click);
               else
                   play.Click += new EventHandler(playvideo_Click);
                p.Controls.Add(play);
                LiteralControl lce = new LiteralControl("</kbd>");
                p.Controls.Add(lce);
                p.Controls.Add(new LiteralControl("&nbsp&nbsp"));


                LinkButton download = new LinkButton();
                download.Text = "Download";
                download.ForeColor = System.Drawing.Color.White;
                download.CommandName = node.SelectSingleNode("path").InnerText;
                download.Click += new EventHandler(download_Click);
                LiteralControl lcd = new LiteralControl("<kbd>");
                p.Controls.Add(lcd);
                p.Controls.Add(download);
                LiteralControl lcde = new LiteralControl("</kbd></br>");
                p.Controls.Add(lcde);

                p.Controls.Add(lcl); 
               
            }
        }
        protected void btn_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string player = "<audio controls='controls' autoplay='autoplay'><source src='"+btn.CommandName+"' type='audio/mp3' / ></audio>";
            LiteralControl lc = new LiteralControl(player);
            Panel_middle.Controls.Add(lc);

        }
        protected void playvideo_Click(object sender, EventArgs e)
        {
            Panel_middle.Controls.Clear();
            LinkButton btn = (LinkButton)sender;
            string player = "<video controls='controls'  class='img-thumbnail'  width='700px' height='500px' autoplay='autoplay'><source src='" + btn.CommandName + "' type='video/mp4' / ></video>";
            LiteralControl lc = new LiteralControl(player);
            Panel_middle.Controls.Add(lc);

        }

        protected void download_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            
            FileStream fs = new FileStream(btn.CommandName, FileMode.Open, FileAccess.Read);
            int size = (int)fs.Length;
            byte[] bt = new byte[size];
            fs.Read(bt, 0, size);
            Response.AddHeader("content-disposition", "attachment;filename=" + fs.Name);
            Response.BinaryWrite(bt);
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
           
                for (int i = 65; i <= 90; i++)
                {
                    LinkButton l = new LinkButton();
                    l.ForeColor = System.Drawing.Color.White;
                    l.Font.Size = 15;
                    l.Text = ((char)i).ToString();

                    LiteralControl lcl = new LiteralControl("&nbsp&nbsp&nbsp&nbsp&nbsp");
                    EventHandler ev = new EventHandler(btnclick);
                    l.Click += ev;
                    LiteralControl lc = new LiteralControl("<kbd>");
                    Panel1.Controls.Add(lc);
                    Panel1.Controls.Add(l);
                    LiteralControl lckbd = new LiteralControl("</kbd>");
                    Panel1.Controls.Add(lckbd);
                    Panel1.Controls.Add(lcl);

                }
                LiteralControl lc1 = new LiteralControl("</br></br>");
                Panel1.Controls.Add(lc1);


                ///latest songs


                readxml("root/mp3", Panel_SearchSongs);
                readxml("root/other", Panel_Videos);


                ///end latest songs
            }
        protected void btnclick(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            if (RadioButton_songs.Checked)
            {
                Response.Redirect("Pages/Songs.aspx?sname=" + lb.Text);
            }
            if (RadioButton_movies.Checked)
            {
                Response.Redirect("Pages/Songs.aspx?mname=" + lb.Text);
            }
            if (RadioButton_Adultmovies.Checked)
            {
                Response.Redirect("Pages/Songs.aspx?amname=" + lb.Text);
            }
            if (RadioButton_tvshows.Checked)
            {
                Response.Redirect("Pages/Songs.aspx?tvsname=" + lb.Text);
            } 
            if (RadioButton_Videos.Checked)
            {
                Response.Redirect("Pages/Songs.aspx?vname=" + lb.Text);
            } 
        }

     public   void addfile2panel(string dirname,string filename,Panel p,string ext)
        {
         
            LiteralControl pth = new LiteralControl("<kbd>" +dirname + "</kbd>");
            p.Controls.Add(pth);


            Literal lbl = new Literal();
            lbl.Text = filename;
            p.Controls.Add(lbl);

            LiteralControl lcl = new LiteralControl("</br>");
            p.Controls.Add(lcl);
            LiteralControl lc = new LiteralControl("<kbd>");
            p.Controls.Add(lc);
            LinkButton play = new LinkButton();
            play.Text = "Play";


            play.ForeColor = System.Drawing.Color.White;
            play.CommandName = Server.MapPath( dirname + "\\" + filename);
            if (ext.Contains('3'))
                play.Click += new EventHandler(btn_Click);
            else
                play.Click += new EventHandler(playvideo_Click);
            p.Controls.Add(play);
            LiteralControl lce = new LiteralControl("</kbd>");
            p.Controls.Add(lce);
            p.Controls.Add(new LiteralControl("&nbsp&nbsp"));


            LinkButton download = new LinkButton();
            download.Text = "Download";
            download.ForeColor = System.Drawing.Color.White;
            download.CommandName =Server.MapPath(  dirname + "\\" + filename);
            download.Click += new EventHandler(download_Click);
            LiteralControl lcd = new LiteralControl("<kbd>");
            p.Controls.Add(lcd);
            p.Controls.Add(download);
            LiteralControl lcde = new LiteralControl("</kbd></br>");
            p.Controls.Add(lcde);

            p.Controls.Add(lcl); 
               
        }
        public void search4track(string dirpath,string word)
        {
            DirectoryInfo dir = new DirectoryInfo(Server.MapPath( dirpath));
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo f in files)
            {

                if (f.Name.Contains(word))
                {
                    if (f.Extension == ".mp3"||f.Extension == ".aac")
                    {
                        addfile2panel(dirpath,f.Name,Panel_SearchSongs,"mp3");
                       
                       
                    }
                    else
                    {
                        addfile2panel(dirpath,f.Name,Panel_Videos,"abc");
                    }
                }
            }
        }
       
        protected void Button_Search_Click(object sender, EventArgs e)
        {
            if (RadioButton_Adultmovies.Checked)
            {
                Panel_Videos.Controls.Clear();
                search4track("Adultmovies", TextBox_Search.Text);
            }
            if (RadioButton_movies.Checked)
            {
                Panel_Videos.Controls.Clear();
                search4track("Movies", TextBox_Search.Text);
            }
            if (RadioButton_songs.Checked)
            {
                Panel_SearchSongs.Controls.Clear();
                DirectoryInfo dir = new DirectoryInfo(Server.MapPath("~/Songs"));
                DirectoryInfo[] d = dir.GetDirectories();
                foreach (DirectoryInfo dd in d)
                {
                    search4track("Songs/" + dd, TextBox_Search.Text);
                }
            }
            if (RadioButton_Videos.Checked)
            {
                Panel_Videos.Controls.Clear();
                DirectoryInfo dir = new DirectoryInfo(Server.MapPath("~/Video"));
                DirectoryInfo[] d = dir.GetDirectories();
                foreach (DirectoryInfo dd in d)
                {
                    search4track("Video/" + dd, TextBox_Search.Text);
                }
            }
            if (RadioButton_tvshows.Checked)
            {
                Panel_Videos.Controls.Clear();
                DirectoryInfo dir = new DirectoryInfo(Server.MapPath( "Tvshow"));
                DirectoryInfo[] d = dir.GetDirectories();
                foreach (DirectoryInfo dd in d)
                {
                    search4track("Tvshow/" + dd, TextBox_Search.Text);
                }
            }
        }
    }
}