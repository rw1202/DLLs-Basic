Imports System.Collections.ObjectModel
Imports System.Configuration
Imports AdventureWorks.EntityLayer
Imports Common.Library


Public Class ProductManager
    Inherits DataManagerBase

    Private ProductID As Integer

    Function LoadProducts() As ObservableCollection(Of Product)
        Return LoadProducts()
    End Function

    Function LoadProducts(ByVal startingFilePath As String) As ObservableCollection(Of Product)
        Dim ret = New ObservableCollection(Of Product)()

        Try
            Dim doc = MyBase.LoadXElement(
                ConfigurationManager.AppSettings("Products File"),
                startingFilePath)
            Dim products = From prod In doc.<Product>
                           Select New ProductManager With {
                           .ProductID = Convert.ToInt32(prod.Element("ProductID"))
                           }
        Catch ex As Exception

        End Try
    End Function
End Class
