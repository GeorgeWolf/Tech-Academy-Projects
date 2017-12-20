using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnVisualStudioAdmin.Models
{
    public class VideoActionEditViewModel
    {
        public VideoActivity VideoActivity { get; set; }

        public string[] SelectedViewsItemIds { get; set; }
        public string[] SelectedDownloadsItemIds { get; set; }
        public string[] SelectedCommentsItemIds { get; set; }

        public MultiSelectList ViewsItems { get; set; }
        public MultiSelectList DownloadsItems { get; set; }
        public MultiSelectList CommentsItems { get; set; }
    }
}