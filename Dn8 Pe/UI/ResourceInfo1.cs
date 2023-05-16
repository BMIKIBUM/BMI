using System;
using System.Collections;
using System.Drawing;
using System.Resources;
using System.Reflection;
using System.Windows.Forms;
namespace WorkTerminal.UI
{

	public class ResourceInfo1
	{
		public static ResourceManager ResManager;
		public static ResourceManager ResTracking;
		public static ResourceManager ResDate;

		#region [Method] ResourceManagerSet : Resource Manager Set
		public static void ResourceManagerSet()
		{
			ResManager	= new ResourceManager( "WorkTerminal", Assembly.GetCallingAssembly());
		}
		#endregion

		#region [Method] ResManager GetImage : Image Select
		/// <summary>
		/// Image Select
		/// </summary>
		/// <param name="strImage">Image Name</param>
		/// <returns>Image</returns>
		public static Image GetImage(string strImage)
		{
            Image imgIcon;
			try
			{
				imgIcon = (Image) ResManager.GetObject(strImage);
			}
			catch (Exception ex)
			{
                imgIcon = null;
				//imgIcon = (Image) ResManager.GetObject("IMAGE.NONE");
				//SqlError.SystemError("ResourceInfo", ex);
			}
			return imgIcon;
		}
		#endregion

		#region [Method] ResTracking GetImage : Image Select
		/// <summary>
		/// Image Select
		/// </summary>
		/// <param name="strImage">Image Name</param>
		/// <returns>Image</returns>
        //public static Image TrackingGetImage(string strImage)
        //{
        //    Image imgIcon;

        //    try
        //    {
        //        imgIcon = (Image)ResTracking.GetObject(strImage);
        //    }
        //    catch (Exception ex)
        //    {
        //        //imgIcon = (Image) ResTracking.GetObject("NONE");
        //        //SqlError.SystemError("ResourceInfo", ex);
        //    }
        //    return imgIcon;
        //}
		#endregion

		#region [Method] ResDate GetImage : Image Select
		/// <summary>
		/// Image Select
		/// </summary>
		/// <param name="strImage">Image Name</param>
		/// <returns>Image</returns>
		public static Image DateGetImage(string strImage)
		{
			Image imgIcon;

			try
			{
				imgIcon = (Image) ResDate.GetObject(strImage);
			}
			catch (Exception ex)
			{
				imgIcon = (Image) ResDate.GetObject("NONE");
				//SqlError.SystemError("ResourceInfo", ex);
			}
			return imgIcon;
		}
		#endregion
		
		#region [Method] ResManager ImageListSet : ToolBar용 ImageList에 Image Add
		/// <summary>
		/// ToolBar용 ImageList에 Image Add
		/// </summary>
		/// <param name="imgList">ImageList</param>
		/// <param name="strOption">구분자</param>
		public static void ImageListSet(ImageList imgList, string strOption)
		{
			try
			{
				string[] strEnum = new string[0];

                //switch (strOption)
                //{
                //    case "TOOLBAR":
                //        strEnum = Enum.GetNames(typeof(ToolBarButtonEnum));
                //        imgList.ImageSize = new System.Drawing.Size(32, 32);
                //        break;
                //    case "TOOLBAR16":
                //        strOption = "TOOLBAR";
                //        strEnum = Enum.GetNames(typeof(ToolBarButtonEnum));
                //        imgList.ImageSize = new System.Drawing.Size(16, 16);
                //        break;
                //    case "TREEVIEW":
                //        strOption = "IMAGE";
                //        strEnum = Enum.GetNames(typeof(TreeViewImageEnum));
                //        imgList.ImageSize = new System.Drawing.Size(16, 16);
                //        break;
                //    default:
                //        return;
                //}

				imgList.ColorDepth = ColorDepth.Depth32Bit;
				imgList.TransparentColor = System.Drawing.Color.Transparent;
				imgList.Images.Clear();

				for (int i = 0; i < strEnum.Length; i++)
				{
					imgList.Images.Add((Image) ResManager.GetObject(strOption + "." + strEnum[i]));
				}
			}			
			catch (Exception ex)
			{
				//SqlError.SystemError("ResourceInfo", ex);
			}
		}
		#endregion
	}
}