using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using SharedWPF;

namespace PoseClassifier
{
    internal class DataSource : ViewModelBase
    {
        #region == CaptureImage ==

        private WriteableBitmap? _captureImage;
        public WriteableBitmap? CaptureImage
        {
            get => _captureImage;
            set
            {
                if (_captureImage != value)
                {
                    _captureImage = value;
                    RaisePropertyChanged(nameof(CaptureImage));
                }
            }
        }

        #endregion
        #region == PoseLabel ==

        private string? _poseLabel;
        public string? PoseLabel
        {
            get => _poseLabel;
            set
            {
                if (_poseLabel != value)
                {
                    _poseLabel = value;
                    RaisePropertyChanged(nameof(PoseLabel));
                }
            }
        }

        #endregion
    }
}
