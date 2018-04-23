Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Utils
Imports DevExpress.ExpressApp.Win.Editors
Imports DevExpress.ExpressApp.Model

Namespace HowToImplementDetailViewItem.Module.Win

	Public Interface IModelClassIcon
        Inherits IModelViewItem
	End Interface

	<ViewItemAttribute(GetType(IModelClassIcon))> _
	Public Class ClassIconDetailItem
		Inherits ViewItem
		Private Info As IModelClassIcon
		Public Sub New(ByVal info As IModelClassIcon, ByVal classType As Type)
			MyBase.New(classType, info.Id)
			Me.Info = info
		End Sub
		Protected Overrides Function CreateControlCore() As Object
			Dim imageControl As New ResizablePictureBox()
			Dim imageName As String = (CType(Info.Parent.Parent, IModelDetailView)).ImageName
			Dim imageInfo As ImageInfo = ImageLoader.Instance.GetLargeImageInfo(imageName)
			If imageInfo.IsEmpty Then
				imageControl.Visible = False
			Else
				Dim image As Image = imageInfo.Image
				imageControl.Image = image
				imageControl.Width = image.Width
				imageControl.Height = image.Height
			End If
			Return imageControl
		End Function
	End Class
End Namespace