using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing;
using System.Windows.Forms;
using TouchlessLib;

namespace TouchlessViewer
{
    class TouchlessManager
    {
        #region object building
        protected static TouchlessManager _instance = null;
        protected static object _lock = new object();

        protected TouchlessManager()
        {
            this.Touchless = new TouchlessMgr();
        }

        /// <summary>
        /// Thread-safe Singleton
        /// </summary>
        public static TouchlessManager Instance
        {
            get
            {
                lock (TouchlessManager._lock)
                {
                    if (TouchlessManager._instance == null)
                    {
                        TouchlessManager._instance = new TouchlessManager();
                    }

                    return TouchlessManager._instance;
                }
            }
        }
        #endregion

        public bool _addingMarker = false;
        public float _markerRadius;
        public Point _markerCenter;
        public Marker _currentMarker;
        public int _addedMarkerCount = 0;
        public DateTime _dtFrameLast;
        public int _nFrameCount = 0;
        public Image _latestFrame;
        public bool _drawSelectionAdornment = false;
        public bool _updatingMarkerUI = false;

        protected TouchlessMgr _touchless;
        public TouchlessMgr Touchless
        {
            get { return this._touchless; }
            set { this._touchless = value; }
        }

        public bool checkCameras()
        {
            if (this.Touchless.Cameras.Count < 1)
                return false;

            return true;
        }
    }
}
