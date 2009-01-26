using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Windows.Media.Imaging;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace TouchlessViewer
{
    class ImageRotator
    {
        #region Delegates
        public delegate void ChangeFormTitle(string title);
        #endregion

        #region Class Members
        /// <summary>
        /// Current image shown in PictureBox
        /// </summary>
        protected Image _currentImage;

        /// <summary>
        /// Temporary image to generate resized versions from
        /// </summary>
        protected Image _tempImage;

        /// <summary>
        /// Current index in the image collection
        /// </summary>
        protected int _imageIndex = 0;

        /// <summary>
        /// List containing the images.
        /// </summary>
        protected List<string> _images = new List<string>();
        public List<string> Images
        {
            get { return this._images; }
            set { this._images = value; }
        }

        /// <summary>
        /// Picturebox used to show the current image.
        /// </summary>
        protected PictureBox _pictureBox;
        public PictureBox PictureBox
        {
            get { return this._pictureBox; }
            set { this._pictureBox = value; }
        }

        /// <summary>
        /// Path to image directory.
        /// </summary>
        protected string _imagePath;
        public string ImagePath
        {
            get { return this._imagePath; }
            set { this._imagePath = value; }
        }

        /// <summary>
        /// List for allowed file extensions.
        /// </summary>
        protected List<string> _allowedExtensions = new List<string>();
        public List<string> AllowedExtensions
        {
            get { return this._allowedExtensions; }
            set { this._allowedExtensions = value; }
        }

        /// <summary>
        /// Determines, if slideshow should return to first image after the last one.
        /// </summary>
        protected bool _loopImages = true;
        public bool LoopImages
        {
            get { return this._loopImages; }
            set { this._loopImages = value; }
        }

        /// <summary>
        /// Access to MainForm's title (display stats like "image 3/15")
        /// </summary>
        protected ChangeFormTitle _formTitle;
        public ChangeFormTitle FormTitle
        {
            get { return this._formTitle; }
            set { this._formTitle = value; }
        }
        #endregion

        public void ThreadTest()
        {
            while (true)
            {
                Console.WriteLine("thread test");
                Thread.Sleep(200);
            }
        }

        public ImageRotator()
        {
        }

        /// <summary>
        /// Check for path existence and read the directory into the Images list.
        /// </summary>
        public void LoadImages()
        {
            this.Images = new List<string>();
            if (this._imagePath == "" || !Directory.Exists(this._imagePath))
                throw new ArgumentException("Path to image directory is invalid");

            this.ReadDirectory();
        }

        /// <summary>
        /// Read the directory into the Images list.
        /// </summary>
        protected void ReadDirectory()
        {
            // read files from filesystem and sort in natural order
            string[] files = System.IO.Directory.GetFiles(this.ImagePath);
            NumericComparer ns = new NumericComparer();
            Array.Sort(files, ns);

            foreach (string filename in files)
            {
                FileInfo file = new FileInfo(filename);
                if (this.AllowedExtensions.Contains(file.Extension.ToLower()))
                {
                    this.Images.Add(filename);
                }
            }
        }

        /// <summary>
        /// Search for filename in loaded image list and update image index.
        /// </summary>
        /// <param name="filename">filename to look for</param>
        public void FindByFilename(string filename)
        {
            int index = this.Images.FindIndex(image => image == filename);
            if (index < 0)
            {
                throw new ArgumentException("Filename not found in image list.");
            }
            else
            {
                this._imageIndex = index;
            }
        }

        /// <summary>
        /// Resize image on current index and display in PictureBox
        /// </summary>
        public void Show()
        {
            if (this._imageIndex < this.Images.Count)
            {
                this._tempImage = Image.FromFile(this.Images[this._imageIndex]);
                this.ScaleTempImage();
                this.SwitchImage();
                this.UpdateFormTitle();
            }
        }

        /// <summary>
        /// Set PictureBox image from _tempImage
        /// </summary>
        protected void SwitchImage()
        {
            this._currentImage = this._tempImage;
            this.PictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            this.PictureBox.Image = this._currentImage;
            this._tempImage = null;
            this.PictureBox.Refresh();
        }

        /// <summary>
        /// Move index to the next image and call Show()
        /// </summary>
        public void ShowNext()
        {
            if (this._imageIndex == (this.Images.Count - 1))
            {
                if (this.LoopImages)
                {
                    this._imageIndex = 0;
                    this.Show();
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            else
            {
                ++this._imageIndex;
                this.Show();
            }
        }

        /// <summary>
        /// Move index to the previous image and call Show()
        /// </summary>
        public void ShowPrevious()
        {
            if (this._imageIndex == 0)
            {
                if (this.LoopImages)
                {
                    this._imageIndex = this.Images.Count - 1;
                    this.Show();
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            else
            {
                --this._imageIndex;
                this.Show();
            }
        }

        /// <summary>
        /// Change the parent form's title
        /// </summary>
        protected void UpdateFormTitle()
        {
            int index = this._imageIndex + 1;
            this.UpdateFormTitle("Image " + index + "/" + this.Images.Count);
        }

        /// <summary>
        /// Change the parent form's title
        /// </summary>
        /// <param name="title">form title</param>
        protected void UpdateFormTitle(string title)
        {
            if (this.FormTitle != null)
                this.FormTitle(title);
        }

        /// <summary>
        /// Scale Image in _tempImage to PictureBox
        /// Source: http://www.codeproject.com/KB/GDI-plus/imageresize.aspx
        /// </summary>
        protected void ScaleTempImage()
        {
            int Width = this.PictureBox.Width;
            int Height = this.PictureBox.Height;
            int sourceWidth = this._tempImage.Width;
            int sourceHeight = this._tempImage.Height;

            if (Width == sourceWidth && Height == sourceHeight)
                return;

            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)Width / (float)sourceWidth);
            nPercentH = ((float)Height / (float)sourceHeight);
            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
                destX = System.Convert.ToInt16((Width -
                              (sourceWidth * nPercent)) / 2);
            }
            else
            {
                nPercent = nPercentW;
                destY = System.Convert.ToInt16((Height -
                              (sourceHeight * nPercent)) / 2);
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap bmPhoto = new Bitmap(Width, Height,
                              PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(this._tempImage.HorizontalResolution,
                                  this._tempImage.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(this.PictureBox.BackColor);
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(this._tempImage,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            this._tempImage = bmPhoto;
        }
    }
}
