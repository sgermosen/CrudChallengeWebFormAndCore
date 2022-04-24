<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Calendar.aspx.cs" Inherits="Calendar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Eco Friend & Co. - Time Tracker - Select Date</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <meta name="generator" content="Microsoft Visual Studio, see http://msdn.microsoft.com/vstudio/" />
    <meta name="Description" content="Select a date" />
    <meta name="copyright" content="Copyright (c) 2011 Eco Friend & Company. All rights reserved." />
</head>
<body>
    <form id="form1" runat="server">
        <div id="calbg">
            <div id="calcontent">
                <fieldset>
                    <legend>SeleSelect a date: </legend>
                    <asp:DropDownList ID="MonthSelect" runat="server" AutoPostBack="True" OnSelectedIndexChanged="MonthSelect_SelectedIndexChanged"></asp:DropDownList>
                    &nbsp;
                    <asp:DropDownList ID="YearSelect" runat="server" AutoPostBack="True" OnSelectedIndexChanged="YearSelect_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:Calendar ID="Cal" runat="server" ShowTitle="False" ShowNextPrevMonth="False"
                         DayNameFormat="FirstTwoLetters" FirstDayOfWeek="Sunday"
OnSelectionChanged="Cal_SelectionChanged">
                        <TodayDayStyle Font-Bold="True" ForeColor="White"
BackColor="#990000"></TodayDayStyle>
                        <DayStyle BorderWidth="2px" ForeColor="#666666" BorderStyle="Solid"
BorderColor="White"
                            BackColor="#EAEAEA"></DayStyle>
                        <DayHeaderStyle ForeColor="#649CBA"></DayHeaderStyle>
                        <SelectedDayStyle Font-Bold="True" ForeColor="#333333"
BackColor="#FAAD50"></SelectedDayStyle>
                        <WeekendDayStyle ForeColor="White"
BackColor="#BBBBBB"></WeekendDayStyle>
                        <OtherMonthDayStyle ForeColor="#666666"
BackColor="White"></OtherMonthDayStyle>
                    </asp:Calendar>
                    <br />
                    <table>
                        <tr>
                            <td valign="middle" colspan="2">
                                Date Selected:
                                <asp:Label ID="lblDate" runat="server">
                                </asp:Label>
                                <input id="datechosen" type="hidden" name="datechosen" runat="server">
                            </td>
                        </tr>
                        <tr>
                            <td valign="middle">
                                <asp:Button ID="OKButton" runat="server" Text="OK" />
                             </td>
                            <td valign="middle">
                                <asp:Button ID="CancelButton" runat="server" Text="Cancel" OnClientClick="javascript:self.close()"/>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </div>
        </div>
    </form>
</body>
</html>