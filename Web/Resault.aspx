<%@ Page Async="true" Title="" Language="C#" MasterPageFile="~/MainPage.Master" AutoEventWireup="true" CodeBehind="Resault.aspx.cs" Inherits="Web.Resault" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Mbody" runat="server">
    
    
    <script type="text/javascript" src="/Scripts/ControlsResult.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <div class="row">
        
        <div class="col-lg-6 col-lg-offset-3">



            <asp:UpdatePanel runat="server" id="UpPanel">
                <ContentTemplate>
                    <asp:Button runat="server" ID="btnCalculate" Text="Решить" OnClick="btnCalculate_OnClick" CssClass="btn center-block btn-info" />
                    
                    
                    <div class="row text-center">
                        <asp:UpdateProgress runat="server" id="PageUpdateProgress">
                            <ProgressTemplate>
                                <img src="/Content/ajax-loader.gif" />
                            </ProgressTemplate>
                        </asp:UpdateProgress>

                    </div>
                    
                    <div id="Time" class="alert alert-info hide">
                        <asp:Label runat="server" ID="info" />
                    </div>
                    
                    <div id="OptSolv" class="panel panel-default hide">
                        <div class="panel-heading">Оптимальное решение</div>
                        <asp:GridView ID="OptimalGrid" runat="server" CssClass="table table-striped" GridLines="None" ShowHeader="False" RowStyle-CssClass="success" />
                    </div>

                    <div id="AcceptSolv" style="height: 400px; overflow: auto" class="hide">
                        <asp:GridView ID="AllowableGrid" runat="server" CssClass="table table-striped table-hover" GridLines="None" />
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>  

        </div>
    </div>
    
    
</asp:Content>