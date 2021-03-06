﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Media.Capture;
using Windows.Storage;
using System.Threading;
using System.Threading.Tasks;
using Windows.Media.MediaProperties;
using SharedProject;
using Windows.Devices.Enumeration;



// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace EpicEvalsWindows
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private MediaCapture _captureManager = null;
        private BitmapImage _bmpImage = null;
        private StorageFile _file = null;
        private bool _isCaptureMode = true;
        private int currentCameraIndex = 0;
        DeviceInformation cameraDevice;
        DeviceInformationCollection devices;

        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;

            
        }

        private async Task InitCameraSwitch()
        {
            devices = await DeviceInformation.FindAllAsync(DeviceClass.VideoCapture);

            if (devices.Count > 0)
            {
                if (devices.Count >= 2)
                {
                    cameraSwitch.Visibility = Visibility.Visible;
                    cameraSwitch.Click += CameraSwitch_Click;
                    currentCameraIndex = 0;
                    cameraDevice = devices.FirstOrDefault(d => d.EnclosureLocation.Panel == Windows.Devices.Enumeration.Panel.Front);
                }
            }
        }

        private async void CameraSwitch_Click(object sender, RoutedEventArgs e)
        {
            if (currentCameraIndex == 0)
            {
                cameraDevice = devices[1];
                currentCameraIndex = 1;
            }
            else
            {
                cameraDevice = devices[0];
                currentCameraIndex = 0;
            }

            await InitMediaCapture();
        }

        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            await InitCameraSwitch();
            await InitMediaCapture();
        }

        private async Task<bool> InitMediaCapture()
        {
            _captureManager = new MediaCapture();
            await _captureManager.InitializeAsync(new MediaCaptureInitializationSettings()
            {
                VideoDeviceId = cameraDevice.Id
            }
                );

            captureElement.Source = _captureManager;
            captureElement.FlowDirection = FlowDirection.RightToLeft;

            // start capture preview
            await _captureManager.StartPreviewAsync();

            return true;
        }

        private async Task<bool> ImageCaptureAndDisplay()
        {
            ImageEncodingProperties imageFormat = ImageEncodingProperties.CreateJpeg();

            // create storage file in local app storage 
            _file = await ApplicationData.Current.LocalFolder.CreateFileAsync(
                 $"myPhoto_{Guid.NewGuid()}.jpg",
                 CreationCollisionOption.GenerateUniqueName);

            // capture to file 
            await _captureManager.CapturePhotoToStorageFileAsync(imageFormat, _file);

            _bmpImage = new BitmapImage(new Uri(_file.Path));
            previewImage.Source = _bmpImage;

            return true;
        }

        private async void OnActionClick(object sender, RoutedEventArgs e)
        {
            if (_isCaptureMode == true)
            {
                await ImageCaptureAndDisplay();

                try
                {
                    float result = await Core.GetAvgEmotionScore(await _file.OpenStreamForReadAsync());

                    hapinessRatio.Text = Core.GetEmotionMessage(result);

                    previewImage.Visibility = Visibility.Visible;
                }
                catch (Exception ex)
                {
                    hapinessRatio.Text = ex.Message;
                }
                finally
                {
                    actionButton.Content = "Reset";
                    _isCaptureMode = false;
                }
            }
            else
            {
                previewImage.Visibility = Visibility.Collapsed;
                actionButton.Content = "Take Picture";
                hapinessRatio.Text = "";
                _isCaptureMode = true;
            }
        }
    }
}
