Imports Microsoft.VisualBasic
Imports E2979DVC.Models
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc

Namespace E2979DVC.Controllers
	Public Class HomeController
		Inherits Controller
		'
		' GET: /Home/
		Private context As New NorthwindDataContext()
		Public Function Index() As ActionResult
			Return View()
		End Function

		Public Function ProductsGridViewPartial() As ActionResult
			Dim model = context.Products
			ViewData("Categories") = context.Categories
			Return PartialView(model)
		End Function

		Public Function GridLookupPartial(ByVal CurrentCategory? As Integer) As ActionResult
			ViewData("Categories") = context.Categories
			If Not CurrentCategory.HasValue Then
				CurrentCategory = -1
			End If
			Return PartialView(New Product() With {.CategoryID = CInt(Fix(CurrentCategory))})
		End Function
		<HttpPost, ValidateInput(False)> _
		Public Function ProductsGridViewAddNewPartial(ByVal item As Product) As ActionResult
			Dim model = context.Products
			ViewData("Categories") = context.Categories
			If ModelState.IsValid Then
				Try
					model.InsertOnSubmit(item)
					context.SubmitChanges() 'uncomment this line to save changes to a data base
				Catch e As Exception
					ViewData("EditError") = e.Message
				End Try
			Else
				ViewData("EditError") = "Please, correct all errors."
			End If

			Return PartialView("_ProductsGridViewPartial", model)
		End Function
		<HttpPost, ValidateInput(False)> _
		Public Function ProductsGridViewUpdatePartial(ByVal item As Product) As ActionResult
			Dim model = context.Products
			ViewData("Categories") = context.Categories
			If ModelState.IsValid Then
				Try
					Dim modelItem = model.FirstOrDefault(Function(it) it.ProductID = item.ProductID)
					If modelItem IsNot Nothing Then
						modelItem.ProductName = item.ProductName
						modelItem.UnitPrice = item.UnitPrice
						modelItem.CategoryID = item.CategoryID
						modelItem.QuantityPerUnit = item.QuantityPerUnit
					 '   context.SubmitChanges(); uncomment this line to save changes to a data base
					End If
				Catch e As Exception
					ViewData("EditError") = e.Message
				End Try
			Else
				ViewData("EditError") = "Please, correct all errors."
			End If

			Return PartialView("ProductsGridViewPartial", model)
		End Function
		<HttpPost, ValidateInput(False)> _
		Public Function ProductsGridViewDeletePartial(ByVal ProductID As System.Int32) As ActionResult

			Dim model = context.Products
			ViewData("Categories") = context.Categories
			If ProductID >= 0 Then
				Try
					Dim item = model.FirstOrDefault(Function(it) it.ProductID = ProductID)
					If item IsNot Nothing Then
						model.DeleteOnSubmit(item)
					End If
					' context.SubmitChanges(); uncomment this line to save changes to a data base
				Catch e As Exception
					ViewData("EditError") = e.Message
				End Try
			End If

			Return PartialView("_ProductsGridViewPartial", model)
		End Function
	End Class
End Namespace