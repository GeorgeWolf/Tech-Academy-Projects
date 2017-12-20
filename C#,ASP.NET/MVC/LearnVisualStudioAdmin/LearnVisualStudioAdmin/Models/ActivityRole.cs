using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnVisualStudioAdmin.Models
{
    public class ActivityRole
    {
        public Guid Id { get; set; }

        public string RoleId { get; set; }
        public PermissionType Permission { get; set; }

    }

    public enum PermissionType
    {
        View,
        Download,
        Comment
    }
}