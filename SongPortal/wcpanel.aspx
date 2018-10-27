<%@ Page Title="" Language="C#" MasterPageFile="~/Song.Master" AutoEventWireup="true" CodeBehind="wcpanel.aspx.cs" Inherits="SongPortal.wcpanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"> 
    <div class="row">
        <div class="col-sm-2">Select category:</div>
        <div class="col-sm-2"><asp:RadioButton ID="RadioButton_Movies" runat="server" GroupName="Category" Text="Movies" /></div>
        <div class="col-sm-2"><asp:RadioButton ID="RadioButton_mp3songs" runat="server" GroupName="Category" Text="mp3 Songs" /></div>
        <div class="col-sm-2"><asp:RadioButton ID="RadioButton_Videos" runat="server" GroupName="Category" Text="Videos" /></div>
        <div class="col-sm-2"><asp:RadioButton ID="RadioButton_tvshows" runat="server" GroupName="Category" Text="Tv Show" /></div>
        <div class="col-sm-2"><asp:RadioButton ID="RadioButton_adultmovies" runat="server" GroupName="Category" Text="Adult Movies" /></div>

    </div>

    <br />

    <br />
    <div class="row">
        <div class="col-sm-6">
            <input type="file" id="myfile" multiple="multiple" name="myfile" runat="server" />
            <asp:Button ID="Button1" runat="server" Text="Upload" OnClick="Button1_Click" />
           
        </div>
        <div class="col-sm-6">
            <asp:Panel ID="Panel_uploaded_files" class="img-thumbnail" runat="server">

            </asp:Panel>
        </div>
    </div>

</asp:Content>

