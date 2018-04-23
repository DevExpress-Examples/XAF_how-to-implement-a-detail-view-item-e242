using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.NodeWrappers;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.Layout;


namespace HowToImplementDetailViewItem.Module.Win {

    public class MyDetailViewLayoutUpdater : ModelNodesGeneratorUpdater<ModelDetailViewLayoutNodesGenerator> {
        public override void UpdateNode(DevExpress.ExpressApp.Model.Core.ModelNode node) {
            IModelDetailViewLayout layoutNode = (IModelDetailViewLayout)node;
            IModelLayoutGroup myGroup = layoutNode.AddNode<IModelLayoutGroup>("ClassIcon");            
            myGroup.Index = 0;
            myGroup.RelativeSize = 1;
            myGroup.Direction = FlowDirection.Horizontal;
            IModelLayoutItem myItem = myGroup.AddNode<IModelLayoutItem>("Icon");
        }
    }

    public class MyDetailViewItemUpdater : ModelNodesGeneratorUpdater<ModelDetailViewItemsNodesGenerator> {
        public override void UpdateNode(DevExpress.ExpressApp.Model.Core.ModelNode node) {
            IModelDetailViewItems itemsNode = (IModelDetailViewItems)node;
            IModelClassIcon myItem = itemsNode.AddNode<IModelClassIcon>("Icon");
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
