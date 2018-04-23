using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.Layout;


namespace HowToImplementDetailViewItem.Module.Win {

    public class MyDetailViewLayoutUpdater : ModelNodesGeneratorUpdater<ModelDetailViewLayoutNodesGenerator> {
        public override void UpdateNode(DevExpress.ExpressApp.Model.Core.ModelNode node) {
            IModelViewLayout layoutNode = (IModelViewLayout)node;
            IModelLayoutGroup mainGroup = 
                layoutNode.GetNode(ModelDetailViewLayoutNodesGenerator.MainLayoutGroupName) as IModelLayoutGroup;
            mainGroup.Direction = FlowDirection.Horizontal;
            IModelLayoutViewItem myItem = mainGroup.AddNode<IModelLayoutViewItem>("Icon");
            myItem.Index = int.MinValue;
            myItem.MaxSize = new System.Drawing.Size(64, 64);
            myItem.SizeConstraintsType = XafSizeConstraintsType.Custom;
            myItem.ViewItem = ((IModelCompositeView)layoutNode.Parent).Items.GetNode("Icon") as IModelViewItem;
        }
    }

    public class MyDetailViewItemUpdater : ModelNodesGeneratorUpdater<ModelDetailViewItemsNodesGenerator> {
        public override void UpdateNode(DevExpress.ExpressApp.Model.Core.ModelNode node) {
            IModelViewItems itemsNode = (IModelViewItems)node;
            itemsNode.AddNode<IModelClassIcon>("Icon");
        }
    }

	[ToolboxItemFilter("Xaf.Platform.Win")]
	public sealed partial class HowToImplementDetailViewItemWindowsFormsModule : ModuleBase {
		public HowToImplementDetailViewItemWindowsFormsModule() {
			InitializeComponent();
		}
        public override void AddGeneratorUpdaters(ModelNodesGeneratorUpdaters updaters) {
            base.AddGeneratorUpdaters(updaters);
            updaters.Add(new MyDetailViewLayoutUpdater());
            updaters.Add(new MyDetailViewItemUpdater());
        }
	}
}
