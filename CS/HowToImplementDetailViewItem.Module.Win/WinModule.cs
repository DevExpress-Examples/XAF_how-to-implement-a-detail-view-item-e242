using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

using DevExpress.ExpressApp;

using DevExpress.ExpressApp.NodeWrappers;


namespace HowToImplementDetailViewItem.Module.Win {
	[ToolboxItemFilter("Xaf.Platform.Win")]
	public sealed partial class HowToImplementDetailViewItemWindowsFormsModule : ModuleBase {
		public HowToImplementDetailViewItemWindowsFormsModule() {
			InitializeComponent();
		}
		public override void UpdateModel(Dictionary model) {
			base.UpdateModel(model);
			foreach(BaseViewInfoNodeWrapper viewInfo in new ApplicationNodeWrapper(model).Views.Items) {
				DetailViewInfoNodeWrapper detailViewInfo = viewInfo as DetailViewInfoNodeWrapper;
				if(detailViewInfo != null) {
					detailViewInfo.Editors.Node.AddChildNode("ClassIcon").SetAttribute("ID", "ClassIcon");

					DictionaryNode layoutNode = detailViewInfo.Node.GetChildNode("Layout");

					DictionaryNode iconGroupNode = new DictionaryNode("LayoutGroup");
					iconGroupNode.SetAttribute("ID", "Icon");
					iconGroupNode.SetAttribute("Index", 0);
					iconGroupNode.SetAttribute("RelativeSize", 1);
					iconGroupNode.AddChildNode("LayoutItem").SetAttribute("ID", "ClassIcon");

					layoutNode.AddChildNode(iconGroupNode);
				}
			}
		}
	}
}
