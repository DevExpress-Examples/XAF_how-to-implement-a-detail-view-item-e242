Imports System
Imports System.Text
Imports System.Collections.Generic
Imports System.ComponentModel

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.NodeWrappers

<ToolboxItemFilter("Xaf.Platform.Win")> _
Partial Public NotInheritable Class [HowToImplementDetailViewItemWindowsFormsModule]
	Inherits ModuleBase
	Public Sub New()
		InitializeComponent()
   End Sub
   Public Overrides Sub UpdateModel(ByVal model As Dictionary)
      MyBase.UpdateModel(model)
      For Each viewInfo As BaseViewInfoNodeWrapper In New ApplicationNodeWrapper(model).Views.Items
         Dim detailViewInfo As DetailViewInfoNodeWrapper = TryCast(viewInfo, DetailViewInfoNodeWrapper)
         If Not detailViewInfo Is Nothing Then
            detailViewInfo.Editors.Node.AddChildNode("ClassIcon").SetAttribute("ID", "ClassIcon")
            Dim layoutNode As DictionaryNode = detailViewInfo.Node.GetChildNode("Layout")
            Dim rootGroupNode As DictionaryNode = New DictionaryNode("LayoutGroup")
            rootGroupNode.SetAttribute("ID", "Root")
            rootGroupNode.SetAttribute("Index", 0)
            rootGroupNode.SetAttribute("Direction", "Horizontal")
            Dim iconGroupNode As DictionaryNode = New DictionaryNode("LayoutGroup")
            iconGroupNode.SetAttribute("ID", "Icon")
            iconGroupNode.SetAttribute("Index", 0)
            iconGroupNode.SetAttribute("RelativeSize", 1)
            iconGroupNode.AddChildNode("LayoutItem").SetAttribute("ID", "ClassIcon")
            rootGroupNode.AddChildNode(iconGroupNode)
            If layoutNode.ChildNodeCount > 0 Then
               Dim mainNode As DictionaryNode = layoutNode.ChildNodes(0)
               layoutNode.RemoveChildNode(mainNode)
               rootGroupNode.AddChildNode(mainNode).SetAttribute("Index", 1)
            End If
            layoutNode.AddChildNode(rootGroupNode)
         End If
      Next viewInfo
   End Sub
End Class

