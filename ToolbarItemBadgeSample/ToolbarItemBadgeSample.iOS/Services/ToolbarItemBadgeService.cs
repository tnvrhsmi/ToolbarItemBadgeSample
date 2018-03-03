﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using CoreGraphics;
using Foundation;
using ToolbarItemBadgeSample.iOS.Services;
using ToolbarItemBadgeSample.Services;
using UIKit;
using Xamarin.Forms;
using ToolbarItemBadgeSample.iOS.Utils;
using Xamarin.Forms.Platform.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(ToolbarItemBadgeService))]
namespace ToolbarItemBadgeSample.iOS.Services
{
    public class ToolbarItemBadgeService : IToolbarItemBadgeService
    {
        public void SetBadge(Page page, ToolbarItem item, string value,Color backgroundColor, Color textColor)
        {
            var renderer = Platform.GetRenderer(page);
            if (renderer == null)
            {
                renderer = Platform.CreateRenderer(page);
                Platform.SetRenderer(page, renderer);
            }
            var vc = renderer.ViewController;

            var rightButtomItems =vc?.ParentViewController?.NavigationItem?.RightBarButtonItems;
            var idx = page.ToolbarItems.IndexOf(item);
            if (rightButtomItems !=null && rightButtomItems.Length>idx)
            {
                var barItem = rightButtomItems[idx];
                if (barItem != null)
                {
                    barItem.UpdateBadge(value,backgroundColor.ToUIColor(),textColor.ToUIColor());
                }
            }

           
        }
    }
}