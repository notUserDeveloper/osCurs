<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.Master" AutoEventWireup="true" CodeBehind="Manual.aspx.cs" Inherits="Web.Manual" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Mbody" runat="server">
    <script type="text/javascript" src="/Scripts/HelpValidator.js"> </script>
    
    <div class="row">
        
        <div class="col-lg-12 col-lg-offset-3">

            <div class="col-lg-3">
            
                <div class="row">
                    <div class="panel panel-default">
                        <div class="panel-heading">Количество рюкзаков</div>
                        <div class="panel-body">
                            <div class="input-group input-group-sm">
                                <span class="input-group-addon"><span class="glyphicon glyphicon-briefcase"></span></span>
                                <asp:TextBox ID="KnapsacksCount" CssClass="form-control" placeholder="Число рюкзаков" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            
                <div class="row">
                    <div class="panel panel-default">
                        <div class="panel-heading">Количество вещей</div>
                        <div class="panel-body">
                            <div class="input-group input-group-sm">
                                <span class="input-group-addon"><span class="glyphicon glyphicon-align-center"></span></span>
                                <asp:TextBox ID="ItemsCount" class="form-control" placeholder="Число вещей" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
                
                <div class="row">
                    <div class="panel panel-default">
                        <div class="panel-heading">Погрешность</div>
                        <div class="panel-body">
                            <div class="input-group input-group-sm">
                                <span class="input-group-addon"><span class="glyphicon glyphicon-minus-sign"></span></span>
                                <asp:TextBox ID="CalculateError" Text="0" class="form-control" placeholder="Погрешность от 0 до 1" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            
                <div class="row">
                    <asp:Button runat="server" ID="btnGridParameters" Text="Принять" CssClass="btn btn-block btn-info" OnClick="btnGridParameters_OnClick" />
                </div>

            </div>
        
            <div class="col-lg-3">
            
                <div class="row">
                    <div class="panel panel-default">
                        <div class="panel-heading">Вместимость рюкзаков</div>
                        <asp:GridView runat="server" ID="KnapsacksGrid" CssClass="table table-striped" GridLines="None"
                                      AutoGenerateEditButton="True" OnRowEditing="KnapsacksGrid_OnRowEditing" OnRowUpdating="KnapsacksGrid_OnRowUpdating" />
                    </div>
                </div>
            
                <div class="row">
                    <div class="panel panel-default">
                        <div class="panel-heading">Веса вещей</div>
                        <asp:GridView runat="server" ID="ItemsGrid" CssClass="table table-striped" GridLines="None"
                                      AutoGenerateEditButton="True" OnRowEditing="ItemsGrid_OnRowEditing" OnRowUpdating="ItemsGrid_OnRowUpdating" />
                    </div>
                </div>
                
                <div class="row">
                    <asp:Button runat="server" ID="btnCalculate" Text="Решить" CssClass="btn btn-block btn-info" OnClick="btnCalculate_Click" />
                </div>

            </div>
            
        </div>

    </div>

</asp:Content>