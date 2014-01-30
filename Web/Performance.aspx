<%@ Page Async="true" Title="" Language="C#" MasterPageFile="~/MainPage.Master" AutoEventWireup="true" CodeBehind="Performance.aspx.cs" Inherits="Web.Performance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Mbody" runat="server">
    
    <div class="row">
        <div class="col-lg-12">
            
            <div class="row">
                <div class="col-lg-8 col-lg-offset-2">
                    
                    <div class="col-lg-3">
                        <div class="panel panel-default">
                            <div class="panel-heading">Кол-во рюкзаков</div>
                            <div class="dropdown">
                                <asp:DropDownList runat="server" CssClass="form-control" ID="KnapsacksCountSelect" >
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    
                    <div class="col-lg-3">
                        <div class="panel panel-default">
                            <div class="panel-heading">Погрешность</div>
                            <asp:TextBox runat="server" ID="CalculateError" CssClass="form-control" />
                        </div>
                    </div>
                    
                    <div class="col-lg-2">
                        <asp:Button Text="Решить" ID="Calculate" CssClass="btn btn-info" runat="server" OnClick="Calculate_OnClick" />
                    </div>
                </div>
            </div>
                
            <div class="row">
                <div class="col-lg-8 col-lg-offset-2">
                    <asp:Chart ID="PerformChart" runat="server" Width="580px">
                        <Series>
                            <asp:Series Name="Series1" ChartType="Range" YValuesPerPoint="2" MarkerStyle="Circle" MarkerColor="red" />
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                                <AxisX Title="Количество предметов, шт">
                                    <MajorGrid Enabled="False" />
                                </AxisX>
                                <AxisY Title="Время, мс">
                                    <MajorGrid LineColor="Gainsboro"></MajorGrid>
                                </AxisY>
                            </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </div>
            </div>

        </div>
    </div>

</asp:Content>