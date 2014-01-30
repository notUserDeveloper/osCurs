<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.Master" AutoEventWireup="true" CodeBehind="Database.aspx.cs" Inherits="Web.Database" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Mbody" runat="server">
    
    <div class="row">
        
        <div class="col-lg-8 col-lg-offset-2">
            <div class="row">
                <div class="panel panel-default">
                    <div class="panel-heading"><span class="glyphicon glyphicon-list"></span> Примеры</div>
                    <asp:GridView runat="server" ID="ExamplesGrid" CssClass="table table-striped" GridLines="None"
                        AutoGenerateSelectButton="True" OnSelectedIndexChanging="ExamplesGrid_OnSelectedIndexChanging" />
                </div>
            </div>
        </div>

    </div>


</asp:Content>