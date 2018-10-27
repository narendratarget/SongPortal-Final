<%@ Page Language="C#" MasterPageFile="~/Song.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SongPortal.Default" %>

<asp:Content ID="content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div>
    <div class="row">
        <div class="col-*-4">
            <asp:RadioButton ID="RadioButton_all" runat="server" GroupName="Search" 
                    Text="All" Checked="True" />
                    &nbsp;
            <asp:RadioButton ID="RadioButton_movies" runat="server" GroupName="Search" 
                    Text="Movies" />
            &nbsp;
            <asp:RadioButton ID="RadioButton_songs" runat="server" GroupName="Search" 
                    Text="Mp3 Songs" />
       
            <asp:RadioButton ID="RadioButton_Videos" GroupName="Search" 
                    Text="Video Songs" runat="server" />
             <asp:RadioButton ID="RadioButton_tvshows" GroupName="Search" 
                    Text="TV Shows" runat="server" />
                    <asp:RadioButton ID="RadioButton_Adultmovies" GroupName="Search" 
                    Text="Adult Films" runat="server" />
             &nbsp;&nbsp;
              <asp:TextBox ID="TextBox_Search" placeholder="Search Songs/Video" Width="250px" class="text-primary" runat="server"  > </asp:TextBox>
              <asp:Button ID="Button_Search" class="btn-primary" runat="server" 
                Width="60px" Text="Search" onclick="Button_Search_Click" />
        </div>
        <div> 
              
        </div>
        
   </div>
   <div class="row"></br></div>
   <div class="row">
     <div class="col-sm-12">
        <asp:Panel ID="Panel1" class="img-thumbnail"  runat="server">
         </asp:Panel>
     </div>
   </div>
       <br />
       <div class="row">
          <div class="col-md-3">
             
               <asp:Panel ID="Panel_SearchSongs" Width="100%" class="img-thumbnail"  runat="server">
           
              </asp:Panel>
             
         
          </div>
      <div class="col-md-6">
          <asp:Panel ID="Panel_middle" Width="100%" runat="server">
          
              <video controls="controls"  class="img-thumbnail"  width="700px" height="500px">
               <source src="Songs/video/Afsos.mp4" type="video/mp4"></source>
               </video>
          </asp:Panel>
      </div>
      
      <div class="col-md-3">
          <asp:Panel ID="Panel_Videos" Width="100%" class="img-thumbnail"  runat="server">

          </asp:Panel>
      </div>
 </div>
 </div>
 
</asp:Content>



    