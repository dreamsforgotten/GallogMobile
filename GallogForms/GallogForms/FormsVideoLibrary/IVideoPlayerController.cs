using System;

namespace GallogForms.FormsVideoLibrary
{
    public interface IVideoPlayerController
        {
            VideoStatus Status { set; get; }

            TimeSpan Duration { set; get; }
        }
    }