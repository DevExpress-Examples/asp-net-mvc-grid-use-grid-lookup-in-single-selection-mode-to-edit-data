@Html.DevExpress().GridView(Sub(settings)

                                settings.Name = "ProductsGridView"
                                settings.KeyFieldName = "ProductID"
                                settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "ProductsGridViewPartial"}
                                settings.SettingsEditing.AddNewRowRouteValues = New With {.Controller = "Home", .Action = "ProductsGridViewAddNewPartial"}
                                settings.SettingsEditing.UpdateRowRouteValues = New With {.Controller = "Home", .Action = "ProductsGridViewUpdatePartial"}
                                settings.SettingsEditing.DeleteRowRouteValues = New With {.Controller = "Home", .Action = "ProductsGridViewDeletePartial"}
                                settings.CommandColumn.Visible = True
                                settings.CommandColumn.ShowEditButton = True
                                settings.CommandColumn.ShowNewButton = True
                                settings.CommandColumn.ShowDeleteButton = True
                                settings.Columns.Add(Sub(column)
    
                                                         column.FieldName = "ProductID"
                                                         column.EditFormSettings.Visible = DefaultBoolean.False
                                                     End Sub)
                                settings.Columns.Add("ProductName")
                                settings.Columns.Add(Sub(column)
    
                                                         column.FieldName = "CategoryID"
                                                         column.Caption = "Category"
                                                         column.ColumnType = MVCxGridViewColumnType.ComboBox
                                                         Dim properties As ComboBoxProperties = TryCast(column.PropertiesEdit, ComboBoxProperties)
                                                         properties.TextField = "CategoryName"
                                                         properties.ValueField = "CategoryID"
                                                         properties.ValueType = GetType(Int32)
                                                         properties.DataSource = ViewData("Categories")
                                                         column.SetEditItemTemplateContent(Sub(container)
                                                                                               Html.RenderAction("GridLookupPartial", New With {.CurrentCategory = DataBinder.Eval(container.DataItem, "CategoryID")})
                                                                                           End Sub)
                                                     End Sub)
                                settings.Columns.Add("QuantityPerUnit")
                                settings.Columns.Add(Sub(column)
                                                         column.FieldName = "UnitPrice"
                                                         column.ColumnType = MVCxGridViewColumnType.SpinEdit
                                                         Dim properties As SpinEditProperties = TryCast(column.PropertiesEdit, SpinEditProperties)
                                                         properties.DecimalPlaces = 2
                                                         properties.DisplayFormatString = "C2"
                                                     End Sub)
                                settings.CellEditorInitialize = Sub(s, e)
                                                                    CType(e.Editor, ASPxEdit).ValidationSettings.Display = Display.Dynamic
                                                                End Sub
                            End Sub).SetEditErrorText(CStr(ViewData("EditError"))).Bind(Model).GetHtml()