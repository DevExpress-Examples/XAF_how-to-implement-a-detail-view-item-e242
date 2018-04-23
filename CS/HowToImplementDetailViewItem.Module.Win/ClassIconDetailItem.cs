using System;
using System.Drawing;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.Win.Editors;

namespace HowToImplementDetailViewItem.Module.Win {

	[DetailViewItemName("ClassIcon")]
	public class ClassIconDetailItem : DetailViewItem {
		public ClassIconDetailItem(Type classType, DictionaryNode info)
			: base(info, classType) {
		}
		protected override object CreateControlCore() {
			ResizablePictureBox imageControl = new ResizablePictureBox();
			string imageName = Info.Parent.Parent.GetAttributeValue("ImageName");
			ImageInfo imageInfo = ImageLoader.Instance.GetLargeImageInfo(imageName);
			if(imageInfo.IsEmpty) {
				imageControl.Visible = false;
			}
			else {
				Image image = imageInfo.Image;
				imageControl.Image = image;
				imageControl.Width = image.Width;
				imageControl.Height = image.Height;
			}
			return imageControl;
		}
	}
}