Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Text
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls


<DefaultProperty("Text"), ToolboxData("<{0}:AbsExporter runat=server></{0}:AbsExporter>")> _
Public Class AbsExporter
    Inherits Button

#Region " [ ] "

#End Region

#Region " [ PUBLIC PEROPERTIES ] "

    <Bindable(True), Category("Appearance"), DefaultValue(""), Localizable(True)> Overloads Property Text() As String
        Get
            Dim _text As String = CStr(ViewState("Text"))
            If _text Is Nothing Then
                Return String.Empty
            Else
                Return _text
            End If
        End Get

        Set(ByVal Value As String)
            ViewState("Text") = Value
        End Set
    End Property

    <Bindable(True), Category("Appearance"), DefaultValue(""), Localizable(True)> Overloads Property DataTable() As DataTable
        Get
            Dim dtExport As DataTable = CType(ViewState("DataTable"), DataTable)
            If dtExport Is Nothing Then
                Return Nothing
            Else
                Return dtExport
            End If
        End Get

        Set(ByVal Value As DataTable)
            ViewState("DataTable") = Value
        End Set
    End Property

#End Region

#Region " [ CLICK EVENT ] "

    Private Sub AbsExporter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        Dim dtExporter As DataTable
        If Not Me.DataTable Is Nothing Then
            dtExporter = Me.DataTable
            ExportDataToExcel(dtExporter)
        Else
            Me.ToolTip = "No Records to Export."
        End If
    End Sub

#End Region

#Region " [ PRIVATE METHODS ] "
    Private Sub ExportDataToExcel(ByVal dtExport As DataTable)
        Context.Response.Clear()
        Context.Response.Buffer = True
        Context.Response.Charset = ""
        Context.Response.ContentType = "application/vnd.ms-excel"
        Context.Response.AddHeader("Content-Disposition", "attachment; filename=""" & dtExport.TableName & """")

        Dim strData As String

        Dim Count, InnerCount As Integer
        Dim table As DataTable
        Dim row As DataRow

        table = dtExport

        If table.Rows.Count <= 0 Then
            Me.ToolTip = "No Records to Export."
            Exit Sub
        End If

        strData = "<table border = 1> "
        strData = strData & "<tr bgcolor = ""Yellow"">"
        For InnerCount = 0 To table.Columns.Count - 1
            strData &= "<td>" & table.Columns(InnerCount).ColumnName & "</td>"
        Next
        strData &= "</tr>"
        For Count = 0 To table.Rows.Count - 1
            row = table.Rows(Count)
            strData = strData & "<tr>"
            For InnerCount = 0 To table.Columns.Count - 1
                strData &= "<td>" & row.Item(InnerCount) & "</td>"
            Next
            strData &= "</tr>"
        Next
        strData &= "</table>"

        Context.Response.Write(strData)

        Context.Response.End()

    End Sub
#End Region

End Class
