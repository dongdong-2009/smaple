Imports Microsoft.Office
Imports System.IO
Imports Mysoft.Map.Excel

Module Module1

    Sub Main()
        Dim missing As Object = System.Reflection.Missing.Value
        Dim xls As New Microsoft.Office.Interop.Excel.Application
        xls.DisplayAlerts = False

        If File.Exists("c:\3.xls") Then
            File.Delete("c:\3.xls")
        End If
        xls.Workbooks.Add()
        Dim wb As Microsoft.Office.Interop.Excel.Workbook = xls.Workbooks(1)

        xls.SheetsInNewWorkbook = 1

        Dim ws As New Microsoft.Office.Interop.Excel.Worksheet
        ws = wb.Sheets("Sheet1")


        Dim range As Microsoft.Office.Interop.Excel.Range
        ws.Range("A1", "C10").Borders.ColorIndex = 1
        range = ws.Range("A1", "A1")
        range.Font.Color = -11489280
        range.Borders(Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom).ColorIndex = 0
        ws.Range("A1:A1").EntireColumn.Hidden = True
        ws.Range("A1", "P1").Value = "sdfasdfasdfsa"
        ws.SaveAs("c:\3.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel7, missing, missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, missing, missing, missing, missing, missing)
        xls.Quit()
        System.Runtime.InteropServices.Marshal.ReleaseComObject(xls)
        xls = Nothing
        GC.Collect()


        'Dim wb1 As New ExcelWookbook
        'wb1.LoadXls("C:\3.xls")

        'Console.Write(42 \ 27)
        'Console.Read()
        'Console.Write(HexConvert(126))
        'Console.Read()
    End Sub

    Public Function HexConvert(ByVal intNum As Integer, Optional ByVal intHex As Integer = 27) As String
        If intNum <= 0 Or intHex <= 0 Then
            Return intNum
        End If

        If intNum > 26 Then
            intNum = intNum + 1
        End If

        Dim strResult As String = String.Empty
        Dim intShang As Integer  '商
        Dim intYushu As Integer '余数
        Do While intNum > 0
            intShang = intNum \ intHex
            intYushu = intNum Mod intHex
            strResult = Chr(intYushu + 65 - 1) & strResult
            intNum = intShang
        Loop
        Return strResult
    End Function

End Module
