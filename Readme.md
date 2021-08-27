<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128550902/15.1.9%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T328413)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/E2979MVC/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/E2979MVC/Controllers/HomeController.vb))
* [GridLookupPartial.cshtml](./CS/E2979MVC/Views/Home/GridLookupPartial.cshtml)
* [Index.cshtml](./CS/E2979MVC/Views/Home/Index.cshtml)
* [ProductsGridViewPartial.cshtml](./CS/E2979MVC/Views/Home/ProductsGridViewPartial.cshtml)
<!-- default file list end -->
# GridView - How to use GridLookup with single selection mode in EditForm 
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/t328413/)**
<!-- run online end -->


<p>This example illustrates how to use GridLookup with single selection mode (<a href="https://documentation.devexpress.com/#AspNet/DevExpressWebGridLookupProperties_SelectionModetopic">SelectionMode</a> is <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebGridLookupSelectionModeEnumtopic">Single</a>) in GridView for CRUD operations. By default, GridView doesn't have a built-in column for this scenario. The main idea is to use the <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebMvcMVCxGridViewColumn_SetEditItemTemplateContenttopic">MVCxGridViewColumn.SetEditItemTemplateContent</a> method to place GridLookup in EditForm. The same approach will work for a custom EditForm (<a href="https://documentation.devexpress.com/#AspNet/DevExpressWebMvcGridViewSettings_SetEditFormTemplateContenttopic">GridViewSettings.SetEditFormTemplateContent</a>) as well.<br><br>In order to use client-side unobtrusive JavaScript validation with GridLookup, it's necessary to pass a correct model instance to a partial view. This instance should be of the same type as an item of the collection bound to GridView.<br><br>Controller:<br><br></p>


```cs
public ActionResult GridLookupPartial(int? KeyParameter) {
      var model = GetModelInstanceByKey(KeyParameter);    
      return PartialView(model);
}
```


<p> </p>


```vb
Public Function GridLookupPartial(ByVal KeyParameter? As Integer) As ActionResult
	  Dim model = GetModelInstanceByKey(KeyParameter)
	  Return PartialView(model)
End Function
```


<p><br> PartialView:<br><br></p>


```cs
@Html.DevExpress().GridLookup(settings=>{
    settings.Name = PropertyName;
}).BindList(...).Bind(Model.PropertyName).GetHtml()
```




```vb
@Html.DevExpress().GridLookup(Sub(settings)
    settings.Name = PropertyName
End Sub).BindList(...).Bind(Model.PropertyName).GetHtml()
```


<p><br><strong>See also: </strong><br><a href="https://www.devexpress.com/Support/Center/p/T328613">GridView - How to use GridLookup in EditForm in multiple selection mode</a><br><br><strong>Web Forms:</strong><br><a href="https://www.devexpress.com/Support/Center/p/E2979">How to use two-way data-bound ASPxGridLookup in edit form of ASPxGridView to edit data</a><br><a href="https://www.devexpress.com/Support/Center/p/E3981">How to use ASPxGridLookup in multiple selection mode as the ASPxGridView editor</a></p>

<br/>


