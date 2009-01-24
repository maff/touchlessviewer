using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Text;

namespace TouchlessViewer
{
    class RotatorImage
    {
        public RotatorImage()
        {
        }

        public RotatorImage(string filename, Image image)
        {
            this.Filename = filename;
            this.Image = image;
        }

        public override string ToString()
        {
            return this.Filename;
        }

        protected string _filename;
        public string Filename
        {
            get { return this._filename; }
            set { this._filename = value; }
        }

        protected Image _image;
        public Image Image
        {
            get { return this._image; }
            set { this._image = value; }
        }
    }
}
