using System;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using SDWebImage;
using Foundation;
using TwinTechs.Controls;
using Xamarin.Forms;
using TwinTechs.Ios.Controls;

[assembly: ExportRenderer (typeof(FastImage), typeof(FastImageRenderer))]
namespace TwinTechs.Ios.Controls
{
	public class FastImageRenderer : ImageRenderer, IFastImageProvider
	{
		public FastImageRenderer ()
		{
		}

		protected override void OnElementChanged (ElementChangedEventArgs<Image> e)
		{
			base.OnElementChanged (e);
//			if (e.OldElement != null) {
//				((FastImage)e.OldElement).ImageProvider = null;
//			}
			if (e.NewElement != null) {
				var fastImage = e.NewElement as FastImage;
				SetImageUrl (fastImage.ImageUrl);
			}
		}

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);
			if (e.PropertyName == "ImageUrl") {
				var fastImage = Element as FastImage;
				SetImageUrl (fastImage.ImageUrl);
			}
		}

		#region FastImageProvider implementation

	    public void SetImageUrl(string imageUrl)
	    {
	        if (this.Control == null)
	        {
	            return;
	        }
	        if (imageUrl != null)
	        {
	            this.Control.SetImage(
	                url: new NSUrl(imageUrl),
	                placeholder: null,
	                options: SDWebImageOptions.HighPriority
	                    | SDWebImageOptions.RetryFailed
	                    | SDWebImageOptions.ContinueInBackground);
	        }
	        else
	        {
//				Control.Image = UIImage.FromBundle ("placeholder.png");
	        }
	    }

		#endregion
	}
}

