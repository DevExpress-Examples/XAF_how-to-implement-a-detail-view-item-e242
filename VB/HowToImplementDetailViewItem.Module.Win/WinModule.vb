Imports System.Text
Imports System.ComponentModel

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Model
Imports DevExpress.ExpressApp.Model.NodeGenerators
Imports DevExpress.ExpressApp.Model.Core
Imports DevExpress.ExpressApp.Layout


Namespace HowToImplementDetailViewItem.Module.Win

    Public Class MyDetailViewLayoutUpdater
        Inherits ModelNodesGeneratorUpdater(Of ModelDetailViewLayoutNodesGenerator)

        Public Overrides Sub UpdateNode(ByVal node As DevExpress.ExpressApp.Model.Core.ModelNode)
            Dim layoutNode As IModelViewLayout = CType(node, IModelViewLayout)
            Dim mainGroup As IModelLayoutGroup = TryCast(layoutNode.GetNode(ModelDetailViewLayoutNodesGenerator.MainLayoutGroupName), IModelLayoutGroup)
            mainGroup.Direction = FlowDirection.Horizontal
            Dim myItem As IModelLayoutViewItem = mainGroup.AddNode(Of IModelLayoutViewItem)("Icon")
            myItem.Index = Integer.MinValue
            myItem.MaxSize = New System.Drawing.Size(64, 64)
            myItem.SizeConstraintsType = XafSizeConstraintsType.Custom
            myItem.ViewItem = TryCast(CType(layoutNode.Parent, IModelCompositeView).Items.GetNode("Icon"), IModelViewItem)
        End Sub
    End Class

    Public Class MyDetailViewItemUpdater
        Inherits ModelNodesGeneratorUpdater(Of ModelDetailViewItemsNodesGenerator)

        Public Overrides Sub UpdateNode(ByVal node As DevExpress.ExpressApp.Model.Core.ModelNode)
            Dim itemsNode As IModelViewItems = CType(node, IModelViewItems)
            itemsNode.AddNode(Of IModelClassIcon)("Icon")
        End Sub
    End Class

    <ToolboxItemFilter("Xaf.Platform.Win")>
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
