Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.ComponentModel

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.NodeWrappers
Imports DevExpress.ExpressApp.Model
Imports DevExpress.ExpressApp.Model.NodeGenerators
Imports DevExpress.ExpressApp.Model.Core
Imports DevExpress.ExpressApp.Layout


Namespace HowToImplementDetailViewItem.Module.Win

	Public Class MyDetailViewLayoutUpdater
		Inherits ModelNodesGeneratorUpdater(Of ModelDetailViewLayoutNodesGenerator)
		Public Overrides Sub UpdateNode(ByVal node As DevExpress.ExpressApp.Model.Core.ModelNode)
			Dim layoutNode As IModelDetailViewLayout = CType(node, IModelDetailViewLayout)
			Dim myGroup As IModelLayoutGroup = layoutNode.AddNode(Of IModelLayoutGroup)("ClassIcon")
			myGroup.Index = 0
			myGroup.RelativeSize = 1
			myGroup.Direction = FlowDirection.Horizontal
			Dim myItem As IModelLayoutItem = myGroup.AddNode(Of IModelLayoutItem)("Icon")
		End Sub
	End Class

	Public Class MyDetailViewItemUpdater
		Inherits ModelNodesGeneratorUpdater(Of ModelDetailViewItemsNodesGenerator)
		Public Overrides Sub UpdateNode(ByVal node As DevExpress.ExpressApp.Model.Core.ModelNode)
			Dim itemsNode As IModelDetailViewItems = CType(node, IModelDetailViewItems)
			Dim myItem As IModelClassIcon = itemsNode.AddNode(Of IModelClassIcon)("Icon")
		End Sub
	End Class

	<ToolboxItemFilter("Xaf.Platform.Win")> _
	Public NotInheritable Partial Class HowToImplementDetailViewItemWindowsFormsModule
		Inherits ModuleBase
		Public Sub New()
			InitializeComponent()
		End Sub
		Public Overrides Sub AddGeneratorUpdaters(ByVal updaters As ModelNodesGeneratorUpdaters)
			MyBase.AddGeneratorUpdaters(updaters)
			updaters.Add(New MyDetailViewLayoutUpdater())
			updaters.Add(New MyDetailViewItemUpdater())
		End Sub
	End Class
End Namespace
