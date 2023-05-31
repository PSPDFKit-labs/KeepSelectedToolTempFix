# KeepSelectedToolTempFix
a one line temporary fix for using notes under KeepSelectedTool 

line 42 in MainPage.xaml.cs:

 `await sender.Controller.SetViewStateAsync(new ViewState { AppearanceStreamTypes = new[] { AnnotationType.Note } });`
