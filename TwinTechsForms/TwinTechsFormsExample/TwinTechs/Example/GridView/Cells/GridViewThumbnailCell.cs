﻿using System;
using TwinTechs.Forms.Controls;
using TwinTechs.Example;
using TwinTechs.Controls;
using Xamarin.Forms;

namespace TwinTechs.Example.GridView.Cells
{
	public class GridViewThumbnailCell : FastGridCell
	{
		//TODO read this from the parent grid

		FastImage _image;

		public Label _titleLabel { get; set; }


		public GridViewThumbnailCell ()
		{
		}

		protected override void SetupCell (bool isRecycled)
		{
			if (MediaItem != null) {
				_image.ImageUrl = MediaItem.ThumbnailImagePath;
			}
			_titleLabel.Text = MediaItem != null ? MediaItem.Name : "";
		}

		protected override void InitializeCell ()
		{
			var width = CellSize.Width;
			var height = CellSize.Height;

			_titleLabel = new Label ();

			AbsoluteLayout simpleLayout = new AbsoluteLayout {
				VerticalOptions = LayoutOptions.FillAndExpand,
				WidthRequest = width,
				HeightRequest = height,
			};

			_image = new FastImage () {
				Aspect = Aspect.AspectFill,
				BackgroundColor = Color.Black,
			};

			_titleLabel = new Label {
				Text = "",
				TextColor = Color.White,
				FontSize = 14,
				XAlign = TextAlignment.Center,
				YAlign = TextAlignment.Center,
				LineBreakMode = LineBreakMode.TailTruncation,
				BackgroundColor = Color.FromHex ("#272727"),
			};

			simpleLayout.Children.Add (_image, new Rectangle (0, 0, width, height - 30));
			simpleLayout.Children.Add (_titleLabel, new Rectangle (0, height - 30, width, 30));
			View = simpleLayout;
		}


		public MediaItem MediaItem {
			get { return (MediaItem)BindingContext; }
		}
	}
}

