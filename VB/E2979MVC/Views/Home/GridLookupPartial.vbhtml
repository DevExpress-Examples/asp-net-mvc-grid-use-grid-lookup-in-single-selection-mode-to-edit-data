@Html.DevExpress().GridLookup(Sub(settings)

    settings.Name = "CategoryID"
    settings.Width = Unit.Percentage(100)
    settings.GridViewProperties.CallbackRouteValues = new With { .Controller = "Home", .Action = "GridLookupPartial", .CurrentCategory = Model.CategoryID  }
    settings.KeyFieldName = "CategoryID"
    settings.Columns.Add("CategoryName")
    settings.Columns.Add("Description")
    settings.ShowModelErrors = true
    settings.Properties.TextFormatString = "{0}:{1}"
    settings.Properties.IncrementalFilteringMode = IncrementalFilteringMode.Contains
    settings.Properties.SelectionMode = GridLookupSelectionMode.Single
    settings.Properties.ValidationSettings.Display = Display.Dynamic
    settings.Properties.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.ImageWithTooltip
End Sub).BindList(ViewData("Categories")).Bind(Model.CategoryID).GetHtml()

