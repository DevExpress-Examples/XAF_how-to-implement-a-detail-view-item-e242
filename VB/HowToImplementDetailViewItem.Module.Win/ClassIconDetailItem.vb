Imports System
Imports System.Drawing
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Utils
Imports DevExpress.ExpressApp.Win.Editors
<DetailViewItemName("ClassIcon")> _
Public Class ClassIconDetailItem
   Inherits DetailViewItem
   Public Sub New(ByVal classType As Type, ByVal info As DictionaryNode)
      MyBase.New(classType, info)
   End Sub
   Protected Overrides Function CreateControlCore() As Object
      Dim imageControl As ResizablePictureBox = New ResizablePictureBox()
      Dim imageName As String = Info.Parent.Parent.GetAttributeValue("ImageName")
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




