using Emgu.CV;

String webcamString = "Webcam Edges";

//creating a window to display the webcam
CvInvoke.NamedWindow(webcamString);

//using the gaussian blur to reduce noise
Mat gaussianBlur = new Mat();

//using the sobel operator to detect edges
Mat sobelXY = new Mat();

//using the webcam to capture the video
using (Mat frame = new Mat())
using (VideoCapture capture = new VideoCapture())
    while (CvInvoke.WaitKey(1) == -1)
    {
        //reading the frame from the webcam
        capture.Read(frame);

        //applying the gaussian blur and sobel operator
        CvInvoke.GaussianBlur(frame, gaussianBlur, new System.Drawing.Size(3, 3), 5.0);
        CvInvoke.Sobel(gaussianBlur, sobelXY, Emgu.CV.CvEnum.DepthType.Default, 1, 1, 5);

        //displaying the frame
        CvInvoke.Imshow(webcamString, sobelXY);
    }
