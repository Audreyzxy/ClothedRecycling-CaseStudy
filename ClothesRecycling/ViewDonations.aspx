<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewDonations.aspx.cs" Inherits="ClothesRecycling.ViewDonations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
    	<div class="row">
        	<h1>Donations</h1>
    	</div>
 
    	<div class="row">
        	<%--Gridview for submitted donations--%>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    	</div>
	</div>

</asp:Content>
